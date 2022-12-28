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

    [SerializeField] Vector2 position;
    [SerializeField] private bool isWhite;

    [SerializeField] private TypeOfPiece typeOfPiece;


    private BoardManager boardManager;
    private Transform _transform;

    private bool isGrabbed = false;


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

        if (isGrabbed)
        {
            GrabPiece();
        }
        else
        {
            //show the piece on the board
            _transform.position = boardManager.FromCoordinatesToPosition((int)position.x, (int)position.y);
        }

    }

    private void OnMouseDown()
    {
        //grab the piece
        isGrabbed = true;
    }

    private void OnMouseUp()
    {
        //drop the piece
        isGrabbed = false;
        ReleasePiece();

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


    private void GrabPiece()
    {
        //grab the piece
        _transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _transform.position = new Vector3(_transform.position.x, _transform.position.y, 0.4f);
    }

    private void ReleasePiece()
    {
        //drop the piece
        this.position = boardManager.FromSquarePositionToCoordinates(boardManager.GetSquareUnderTheMouse().transform.position);
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
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
