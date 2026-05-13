using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleWires : MonoBehaviour
{
    public GameObject Wire1, Wire2, Wire3, Wire4, Wire5, Wire6;
    private List<GameObject> wires = new List<GameObject>();
    private List<GameObject> reds = new List<GameObject>();
    private List<GameObject> blues = new List<GameObject>();
    private List<GameObject> greens = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wires.Add(Wire1);
        wires.Add(Wire2);
        wires.Add(Wire3);
        wires.Add(Wire4);
        wires.Add(Wire5);
        wires.Add(Wire6);
        ColorCalc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColorCalc()
    { 
        for (int i = 0; i < wires.Count; i++)
        {
                int color = Random.Range(0, 3);
                if (color == 0 && reds.Count < 2)
                {
                    wires[i].GetComponent<Image>().color = Color.red;
                    reds.Add(wires[i]);
                }


                if (color == 1 && blues.Count < 2)
                {
                    wires[i].GetComponent<Image>().color = Color.blue;
                    blues.Add(wires[i]);
                }

                if (color == 2 && greens.Count < 2)
                {
                    wires[i].GetComponent<Image>().color = Color.green;
                    greens.Add(wires[i]);
                }

        }
    }


}
