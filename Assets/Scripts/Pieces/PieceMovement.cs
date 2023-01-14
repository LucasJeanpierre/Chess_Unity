using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Piece))]
public class PieceMovement : MonoBehaviour
{

    private BoardManager boardManager;

    // Start is called before the first frame update
    void Start()
    {
        boardManager = GameObject.Find("BoardManager").GetComponent<BoardManager>();
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
            for (int i = -1; i <= 1; i += 2)
            {
                if (piece.GetPosition().x + i >= 0 && piece.GetPosition().x + i <= 7)
                {
                    if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + 1)))
                    {
                        if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + 1)).IsWhite() == false)
                        {
                            possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + 1));
                        }
                    }
                }
            }

            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 1));
            }
            else
            {
                return possibleMoves;
            }

            if (piece.GetPosition().y == 1)
            {
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 2)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y + 2));
                }
            }

        }
        else
        {
            for (int i = -1; i <= 1; i += 2)
            {
                if (piece.GetPosition().x + i >= 0 && piece.GetPosition().x + i <= 7)
                {
                    if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - 1)))
                    {
                        if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - 1)).IsWhite() == true)
                        {
                            possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - 1));
                        }
                    }
                }
            }

            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 1));
            }
            else
            {
                return possibleMoves;
            }

            if (piece.GetPosition().y == 6)
            {
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 2)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y - 2));
                }
            }
        }
        return possibleMoves;
    }

    public List<Vector2> GetStraightPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        Vector2 _pos = new Vector2(piece.GetPosition().x, piece.GetPosition().y);

        while (_pos.x < 7)
        {
            _pos.x++;
            if (boardManager.IsAPieceOnTheSquare(_pos) == false)
            {
                possibleMoves.Add(_pos);
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(_pos).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(_pos);
                }
                break;
            }
        }

        _pos.x = piece.GetPosition().x;

        while (_pos.x > 0)
        {
            _pos.x--;
            if (boardManager.IsAPieceOnTheSquare(_pos) == false)
            {
                possibleMoves.Add(_pos);
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(_pos).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(_pos);
                }
                break;
            }
        }

        _pos.x = piece.GetPosition().x;

        while (_pos.y < 7)
        {
            _pos.y++;
            if (boardManager.IsAPieceOnTheSquare(_pos) == false)
            {
                possibleMoves.Add(_pos);
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(_pos).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(_pos);
                }
                break;
            }
        }

        _pos.y = piece.GetPosition().y;

        while (_pos.y > 0)
        {
            _pos.y--;
            if (boardManager.IsAPieceOnTheSquare(_pos) == false)
            {
                possibleMoves.Add(_pos);
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(_pos).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(_pos);
                }
                break;
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
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y + i)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y + i));
                }
                else
                {
                    if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y + i)).IsWhite() != piece.IsWhite())
                    {
                        possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y + i));
                    }
                    break;
                }
            }
        }

        //top right direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x + i < 8 && piece.GetPosition().y + i < 8)
            {
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + i)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + i));
                }
                else
                {
                    if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + i)).IsWhite() != piece.IsWhite())
                    {
                        possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + i));
                    }
                    break;
                }
            }
        }

        //bottom left direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x - i >= 0 && piece.GetPosition().y - i >= 0)
            {
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y - i)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y - i));
                }
                else
                {
                    if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y - i)).IsWhite() != piece.IsWhite())
                    {
                        possibleMoves.Add(new Vector2(piece.GetPosition().x - i, piece.GetPosition().y - i));
                    }
                    break;
                }
            }
        }

        //bottom right direction
        for (int i = 1; i < 8; i++)
        {
            if (piece.GetPosition().x + i < 8 && piece.GetPosition().y - i >= 0)
            {
                if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - i)) == false)
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - i));
                }
                else
                {
                    if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - i)).IsWhite() != piece.IsWhite())
                    {
                        possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y - i));
                    }
                    break;
                }
            }
        }

        return possibleMoves;
    }

    public List<Vector2> GetKingPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (piece.GetPosition().x + i < 8 && piece.GetPosition().y + j < 8 && piece.GetPosition().x + i >= 0 && piece.GetPosition().y + j >= 0)
                {
                    if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + j)) == false)
                    {
                        possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + j));
                    }
                    else
                    {
                        if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + j)).IsWhite() != piece.IsWhite())
                        {
                            possibleMoves.Add(new Vector2(piece.GetPosition().x + i, piece.GetPosition().y + j));
                        }
                    }
                }
            }
        }
        return possibleMoves;
    }

    public List<Vector2> GetKnightPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();
        if (piece.GetPosition().x + 1 < 8 && piece.GetPosition().y + 2 < 8)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 2)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 2));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 2)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y + 2));
                }
            }
        }

        if (piece.GetPosition().x + 1 < 8 && piece.GetPosition().y - 2 >= 0)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 2)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 2));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 2)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + 1, piece.GetPosition().y - 2));
                }
            }
        }

        if (piece.GetPosition().x - 1 >= 0 && piece.GetPosition().y + 2 < 8)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 2)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 2));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 2)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y + 2));
                }
            }
        }

        if (piece.GetPosition().x - 1 >= 0 && piece.GetPosition().y - 2 >= 0)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 2)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 2));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 2)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - 1, piece.GetPosition().y - 2));
                }
            }
        }

        if (piece.GetPosition().x + 2 < 8 && piece.GetPosition().y + 1 < 8)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y + 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y + 1));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y + 1)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y + 1));
                }
            }
        }

        if (piece.GetPosition().x + 2 < 8 && piece.GetPosition().y - 1 >= 0)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y - 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y - 1));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y - 1)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x + 2, piece.GetPosition().y - 1));
                }
            }
        }

        if (piece.GetPosition().x - 2 >= 0 && piece.GetPosition().y + 1 < 8)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y + 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y + 1));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y + 1)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y + 1));
                }
            }
        }

        if (piece.GetPosition().x - 2 >= 0 && piece.GetPosition().y - 1 >= 0)
        {
            if (boardManager.IsAPieceOnTheSquare(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y - 1)) == false)
            {
                possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y - 1));
            }
            else
            {
                if (boardManager.GetPieceOnTheSquare(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y - 1)).IsWhite() != piece.IsWhite())
                {
                    possibleMoves.Add(new Vector2(piece.GetPosition().x - 2, piece.GetPosition().y - 1));
                }
            }
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
