using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlideMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private bool _hovered = false;
    public PuzzleSlideGrid PSG;
    public enum Positions
    {
        first,
        second,
        third,
        fourth,
        fifth,
        sixth,
        seventh,
        eighth,
        ninth
    }
    public Positions position;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_hovered)
        {
            if (PSG.selectedPiece.Count == 0)
            {             
                PSG.selectedPiece.Add(gameObject);
            }
            
                else if (PSG.selectedPiece.Count == 1 && PSG.selectedPiece[0] != gameObject)
                {
                    Vector2 temp = PSG.selectedPiece[0].transform.localPosition;
                    Vector2 temp2 = PSG.selectedPiece[1].transform.localPosition;
                    PSG.selectedPiece.Add(gameObject);
                    PSG.selectedPiece[0].transform.localPosition = temp2;
                    PSG.selectedPiece[1].transform.localPosition = temp;
                PSG.selectedPiece.Clear();
                }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _hovered = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (position == Positions.first)
        {
            PSG.n1 = transform.localPosition;
        }

        if (position == Positions.second)
        {
            PSG.n2 = transform.localPosition;
        }

        if (position == Positions.third)
        {
            PSG.n3 = transform.localPosition;
        }   

        if (position == Positions.fourth)
        {
            PSG.n4 = transform.localPosition;
        }

        if (position == Positions.fifth)
        {
            PSG.n5 = transform.localPosition;
        }

        if (position == Positions.sixth)
        {
            PSG.n6 = transform.localPosition;
        }

        if (position == Positions.seventh)
        {
            PSG.n7 = transform.localPosition;
        }

        if (position == Positions.eighth)
        {
            PSG.n8 = transform.localPosition;
        }

        if (position == Positions.ninth)
        {
                PSG.n9 = transform.localPosition;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
