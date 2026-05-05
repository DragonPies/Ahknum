using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Dr;
    public GameObject Key;
    public ItemGrab itemGrab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        foreach (GameObject item in itemGrab.items)
        {
            if (item == Key)
            {
                Dr.SetActive(false);
                Debug.Log("Door opened");
            }
        }
    }
}
