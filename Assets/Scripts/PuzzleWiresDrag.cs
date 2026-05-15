using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.WSA;

public class PuzzleWiresDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    private Vector3 p1, p2;
    private bool hovered = false;
    //public static 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WireGrab()
    {
        ///if () 

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;

    }


}
