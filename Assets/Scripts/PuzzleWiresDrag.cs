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
            //RectTransform rt = transform as RectTransform;
            if (transform.childCount >= 1)
            { 
            transform.GetComponentInChildren<UILineRenderer>().isSelectedd = true;
            transform.parent.parent.GetComponent<PuzzleWires>().PWD = this;
            transform.parent.parent.GetComponent<PuzzleWires>().isSelectedList.Add(transform.GetComponentInChildren<UILineRenderer>().isSelectedd);
            }


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
        //GraphicRaycaster gr = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        //PointerEventData ped = new PointerEventData(EventSystem.current);
        //ped.position = Input.mousePosition;
        //    List<RaycastResult> results = new List<RaycastResult>();
        //gr.Raycast(ped, results);
        var mainWires = transform.parent.parent.GetComponent<PuzzleWires>();

        if (mainWires.isSelectedList.Count >= 1)
        {
            Debug.Log("Attempting to Place Wire");

            if (mainWires.PWD.GetComponent<Image>().color == gameObject.GetComponent<Image>().color)
            {
                Debug.Log("Wire Placed");
                mainWires.PWD.GetComponentInChildren<UILineRenderer>().isSelectedd = false;
                mainWires.PWD.GetComponentInChildren<UILineRenderer>().SetPoint(GetComponent<RectTransform>().anchoredPosition - mainWires.PWD.GetComponent<RectTransform>().anchoredPosition);
                mainWires.isSelectedList.Clear();
                mainWires.PWD = null;
                mainWires.ConnectedWires.Add(1);
            }
        }

        WireGrab();
    }
}
