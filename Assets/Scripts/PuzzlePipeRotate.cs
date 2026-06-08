using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePipeRotate : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private bool hovered;
    public bool isEnd;
    [System.Flags]
    public enum Directions : uint
    {
        up = 1,
        right = 2,
        down = 4,
        left = 8
    }
    public Directions direction;
    public int numberOfConnections;

    void Start()
    {
        if (!isEnd)
        {
            int rotations = Random.Range(0, 4);
            for (int i = 0; i < rotations; i++)
            {
                Rotate();
            }
        }
    }
    public void Rotate()
    {
        transform.Rotate(0, 0, -90);
        direction = (Directions)(((int)direction << 1) | ((int)direction >> 3));
        GetComponentInParent<PuzzlePipesCheck>().CheckWin();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (hovered && !isEnd)
        {
            Rotate();
        }
       
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
}
