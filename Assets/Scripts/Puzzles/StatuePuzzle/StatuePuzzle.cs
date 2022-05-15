using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{
    public static StatuePuzzle instance;
    public GameObject statuePuzzleCanvas;
    public GameObject statueConfirmCanvas;
    public GameObject statueVictoryCanvas;
    public GameObject statuePyramidPiece;
    public int imagesConnected = 0;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(imagesConnected == 5)
        {
            Victory();
        }
    }
    void Victory()
    {
        imagesConnected++;
        statuePuzzleCanvas.SetActive(false);
        statueVictoryCanvas.SetActive(true);
        statuePyramidPiece.SetActive(true);
    }
}

