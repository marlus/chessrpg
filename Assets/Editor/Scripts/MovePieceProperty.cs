using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Board))]
public class MovePieceProperty : PropertyDrawer
{
    private const float RectSize = 40f;
    private const float BorderSize = 3f;
	private int _matrixSize;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		EditorGUI.PrefixLabel(position, label);

		var matrixSize = property.FindPropertyRelative("MatrixSize");
		matrixSize.intValue = (int)EditorGUILayout.Slider(matrixSize.intValue, 1, 8);
		_matrixSize = matrixSize.intValue;

		position.x += RectSize;
		position.y += RectSize;
		Rect newposition = position;
		SerializedProperty data = property.FindPropertyRelative("rows");
		data.arraySize = _matrixSize;

		for (int i = 0; i < _matrixSize; i++)
		{
			SerializedProperty row = data.GetArrayElementAtIndex(i).FindPropertyRelative("row");

			newposition.width = RectSize;
			newposition.height = RectSize;

			if (row.arraySize != _matrixSize)
				row.arraySize = _matrixSize;

			for (int j = 0; j < _matrixSize; j++)
			{
				var cell = row.GetArrayElementAtIndex(j);
				var cellColor = ((i + j) % 2 == 0) ? Color.white : Color.black;
				var cellSize = RectSize - (BorderSize * 2);
				var cellState = (BoardCellState) Enum.ToObject(typeof(BoardCellState), cell.intValue);

				// Draw check board border
				switch (cellState)
                {
                    case BoardCellState.Initial:
						EditorGUI.DrawRect(new Rect(newposition.min.x, newposition.min.y, RectSize, RectSize), Color.green);
						break;
					case BoardCellState.Valid:
						EditorGUI.DrawRect(new Rect(newposition.min.x, newposition.min.y, RectSize, RectSize), Color.magenta);
						break;
					default:
						EditorGUI.DrawRect(new Rect(newposition.min.x, newposition.min.y, RectSize, RectSize), cellColor);
						break;
                }

                // C# 8
                //EditorGUI.DrawRect(new Rect(newposition.min.x, newposition.min.y, RectSize, RectSize), cellState switch
                //{
                //    MoveState.Initial => Color.green,
                //    MoveState.Valid => Color.magenta,
                //    _ => cellColor,
                //});

                // Draw check board alternating color
                EditorGUI.DrawRect(new Rect(newposition.min.x + BorderSize, newposition.min.y + BorderSize, cellSize, cellSize), cellColor);

				// Enable/Disable cell based on click behavior
				if (Event.current.type == EventType.MouseDown && newposition.Contains(Event.current.mousePosition))
                {
					switch (cellState)
                    {
						case BoardCellState.Invalid:
							if (Event.current.button == 0) cell.intValue = (int) BoardCellState.Valid;
							else if (Event.current.button == 1) cell.intValue = (int) BoardCellState.Initial;
							break;
						case BoardCellState.Valid:
							if (Event.current.button == 0) cell.intValue = (int)BoardCellState.Invalid;
							else if (Event.current.button == 1) cell.intValue = (int)BoardCellState.Initial;
							break;
						default:
							if (Event.current.button == 0) cell.intValue = (int)BoardCellState.Valid;
							else if (Event.current.button == 1) cell.intValue = (int)BoardCellState.Invalid;
							break;
					}

					// C# 8
					//cell.intValue = (cellState, Event.current.button) switch
					//{
					//	var (state, button) when state == MoveState.Invalid && button	== 0 => (int) MoveState.Valid,
					//	var (state, button) when state == MoveState.Valid && button		== 0 => (int) MoveState.Invalid,
					//	var (state, button) when state == MoveState.Initial && button	== 0 => (int) MoveState.Valid,
					//	var (state, button) when state == MoveState.Invalid && button	== 1 => (int) MoveState.Initial,
					//	var (state, button) when state == MoveState.Valid && button		== 1 => (int) MoveState.Initial,
					//	var (state, button) when state == MoveState.Initial && button	== 1 => (int) MoveState.Invalid,
					//	_ => throw new NotImplementedException(),
					//};

				}

				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += RectSize;
		}

		EditorGUILayout.PropertyField(data);
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return RectSize * (_matrixSize + 1);
	}
}
