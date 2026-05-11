using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePasswordUICheck : MonoBehaviour
{
    public GameObject PuzzleObj, PuzzlePasswordScreen, Key;
    public PuzzlePassword PP;
    public PuzzlePasswordUI n1,n2,n3;
    public Button CheckButton;

    public void Button()
    {
        StartCoroutine(Check());
    }
    public IEnumerator Check()
    {
        if (PP.Num1 == n1.currentNumber && PP.Num2 == n2.currentNumber && PP.Num3 == n3.currentNumber)
        { 
            CheckButton.GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(1);
            PuzzlePasswordScreen.SetActive(false);
            Key.SetActive(true);
            PuzzleObj.SetActive(true);
        }
        else
        {
            CheckButton.GetComponent<Image>().color = Color.red;
                yield return new WaitForSeconds(1);
                CheckButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void Close()
    {
        PuzzlePasswordScreen.SetActive(false);
        PuzzleObj.transform.position = PuzzleObj.GetComponent<PuzzlePassword>().pos;
        PuzzleObj.GetComponent<PuzzlePassword>().isOpen = false;
        PuzzleObj.SetActive(true);
    }
}
