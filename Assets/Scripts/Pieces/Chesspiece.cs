using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Piece", menuName = "Chess Data", order = 51)]
public class Chesspiece : ScriptableObject
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int xp;
    [SerializeField]
    private int level;
    [SerializeField]
    private AssetReferenceSprite sprite;
    [SerializeField]
    private MoveData[] moves;

    public int Hp { get => hp; }
    public int Xp { get => xp; }
    public int Level { get => level; }
    public AssetReferenceSprite Sprite { get => sprite; }
    public MoveData[] Moves { get => moves; }
}
