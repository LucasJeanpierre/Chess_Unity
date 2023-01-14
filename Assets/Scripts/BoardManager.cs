using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    [SerializeField] Color whiteColor;
    [SerializeField] Color blackColor;


    [SerializeField] Color availableMoveWhiteColor;

    [SerializeField] Color availableMoveBlackColor;

    [SerializeField] float boardSize;


    public Piece piecePrefab;

    //2d array of square
    public GameObject[,] squares;




    // Show a chess board in the middle of the screen
    void Start()
    {
        squares = new GameObject[8, 8];
        //create a line of squares (white and black) around the center of the screen
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                //create a square sprite as a child of the board

                GameObject square = GameObject.CreatePrimitive(PrimitiveType.Cube);
                square.transform.parent = transform;
                square.tag = "Square";

                //set the size of the square
                square.transform.localScale = new Vector3(boardSize / 8, boardSize / 8, 0.1f);
                square.transform.position = new Vector3(i * (boardSize / 8) - boardSize / 2, j * (boardSize / 8) - boardSize / 2, 1f);

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
                squares[i, j] = square;
            }
        }

        CreatePieces();
    }

    /**
    * Create all the pieces on the board
    */
    private void CreatePieces()
    {
        GameObject pieces = new GameObject("Pieces");


        //create all the piece on the board

        //create the white pawns
        for (int i = 0; i < 8; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Pawn " + i;
            piece.SetPosition(new Vector2(i, 1));
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.pawn);
        }

        //create the black pawns
        for (int i = 0; i < 8; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Pawn " + i;
            piece.SetPosition(new Vector2(i, 6));
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.pawn);
        }

        //create the white rooks
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Rook " + i;
            piece.SetPosition(new Vector2(i * 7, 0));
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.rook);
        }

        //create the black rooks
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Rook " + i;
            piece.SetPosition(new Vector2(i * 7, 7));
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.rook);
        }

        //create the white knights
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Knight " + i;
            piece.SetPosition(new Vector2(i * 5 + 1, 0));
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.knight);
        }

        //create the black knights
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Knight " + i;
            piece.SetPosition(new Vector2(i * 5 + 1, 7));
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.knight);
        }

        //create the white bishops
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "White Bishop " + i;
            piece.SetPosition(new Vector2(i * 3 + 2, 0));
            piece.SetColor(true);
            piece.SetType(Piece.TypeOfPiece.bishop);
        }

        //create the black bishops
        for (int i = 0; i < 2; i++)
        {
            Piece piece = Instantiate(piecePrefab, pieces.transform);
            piece.name = "Black Bishop " + i;
            piece.SetPosition(new Vector2(i * 3 + 2, 7));
            piece.SetColor(false);
            piece.SetType(Piece.TypeOfPiece.bishop);
        }

        //create the white queen
        Piece whiteQueen = Instantiate(piecePrefab, pieces.transform);
        whiteQueen.name = "White Queen";
        whiteQueen.SetPosition(new Vector2(3, 0));
        whiteQueen.SetColor(true);
        whiteQueen.SetType(Piece.TypeOfPiece.queen);

        //create the black queen
        Piece blackQueen = Instantiate(piecePrefab, pieces.transform);
        blackQueen.name = "Black Queen";
        blackQueen.SetPosition(new Vector2(3, 7));
        blackQueen.SetColor(false);
        blackQueen.SetType(Piece.TypeOfPiece.queen);

        //create the white king
        Piece whiteKing = Instantiate(piecePrefab, pieces.transform);
        whiteKing.name = "White King";
        whiteKing.SetPosition(new Vector2(4, 0));
        whiteKing.SetColor(true);
        whiteKing.SetType(Piece.TypeOfPiece.king);

        //create the black king
        Piece blackKing = Instantiate(piecePrefab, pieces.transform);
        blackKing.name = "Black King";
        blackKing.SetPosition(new Vector2(4, 7));
        blackKing.SetColor(false);
        blackKing.SetType(Piece.TypeOfPiece.king);
    }

    /**
    * Get the square at the given position
    * @param x the x coordinate of the square
    * @param y the y coordinate of the square
    * @return the square at the given position
    */
    public Vector3 FromCoordinatesToPosition(int x, int y)
    {
        return new Vector3(x * (boardSize / 8) - boardSize / 2, y * (boardSize / 8) - boardSize / 2, 0.5f);
    }

    public Vector2 FromPositionToCoordinates(Vector3 position)
    {
        //get the position of the mouse in the world
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2((worldPoint.x + boardSize / 2) / (boardSize / 8), (worldPoint.y + boardSize / 2) / (boardSize / 8));

    }

    public Vector2 FromSquarePositionToCoordinates(Vector3 position)
    {
        return new Vector2((position.x + boardSize / 2) / (boardSize / 8), (position.y + boardSize / 2) / (boardSize / 8));
    }

    public GameObject GetSquareUnderTheMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();
        Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (hit.collider != null)
        {
            //if the mouse is over a square
            if (hit.collider.gameObject.tag.Equals("Square"))
                return hit.collider.gameObject;
        }
        return null;
    }

    public void updateSquaresColor()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 1)
                {
                    this.squares[i, j].GetComponent<Renderer>().material.color = whiteColor;
                    this.squares[i, j].GetComponent<Renderer>().material.SetColor("_EmissionColor", whiteColor);
                }
                else
                {
                    this.squares[i, j].GetComponent<Renderer>().material.color = blackColor;
                    this.squares[i, j].GetComponent<Renderer>().material.SetColor("_EmissionColor", blackColor);
                }
            }
        }
    }

    public void ShowPossibleMoves(List<Vector2> possibleMoves)
    {

        //show the possible moves
        foreach (Vector2 move in possibleMoves)
        {
            if (((int)move.x + (int)move.y) % 2 == 1)
            {
                this.squares[(int)move.x, (int)move.y].GetComponent<Renderer>().material.color = availableMoveWhiteColor;
                this.squares[(int)move.x, (int)move.y].GetComponent<Renderer>().material.SetColor("_EmissionColor", availableMoveWhiteColor);
            }
            else
            {
                this.squares[(int)move.x, (int)move.y].GetComponent<Renderer>().material.color = availableMoveBlackColor;
                this.squares[(int)move.x, (int)move.y].GetComponent<Renderer>().material.SetColor("_EmissionColor", availableMoveBlackColor);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //update the squares color
        //updateSquaresColor();

        //get the square under the mouse
        // GameObject square = GetSquareUnderTheMouse();    
        // if (square != null)
        // {
        //     square.GetComponent<Renderer>().material.color = Color.red;
        //     square.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        // }
    }
}
