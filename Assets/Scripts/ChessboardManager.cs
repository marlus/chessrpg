using UnityEngine;
using UnityEngine.AddressableAssets;

public class ChessboardManager : MonoBehaviour
{
    void Start()
    {
        CreateBoard();
    }

    public async void CreateBoard()
    {
        BoardData boardData = await Addressables.LoadAssetAsync<BoardData>("board").Task;

        // Load tiles
        var whiteTileObj = await boardData.Tiles[0].LoadAssetAsync<GameObject>().Task;
        var blackTileObj = await boardData.Tiles[1].LoadAssetAsync<GameObject>().Task;

        // load pieces
        var whitePawn = await boardData.Pieces[0].LoadAssetAsync<GameObject>().Task;
        var whiteRook = await boardData.Pieces[1].LoadAssetAsync<GameObject>().Task;
        var whiteKnight = await boardData.Pieces[2].LoadAssetAsync<GameObject>().Task;
        var whiteBishop = await boardData.Pieces[3].LoadAssetAsync<GameObject>().Task;
        var whiteQueen = await boardData.Pieces[4].LoadAssetAsync<GameObject>().Task;
        var whiteKing = await boardData.Pieces[5].LoadAssetAsync<GameObject>().Task;

        var blackPawn = await boardData.Pieces[6].LoadAssetAsync<GameObject>().Task;
        var blackRook = await boardData.Pieces[7].LoadAssetAsync<GameObject>().Task;
        var blackKnight = await boardData.Pieces[8].LoadAssetAsync<GameObject>().Task;
        var blackBishop = await boardData.Pieces[9].LoadAssetAsync<GameObject>().Task;
        var blackQueen = await boardData.Pieces[10].LoadAssetAsync<GameObject>().Task;
        var blackKing = await boardData.Pieces[11].LoadAssetAsync<GameObject>().Task;

        // Create chessboard tiles
        GameObject l_tile;

        for (int row = 0; row < boardData.Board.MatrixSize; row++)
        {
            for (int col = 0; col < boardData.Board.MatrixSize; col++)
            {
                if ((row + col) % 2 == 0)
                    l_tile = Instantiate(blackTileObj, transform);
                else
                    l_tile = Instantiate(whiteTileObj, transform);

                l_tile.transform.position = new Vector2(col, row);
            }
        }

        // Create chessboard pieces
        GameObject l_piece;

        // --- White pieces ---

        // White pawn 1
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(0, 1);

        // White pawn 2
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(1, 1);

        // White pawn 3
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(2, 1);

        // White pawn 4
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(3, 1);

        // White pawn 5
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(4, 1);

        // White pawn 6
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(5, 1);

        // White pawn 7
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(6, 1);

        // White pawn 8
        l_piece = Instantiate(whitePawn, transform);
        l_piece.transform.position = new Vector2(7, 1);

        // White rook 1
        l_piece = Instantiate(whiteRook, transform);
        l_piece.transform.position = new Vector2(0, 0);

        // White rook 2
        l_piece = Instantiate(whiteRook, transform);
        l_piece.transform.position = new Vector2(7, 0);

        // White knight 1
        l_piece = Instantiate(whiteKnight, transform);
        l_piece.transform.position = new Vector2(1, 0);

        // White knight 2
        l_piece = Instantiate(whiteKnight, transform);
        l_piece.transform.position = new Vector2(6, 0);

        // White bishop 1
        l_piece = Instantiate(whiteBishop, transform);
        l_piece.transform.position = new Vector2(2, 0);

        // White bishop 2
        l_piece = Instantiate(whiteBishop, transform);
        l_piece.transform.position = new Vector2(5, 0);

        // White queen
        l_piece = Instantiate(whiteQueen, transform);
        l_piece.transform.position = new Vector2(3, 0);

        // White king
        l_piece = Instantiate(whiteKing, transform);
        l_piece.transform.position = new Vector2(4, 0);

        // --- Black pieces ---

        // Black pawn 1
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(0, 6);

        // Black pawn 2
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(1, 6);

        // Black pawn 3
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(2, 6);

        // Black pawn 4
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(3, 6);

        // Black pawn 5
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(4, 6);

        // Black pawn 6
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(5, 6);

        // Black pawn 7
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(6, 6);

        // Black pawn 8
        l_piece = Instantiate(blackPawn, transform);
        l_piece.transform.position = new Vector2(7, 6);

        // Black rook 1
        l_piece = Instantiate(blackRook, transform);
        l_piece.transform.position = new Vector2(0, 7);

        // Black rook 2
        l_piece = Instantiate(blackRook, transform);
        l_piece.transform.position = new Vector2(7, 7);

        // Black knight 1
        l_piece = Instantiate(blackKnight, transform);
        l_piece.transform.position = new Vector2(1, 7);

        // Black knight 2
        l_piece = Instantiate(blackKnight, transform);
        l_piece.transform.position = new Vector2(6, 7);

        // Black bishop 1
        l_piece = Instantiate(blackBishop, transform);
        l_piece.transform.position = new Vector2(2, 7);

        // Black bishop 2
        l_piece = Instantiate(blackBishop, transform);
        l_piece.transform.position = new Vector2(5, 7);

        // Black queen
        l_piece = Instantiate(blackQueen, transform);
        l_piece.transform.position = new Vector2(3, 7);

        // Black king
        l_piece = Instantiate(blackKing, transform);
        l_piece.transform.position = new Vector2(4, 7);

        // Center the board on the sceen
        transform.position = new Vector2(-boardData.Board.MatrixSize / 2 + 2 / 2, -3.5f);

        // Release addressable data used to create the board
        boardData.Tiles[0].ReleaseAsset();
        boardData.Tiles[1].ReleaseAsset();
        boardData.Pieces[0].ReleaseAsset();
        boardData.Pieces[1].ReleaseAsset();
        boardData.Pieces[2].ReleaseAsset();
        boardData.Pieces[3].ReleaseAsset();
        boardData.Pieces[4].ReleaseAsset();
        boardData.Pieces[5].ReleaseAsset();
        boardData.Pieces[6].ReleaseAsset();
        boardData.Pieces[7].ReleaseAsset();
        boardData.Pieces[8].ReleaseAsset();
        boardData.Pieces[9].ReleaseAsset();
        boardData.Pieces[10].ReleaseAsset();
        boardData.Pieces[11].ReleaseAsset();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
