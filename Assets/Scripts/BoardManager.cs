using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    [SerializeField] Color whiteColor;
    [SerializeField] Color blackColor;

    [SerializeField] float boardSize;

    public Piece piecePrefab;

    
    // Show a chess board in the middle of the screen
    void Start()
    {
        //create a line of squares (white and black) around the center of the screen
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                //create a square sprite as a child of the board

                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
                square.transform.parent = transform;

                //set the size of the square
                square.transform.localScale = new Vector3(boardSize/8, boardSize/8, 0.1f);
                square.transform.position = new Vector3(i * (boardSize/8) - boardSize/2, j * (boardSize/8) - boardSize/2, 1f);

                square.transform.Rotate(0, 0, 90);

                //set the color of the square
                if ((i + j) % 2 == 1)
                {
                    square.GetComponent<Renderer>().material.color = whiteColor;
                    square.GetComponent<Renderer>().material.SetColor("_EmissionColor", whiteColor);
                }
                else
                {
                    square.GetComponent<Renderer>().material.color = blackColor;
                    square.GetComponent<Renderer>().material.SetColor("_EmissionColor", blackColor);
                }
            }
        }

        GameObject pieces = new GameObject("Pieces");


        //create all the piece on the board
        
        //create the white pawns
        for (int i = 0; i < 8; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Pawn " + i;
            piece.SetPosition(i, 1);
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.pawn);
        }

        //create the black pawns
        for (int i = 0; i < 8; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Pawn " + i;
            piece.SetPosition(i, 6);
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.pawn);
        }

        //create the white rooks
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Rook " + i;
            piece.SetPosition(i * 7, 0);
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.rook);
        }

        //create the black rooks
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Rook " + i;
            piece.SetPosition(i * 7, 7);
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.rook);
        }

        //create the white knights
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Knight " + i;
            piece.SetPosition(i * 5 + 1, 0);
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.knight);
        }

        //create the black knights
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Knight " + i;
            piece.SetPosition(i * 5 + 1, 7);
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.knight);
        }

        //create the white bishops
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Bishop " + i;
            piece.SetPosition(i * 3 + 2, 0);
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.bishop);
        }

        //create the black bishops
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Bishop " + i;
            piece.SetPosition(i * 3 + 2, 7);
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.bishop);
        }

        //create the white queen
        Piece whiteQueen = Instantiate(piecePrefab, pieces.transform);
        whiteQueen.name = "White Queen";
        whiteQueen.SetPosition(3, 0);
        whiteQueen.SetColor(true);
        whiteQueen.SetType(Piece.TypeOfPiece.queen);

        //create the black queen
        Piece blackQueen = Instantiate(piecePrefab, pieces.transform);
        blackQueen.name = "Black Queen";
        blackQueen.SetPosition(3, 7);
        blackQueen.SetColor(false);
        blackQueen.SetType(Piece.TypeOfPiece.queen);

        //create the white king
        Piece whiteKing = Instantiate(piecePrefab, pieces.transform);
        whiteKing.name = "White King";
        whiteKing.SetPosition(4, 0);
        whiteKing.SetColor(true);
        whiteKing.SetType(Piece.TypeOfPiece.king);

        //create the black king
        Piece blackKing = Instantiate(piecePrefab, pieces.transform);
        blackKing.name = "Black King";
        blackKing.SetPosition(4, 7);
        blackKing.SetColor(false);
        blackKing.SetType(Piece.TypeOfPiece.king);




    }

    public Vector3 FromCoordinatesToPosition(int x, int y)
    {
        return new Vector3(x * (boardSize / 8) - boardSize / 2, y * (boardSize / 8) - boardSize / 2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
