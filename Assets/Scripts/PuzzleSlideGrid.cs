using AYellowpaper.SerializedCollections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlideGrid : MonoBehaviour
{
    public SerializedDictionary<PuzzleSlideMove.Positions, Vector2> positionMap;
    public List<GameObject> selectedPiece = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
