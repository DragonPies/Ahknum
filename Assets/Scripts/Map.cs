using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMap(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (isOpen)
        { 
            anim.SetTrigger("Down");
            isOpen = false;
        }

        else
        {
            anim.SetTrigger("Up");
            isOpen = true;
        }
    }
}
