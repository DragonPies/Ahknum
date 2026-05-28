using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemGrab : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject endscreen, button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in items)
            {
                if (item == button)
                {
                endscreen.SetActive(true);
                }
            }
    }

    public void Grob(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            return;
       // Debug.Log("Grabbed");
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.gameObject.CompareTag("Grabbable"))
            {
                items.Add(raycastHit.collider.gameObject);
                raycastHit.collider.gameObject.SetActive(false);
            }

        }
    }
}
