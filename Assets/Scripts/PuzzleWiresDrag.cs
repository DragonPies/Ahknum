using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.WSA;

public class PuzzleWiresDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private GameObject self;
    private bool hovered = false;
    private RectTransform canvas;



    //public static 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        self = gameObject;
        //canvas = GameObject.Find("Puzzle-Wires").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //self.transform.position = Mouse.current.position.ReadValue();
    }

    public void WireGrab()
    {
        if (hovered)
        {
            RectTransform rt = transform as RectTransform;
            var clone = Instantiate(self, rt.position, transform.rotation, rt.parent.parent as RectTransform);
            //clone.GetComponent<RectTransform>().
            Debug.Log("Wire Grabbed");
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
        Debug.Log("Hovering");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        Debug.Log("Not Hovering");

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        WireGrab();
    }


}
