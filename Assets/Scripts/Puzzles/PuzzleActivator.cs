using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleActivator : MonoBehaviour
{
    public int puzzleNumber;

   
    public void IniciarPuzzle(int selection)
    {    
        //--> Resposavel por abrir telas de confirmação
        //--> Se completo não pode voltar
        switch(selection)
        {
            case 0:
                Player.instance.SetState(PlayerState.inDialogue);
                if(MemoryPuzzle.instance.points < 50)
                    MemoryPuzzle.instance.memoryConfirmCanvas.SetActive(true);
                else
                    MemoryPuzzle.instance.memoryVictoryCanvas.SetActive(true);
                break;

            case 1:
                Player.instance.SetState(PlayerState.inDialogue);
                if (!PuzzleManager.instance.pyramidIsCompleted)
                    PyramidPuzzle.instance.pyramidImcompleteCanvas.SetActive(true);
                else if (!PyramidPuzzle.instance.pyramidPuzzleDone)
                    PyramidPuzzle.instance.pyramidConfirmCanvas.SetActive(true);
                else
                    PyramidPuzzle.instance.pyramidVictoryCanvas.SetActive(true);
                break;
            case 2:
                Player.instance.SetState(PlayerState.inDialogue);
                if(StelePuzzle.instance.points <= 30)
                    StelePuzzle.instance.steleConfirmCanvas.SetActive(true);
                else
                    StelePuzzle.instance.stelePuzzleVictoryCanvas.SetActive(true);
                break;
            
            //--> Caso para remover todo tipo de UI relacionado aos puzzles
            //--> Passar para o PuzzleManager
            case 3:
                PuzzleManager.instance.SetState(0);  
                //--> Canvas do Puzzle da Memoria
                if(MemoryPuzzle.instance.memoryConfirmCanvas != null)
                    MemoryPuzzle.instance.memoryConfirmCanvas.SetActive(false);
                if(MemoryPuzzle.instance.memoryPuzzleCanvas != null)
                    MemoryPuzzle.instance.memoryPuzzleCanvas.SetActive(false);
                if(MemoryPuzzle.instance.memoryVictoryCanvas != null)
                    MemoryPuzzle.instance.memoryVictoryCanvas.SetActive(false);
                //--> Canvas do Puzzle da Piramide
                if(PyramidPuzzle.instance.pyramidCollider.enabled == false) 
                    PyramidPuzzle.instance.pyramidCollider.enabled = true;
                if(PyramidPuzzle.instance.pyramidConfirmCanvas != null)
                    PyramidPuzzle.instance.pyramidConfirmCanvas.SetActive(false);    
                if(PyramidPuzzle.instance.pyramidVictoryCanvas != null)
                    PyramidPuzzle.instance.pyramidVictoryCanvas.SetActive(false);
                if(PyramidPuzzle.instance.pyramidImcompleteCanvas != null)
                    PyramidPuzzle.instance.pyramidImcompleteCanvas.SetActive(false);
                //--> Canvas do Puzzle das Estelas
                StelePuzzle.instance.SelectCanvas(3);
                if(StelePuzzle.instance.steleConfirmCanvas != null)
                    StelePuzzle.instance.steleConfirmCanvas.SetActive(false); 
                if(StelePuzzle.instance.stelePuzzleCanvas != null)
                    StelePuzzle.instance.stelePuzzleCanvas.SetActive(false); 
                if(StelePuzzle.instance.steleInventoryCanvas != null)
                    StelePuzzle.instance.steleInventoryCanvas.SetActive(false); 
                if(StelePuzzle.instance.stelePuzzleVictoryCanvas != null)
                    StelePuzzle.instance.stelePuzzleVictoryCanvas.SetActive(false);
                //--> Canvas do Puzzle da Estatua
                if (StatuePuzzle.instance.statueVictoryCanvas != null)
                    StatuePuzzle.instance.statueVictoryCanvas.SetActive(false);
                if (StatuePuzzle.instance.statueConfirmCanvas != null)
                    StatuePuzzle.instance.statueConfirmCanvas.SetActive(false);
                if (StatuePuzzle.instance.statuePuzzleCanvas != null)
                    StatuePuzzle.instance.statuePuzzleCanvas.SetActive(false);
                break;
            case 4:
                if(StatuePuzzle.instance.imagesConnected >= 5)
                    StatuePuzzle.instance.statueVictoryCanvas.SetActive(true);
                else
                    StatuePuzzle.instance.statueConfirmCanvas.SetActive(true);
                break;
        }
    }
}
