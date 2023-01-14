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

    public List<Vector2> GetPossibleMoves(Piece piece)
    {
        List<Vector2> possibleMoves = new List<Vector2>();

        switch (piece.GetTypeOfPiece())
        {
            case Piece.TypeOfPiece.pawn:
                possibleMoves = GetPawnPossibleMoves(piece);
                break;
            case Piece.TypeOfPiece.king:
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y));
                break;
            case Piece.TypeOfPiece.queen:
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y));
                break;
            case Piece.TypeOfPiece.rook:
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y));
                break;
            case Piece.TypeOfPiece.bishop:
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y));
                break;
            case Piece.TypeOfPiece.knight:
                possibleMoves.Add(new Vector2(piece.GetPosition().x, piece.GetPosition().y));
                break;
            default:
                break;
        }
  
        return possibleMoves;

    }
}
