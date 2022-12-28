using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] Sprite[] piece_sprites;

    public enum TypeOfPiece
    {
        bishop,
        king,
        knight,
        pawn,
        queen,
        rook
    }

    [Range(0, 7)]
    [SerializeField] private int x;
    [Range(0, 7)]
    [SerializeField] private int y;

    [SerializeField] private bool isWhite;

    [SerializeField] private TypeOfPiece typeOfPiece;


    private BoardManager boardManager;
    private Transform _transform;


    // Start is called before the first frame update
    void Start()
    {
        //get the board manager
        boardManager = GameObject.Find("BoardManager").GetComponent<BoardManager>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //show the piece on the board
        _transform.position = boardManager.FromCoordinatesToPosition(x, y);
    }

    //onvalidate is called when the inspector is updated
    private void OnValidate()
    {
        //set the sprite of the piece
        if (isWhite)
        {
            GetComponent<SpriteRenderer>().sprite = piece_sprites[(int)typeOfPiece];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = piece_sprites[(int)typeOfPiece + 6];
        }
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetType(TypeOfPiece typeOfPiece)
    {
        this.typeOfPiece = typeOfPiece;
        OnValidate();
    }

    public void SetColor(bool isWhite)
    {
        this.isWhite = isWhite;
        OnValidate();
    }
}
