using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Piece))]
public class PieceMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public List<Vector2> GetPawnPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        if (piece.IsWhite())
        {
            if (piece.GetPosition().y == 1)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 2));
            }
            possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 1));
        }
        else
        {
            if (piece.GetPosition().y == 6)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 2));
            }
            possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 1));
        }
        return possibleMoves;
    }

    public List<Vector2> GetStraightPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        for (int i = 0; i < 8; i++)
        {
            if (piece.GetPosition().x != i)
            {
                possibleMoves.Add(new Vector2(i, piece.GetPosition().y));
            }
            if (piece.GetPosition().y != i)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x, i));
            } 
        }
        return possibleMoves;
    }

    public List<Vector2> GetDiagonalPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        //top left direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x - i >= 0 && piece.GetPosition().y + i < 8)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y + i));
            }
        }

        //top right direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x + i < 8 && piece.GetPosition().y + i < 8)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + i));
            }
        }

        //bottom left direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x - i >= 0 && piece.GetPosition().y - i >= 0)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y - i));
            }
        }

        //bottom right direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x + i < 8 && piece.GetPosition().y - i >= 0)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - i));
            }
        }
        return possibleMoves;
    }

    public List<Vector2> GetKingPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        if (piece.GetPosition().x + 1 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y));
            if (piece.GetPosition().y + 1 < 8)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 1));
            }
            if (piece.GetPosition().y - 1 >= 0)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 1));
            }
        }

        if (piece.GetPosition().x - 1 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y));
            if (piece.GetPosition().y + 1 < 8)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 1));
            }
            if (piece.GetPosition().y - 1 >= 0)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 1));
            }
        }

        if (piece.GetPosition().y + 1 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 1));
        }

        if (piece.GetPosition().y - 1 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 1));
        }
        return possibleMoves;
    }

    public List<Vector2> GetKnightPossibleMoves(Piece piece) {
        List<Vector2> possibleMoves = new List<Vector2>();
        if (piece.GetPosition().x + 1 < 8 && piece.GetPosition().y + 2 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 2));
        }
        if (piece.GetPosition().x + 2 < 8 && piece.GetPosition().y + 1 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y + 1));
        }
        if (piece.GetPosition().x + 2 < 8 && piece.GetPosition().y - 1 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y - 1));
        }
        if (piece.GetPosition().x + 1 < 8 && piece.GetPosition().y - 2 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 2));
        }
        if (piece.GetPosition().x - 1 >= 0 && piece.GetPosition().y - 2 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 2));
        }
        if (piece.GetPosition().x - 2 >= 0 && piece.GetPosition().y - 1 >= 0)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y - 1));
        }
        if (piece.GetPosition().x - 2 >= 0 && piece.GetPosition().y + 1 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y + 1));
        }
        if (piece.GetPosition().x - 1 >= 0 && piece.GetPosition().y + 2 < 8)
        {
            possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 2));
        }
        return possibleMoves;
    }

    public List<Vector2> GetPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();

        switch (piece.GetTypeOfPiece())
        {
            case Piece.TypeOfPiece.pawn:
                possibleMoves = GetPawnPossibleMoves(piece);
                break;
            case Piece.TypeOfPiece.king:
                possibleMoves = GetKingPossibleMoves(piece);
                break;
            case Piece.TypeOfPiece.queen:
                possibleMoves = GetStraightPossibleMoves(piece);
                possibleMoves.AddRange(GetDiagonalPossibleMoves(piece));
                break;
            case Piece.TypeOfPiece.rook:
                possibleMoves = GetStraightPossibleMoves(piece);
                break;
            case Piece.TypeOfPiece.bishop:
                possibleMoves = GetDiagonalPossibleMoves(piece);
                break;
            case Piece.TypeOfPiece.knight:
                possibleMoves = GetKnightPossibleMoves(piece);
                break;
            default:
                break;
        }

        return possibleMoves;

    }
}
