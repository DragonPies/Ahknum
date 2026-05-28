using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleGrab : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PuzzleGrabb(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
            return;
        Debug.Log("Grabbed");
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(cameraRay, out RaycastHit raycastHit))
        {
            Debug.Log(raycastHit.collider.gameObject.name);
            if (raycastHit.collider.gameObject.CompareTag("Puzzle"))
            {
                if (!raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().isOpen)

                {
                    raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().OpenPuzzle();
                    return;
                }

                else
                {
                    raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().ClosePuzzle();
                    return;
                }
            }

            if (raycastHit.collider.gameObject.CompareTag("Wires"))
            {
                Debug.Log("Clicked");

                if (!raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().isOpen)

                {
                    raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().OpenPuzzle();
                    return;
                }
                else
                {
                raycastHit.collider.gameObject.GetComponent<PuzzlePassword>().ClosePuzzle();
                return;
                }

            }

        }
    }

}
