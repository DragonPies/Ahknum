using UnityEngine;
using UnityEngine.UIElements;

public class PuzzlePassword : MonoBehaviour
{
    [SerializeField] private GameObject puzzleObj, puzzleIg, key;
    public int Num1, Num2, Num3;
    [HideInInspector]public bool isOpen = false;
    [HideInInspector]public Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = puzzleObj.transform.position; 
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
            puzzleObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            puzzleObj.SetActive(false);
            puzzleIg.SetActive(true);
            isOpen = true;
        }
    }

    public void ClosePuzzle()
    {
        if (isOpen)
        {
            Debug.Log("Puzzle closed");
            puzzleObj.transform.position = pos;
            puzzleObj.SetActive(true);
            puzzleIg.SetActive(false);
            isOpen = false;
        }
    }




}
