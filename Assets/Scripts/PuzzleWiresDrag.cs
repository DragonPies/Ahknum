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
        if (hovered)
        {
            RectTransform rt = transform as RectTransform;
            var clone = Instantiate(gameObject, rt.position, transform.rotation, rt.parent.parent as RectTransform);
            clone.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
            clone.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
            clonee = clone;

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
