using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidPuzzle : MonoBehaviour
{
    public static PyramidPuzzle instance;
    private int[] objectPos, puzzleAwnser;
    public Collider pyramidCollider;
    public GameObject pyramidConfirmCanvas;
    public GameObject pyramidVictoryCanvas;
    public GameObject pyramidImcompleteCanvas;

    public bool pyramidPuzzleDone = false;

    private void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        objectPos = new int[] { 1, 1, 1, 1 };
        puzzleAwnser = new int[] { 2, 3, 4 ,1};
        PyramidRotation.Rotated += CheckResults;
    }

    void CheckResults(string activeObject, int face)
    {
       
        Debug.Log("Cubo ativo =" + activeObject);
        Debug.Log("Face = " + face );
        switch (activeObject)
        {
            case "Pyramid_Base":
                objectPos[3] = face;
               
                break;

            case "Pyramid_0":
                objectPos[2] = face;
              
                break;

            case "Pyramid_1":
                objectPos[1] = face;
              
                break;
            case "Pyramid_2":
                objectPos[0] = face;
              
                break;
            default:
                Debug.Log("Erro do nome da imagem ativa = " + activeObject);

                break;
        }
        if (   objectPos[0] == puzzleAwnser[0] 
            && objectPos[1] == puzzleAwnser[1]
            && objectPos[2] == puzzleAwnser[2]
            && objectPos[3] == puzzleAwnser[3])
        {
            pyramidPuzzleDone = true;
            pyramidVictoryCanvas.SetActive(true);
        }

    }

    void OnDestroy()
    {
        PyramidRotation.Rotated -= CheckResults;
    }
}