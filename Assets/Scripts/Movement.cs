using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody Rb;
    public Transform camtrans;
    private float distance = 10f;
    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Forward(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (Physics.Raycast(camtrans.position, camtrans.forward, out RaycastHit raycasthit, distance))
        {
            if (raycasthit.collider.gameObject.CompareTag("Door"))
            { 
                raycasthit.collider.gameObject.GetComponent<Door>().OpenDoor();
            }
                Debug.Log("Wall!!");
            return;
        }

        else 
        { 
            if (canMove)
                StartCoroutine(Forwards());
        }
       
    }
    public void ForwardB()
    {

        if (Physics.Raycast(camtrans.position, camtrans.forward, out RaycastHit raycasthit, distance))
        {
            if (raycasthit.collider.gameObject.CompareTag("Door"))
            { 
                raycasthit.collider.gameObject.GetComponent<Door>().OpenDoor();
            }
                Debug.Log("Wall!!");
            return;
        }

        else 
        { 
            if (canMove)
            StartCoroutine(Forwards());
            Debug.Log("Moving Forward");

            
        }

    }

    private IEnumerator Forwards()
    {
        Vector3 startPos = Rb.transform.position;
        Vector3 finalPos = Rb.transform.position + transform.forward * distance;
        canMove = false;
        for (float t = 0; t < 1; t += 1 * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, finalPos, t);
            yield return null;
        }
        canMove = true;
    }

    public void Right(InputAction.CallbackContext ctx)
    { 
        if (!ctx.performed) return;
        if (canMove)
        StartCoroutine(Rights());
    }
    public void RightB()
    { 
            if (canMove)
            StartCoroutine(Rights());
    }
    private IEnumerator Rights()
    {
        Quaternion startRot = Rb.rotation;
        Quaternion finalRot = Quaternion.Euler(0, 90, 0) * Rb.rotation;
        canMove = false;
        for (float t = 0; t < 1; t += 1 * Time.deltaTime)
        {
            Rb.rotation = Quaternion.Lerp(startRot, finalRot, t);
            yield return null;
        }
        canMove = true;
    }
    public void Left(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        if (canMove)
            StartCoroutine(Lefts());
    }
    public void LeftB()
    {
        if (canMove)
            StartCoroutine(Lefts());
    }

    private IEnumerator Lefts()
    {
        Quaternion startRot = Rb.rotation;
        Quaternion finalRot = Quaternion.Euler(0, -90, 0) * Rb.rotation;
        canMove = false;
        for (float t = 0; t < 1; t += 1 * Time.deltaTime)
        {
            Rb.rotation = Quaternion.Lerp(startRot, finalRot, t);
            yield return null;
        }
        canMove = true;
    }
}
