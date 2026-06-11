using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlideMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public static Positions emptyPosition = Positions.ninth;

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
            if ((int)position + 1 == (int)emptyPosition && (position != Positions.third && position != Positions.sixth) ||
                ((int)position - 1 == (int)emptyPosition && (position != Positions.fourth && position != Positions.seventh)) ||
                (int)position + 3 == (int)emptyPosition ||
                (int)position - 3 == (int)emptyPosition)
            {
                (emptyPosition, position) = (position, emptyPosition);

                GetComponent<RectTransform>().anchoredPosition = PSG.positionMap[position];
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
        PSG.positionMap[position] = GetComponent<RectTransform>().anchoredPosition;

        if (position == emptyPosition)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
