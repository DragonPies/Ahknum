using UnityEngine;
using UnityEngine.UI;

public class PuzzlePasswordUI : MonoBehaviour
{
    [SerializeField]private Button up, down;
    [SerializeField]private TMPro.TMP_Text text;
    [HideInInspector]public int currentNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    public void Up()
    {
            currentNumber++;
        if (currentNumber > 9)
        {
            currentNumber = 0;
            text.text = currentNumber.ToString();
        }
        else
        {
            text.text = currentNumber.ToString();
        }
    }
    public void Down()
    {
            currentNumber--;
        
        if (currentNumber < 0)
        {
            currentNumber = 9;
            text.text = currentNumber.ToString();
        }
        else
        {
            text.text = currentNumber.ToString();
        }
    }
}
