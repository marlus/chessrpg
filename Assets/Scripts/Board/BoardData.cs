using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Board", menuName = "Board Data", order = 52)]
public class BoardData : ScriptableObject
{
    [SerializeField]
    private Board _board;

    [SerializeField]
    private AssetReference[] _tiles;

    [SerializeField]
    private AssetReference[] _pieces;

    public Board Board { get => _board; }
    public AssetReference[] Tiles { get => _tiles; }
    public AssetReference[] Pieces { get => _pieces; }
}
