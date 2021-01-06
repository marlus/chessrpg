using UnityEngine;

[CreateAssetMenu(fileName = "New Piece Move", menuName = "Move Data", order = 51)]
public class MoveData : ScriptableObject
{
    [SerializeField]
    private Board move;
}
