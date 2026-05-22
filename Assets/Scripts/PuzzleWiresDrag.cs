using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.WSA;

public class PuzzleWiresDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private GameObject clonee;
    private bool hovered = false;
    private RectTransform canvas;

    //
    // private UILineRenderer lR;

    //public static 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    lR = GetComponent<UILineRenderer>();
    //    //canvas = GameObject.Find("Puzzle-Wires").transform;

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //        lR.points[1] = Input.mousePosition;

    //}
    public void WireGrab()
    {
        if (hovered && transform.parent.parent.GetComponent<PuzzleWires>().isSelectedList.Count < 1)
        {
            RectTransform rt = transform as RectTransform;
            transform.GetComponentInChildren<UILineRenderer>().isSelectedd = true;
            transform.parent.parent.GetComponent<PuzzleWires>().PWD = this;
            transform.parent.parent.GetComponent<PuzzleWires>().isSelectedList.Add(transform.GetComponentInChildren<UILineRenderer>().isSelectedd);


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

        if (transform.GetComponentInChildren<UILineRenderer>().isSelectedd)
        {
            Debug.Log("Attempting to Place Wire");
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out RaycastHit raycastHit))
            {
                if (transform.parent.parent.GetComponent<PuzzleWires>().PWD.GetComponent<Image>().color == raycastHit.collider.gameObject.GetComponent<Image>().color)
                {
                    Debug.Log("Wire Placed");
                    transform.parent.parent.GetComponent<PuzzleWires>().PWD.GetComponent<UILineRenderer>().points[1] = raycastHit.collider.gameObject.GetComponent<RectTransform>().position;
                }
            }
        }
        WireGrab();
    }


}
