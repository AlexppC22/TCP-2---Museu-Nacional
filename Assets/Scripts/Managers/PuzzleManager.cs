using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PuzzleState
{
    none,
    memory,
    stele,
    pyramid,
    statue
    
}
public class PuzzleManager : MonoBehaviour
{
    public GameObject[] pyramid;
    public static PuzzleManager instance;
    PuzzleState state = PuzzleState.none;
    public int pyramidState;
    public bool pyramidIsCompleted = false;
    
    private void Awake() 
    {
        instance = this;
    }
    void Update()
    {
        switch(state)
        {
            case PuzzleState.none:
                break;
            case PuzzleState.memory:
                break;
            case PuzzleState.stele:
                break;
            case PuzzleState.pyramid:
                break;
            case PuzzleState.statue:
                break;
        }
    }
    public void SetState(int state)
    {
        switch((PuzzleState)state)
        {
            case PuzzleState.none:
                Player.instance.SetState(PlayerState.moving);
                break;
            case PuzzleState.memory:
                Player.instance.SetState(PlayerState.inPuzzle);
                MemoryPuzzle.instance.memoryConfirmCanvas.SetActive(false);
                MemoryPuzzle.instance.memoryPuzzleCanvas.SetActive(true);
                break;
            case PuzzleState.stele:
                Player.instance.SetState(PlayerState.inPuzzle);
                StelePuzzle.instance.steleConfirmCanvas.SetActive(false);
                StelePuzzle.instance.steleInventoryCanvas.SetActive(true);
                StelePuzzle.instance.stelePuzzleCanvas.SetActive(true);
                break;
            case PuzzleState.pyramid:
                Player.instance.SetState(PlayerState.inPuzzle);
                PyramidPuzzle.instance.pyramidConfirmCanvas.SetActive(false); 
                PyramidPuzzle.instance.pyramidCollider.enabled = false;                 
                break;
            case PuzzleState.statue:
                Player.instance.SetState(PlayerState.inPuzzle);
                StatuePuzzle.instance.statueConfirmCanvas.SetActive(false);
                StatuePuzzle.instance.statuePuzzleCanvas.SetActive(true);
                break;
        }
        this.state = (PuzzleState)state;
    }
    public void PyramidState()
    {
        switch(pyramidState)
        {
            case 0:
                //Serve pra desbugar, não apagar caso 0
                break;
            case 1:
                pyramid[0].SetActive(true);
                Debug.Log("Piramide tem uma peça");
                break;
            case 2:
                pyramid[1].SetActive(true);
                Debug.Log("Piramide tem 2 peças");
                break;
            case 3:
                pyramid[2].SetActive(true);
                Debug.Log("Piramide tem todas as peças");
                pyramidIsCompleted = true;
                break;
            default:
                break;
        }
    }
}
