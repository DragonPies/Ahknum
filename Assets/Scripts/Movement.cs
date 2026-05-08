using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody Rb;
    public Transform camtrans;
    private float distance = 10f;

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
            Debug.Log("Moving Forward");
             Rb.transform.Translate(Vector3.forward * distance, Camera.main.transform);
        }
       
    }

    public void Right(InputAction.CallbackContext ctx)
    { 
        if (!ctx.performed) return;
        Rb.rotation = Quaternion.Euler(0, 90, 0) * Rb.rotation;
    }

    public void Left(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        Rb.rotation = Quaternion.Euler(0, -90, 0) * Rb.rotation;
    }
}
