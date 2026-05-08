using UnityEngine;
using UnityEngine.UIElements;

public class PuzzlePassword : MonoBehaviour
{
    [SerializeField] private GameObject puzzleObj, puzzleIg;
    private bool isOpen = false;
    private Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPuzzle()
    { 
        if (!isOpen)
        {
            Debug.Log("Puzzle opened");
            puzzleObj.SetActive(false);
            puzzleIg.SetActive(true);
            isOpen = true;
        }
    }




}
