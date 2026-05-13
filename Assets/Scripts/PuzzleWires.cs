using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleWires : MonoBehaviour
{
    public GameObject Wire1, Wire2, Wire3, Wire4, Wire5, Wire6;
    private List<GameObject> leftWires = new List<GameObject>();
    private List<GameObject> rightWires = new List<GameObject>();
    private int redCount = 0;
    private int blueCount = 0;
    private int greenCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftWires.Add(Wire1);
        leftWires.Add(Wire2);
        leftWires.Add(Wire3);
        rightWires.Add(Wire4);
        rightWires.Add(Wire5);
        rightWires.Add(Wire6);
        ColorCalcLeft();
        ColorCalcRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColorCalcLeft()
    {
        bool running = true;
        while (running)
        {
            for (int i = 0; i < leftWires.Count; i++)
            {

                int color = Random.Range(0, 3);
                if (color == 0 && redCount < 1 && leftWires[i].GetComponent<Image>().color == Color.white)
                {
                    leftWires[i].GetComponent<Image>().color = Color.red;
                    redCount += 1;
                }

                else if (color == 0 && redCount >= 1)
                {
                    color = Random.Range(1, 3);
                }


                if (color == 1 && blueCount < 1 && leftWires[i].GetComponent<Image>().color == Color.white)
                {
                    leftWires[i].GetComponent<Image>().color = Color.blue;
                    blueCount += 1;
                }
                else if (color == 1 && blueCount >= 1)
                {
                    int coin = Random.Range(0, 2);
                    if (coin == 0)
                    {
                        color = 0;
                    }
                    else
                    {
                        color = 2;

                    }

                    if (color == 2 && greenCount < 1 && leftWires[i].GetComponent<Image>().color == Color.white)
                    {
                        leftWires[i].GetComponent<Image>().color = Color.green;
                        greenCount += 1;
                    }
                    else if (color == 2 && greenCount >= 1)
                    {
                        color = Random.Range(0, 2);
                    }

                }
            }
            if (redCount == 1 && blueCount == 1 && greenCount == 1)
            {
                running = false;
            }
        }
    }

    private void ColorCalcRight()
    {
        bool running = true;
        while (running)
        {
            for (int i = 0; i < rightWires.Count; i++)
            {

                int color = Random.Range(0, 3);
                if (color == 0 && redCount < 2 && rightWires[i].GetComponent<Image>().color == Color.white)
                {
                    rightWires[i].GetComponent<Image>().color = Color.red;
                    redCount += 1;
                }

                else if (color == 0 && redCount >= 2)
                {
                    color = Random.Range(1, 3);
                }


                if (color == 1 && blueCount < 2 && rightWires[i].GetComponent<Image>().color == Color.white)
                {
                    rightWires[i].GetComponent<Image>().color = Color.blue;
                    blueCount += 1;
                }
                else if (color == 1 && blueCount >= 2)
                {
                    int coin = Random.Range(0, 2);
                    if (coin == 0)
                    {
                        color = 0;
                    }
                    else
                    {
                        color = 2;

                    }

                    if (color == 2 && greenCount < 2 && rightWires[i].GetComponent<Image>().color == Color.white)
                    {
                        rightWires[i].GetComponent<Image>().color = Color.green;
                        greenCount += 1;
                    }
                    else if (color == 2 && greenCount >= 2)
                    {
                        color = Random.Range(0, 2);
                    }

                }
            }
            if (redCount == 2 && blueCount == 2 && greenCount == 2)
            {
                running = false;
            }
        }
    }

}
