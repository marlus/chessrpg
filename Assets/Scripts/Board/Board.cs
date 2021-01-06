using UnityEditor;
using UnityEngine;

public enum BoardCellState
{
    Invalid,
    Valid,
    Initial
}

[System.Serializable]
public class Board
{
    [SerializeField]
    public int MatrixSize = 8;

    [System.Serializable]
    public struct RowData
    {
        public BoardCellState[] row;
    }

    [SerializeField]
    public RowData[] rows = new RowData[8];
}
