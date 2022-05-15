using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;
    public GameObject dialogueFeedbackText;
    public GameObject puzzleFeedbackText;
    public GameObject collectibleFeedbackText;
    private bool dialogueIsActive;
    private GameObject target;
    [SerializeField, Tooltip("Responsavel pela distancia de interação")] int dist;
    public GameObject winGameCanvas;
    public GameObject door;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        TextActivators();
        Collection();
        if (PyramidPuzzle.instance.pyramidPuzzleDone)
        {
            WinGame();
        }
    }
    public void WinGame()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        door.SetActive(true);
        if (Physics.Raycast(ray, out hit, dist) && hit.transform.gameObject.tag == "Finish")
            puzzleFeedbackText.SetActive(true);
        else
            puzzleFeedbackText.SetActive(false);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.gameObject.tag == "Finish")
            {
                winGameCanvas.SetActive(true);
                Player.instance.SetState(PlayerState.inDialogue);
                dialogueIsActive = true;
            }
        }

    }
    public void Collection()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, dist) && hit.transform.gameObject.tag == "Collectible")
            collectibleFeedbackText.SetActive(true);
        else
            collectibleFeedbackText.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(hit.transform.gameObject.tag == "Collectible")
            {
                target = hit.transform.gameObject;
                target.SetActive(false);
                PuzzleManager.instance.PyramidState();
                PuzzleManager.instance.pyramidState++;
            }
            else
            {
                Debug.Log("Nada pra pegar");
            }
        }
    }
    
    public void TextActivators()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //--> Texto de interação que aparece pra saber se é interagivel, futuramente talvez mudarmos as tags ou adicionar mais
        if(Physics.Raycast(ray, out hit, dist) && hit.transform.gameObject.tag == "Dialogue" && !dialogueIsActive)
            dialogueFeedbackText.SetActive(true);
        else
            dialogueFeedbackText.SetActive(false);
        
        if(Physics.Raycast(ray, out hit, dist) && hit.transform.gameObject.tag == "PuzzleActivator" && !dialogueIsActive)
            puzzleFeedbackText.SetActive(true);
        else
            puzzleFeedbackText.SetActive(false);
        

        
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(Physics.Raycast(ray, out hit, dist) && Cursor.lockState == CursorLockMode.Locked)
            { 
                if(hit.transform.gameObject.tag == "Dialogue")
                {
                    target = hit.transform.gameObject;
                    target.GetComponentInChildren<Canvas>().enabled = true;
                    Player.instance.SetState(PlayerState.inDialogue);
                    dialogueIsActive = true;
                }
                else if(hit.transform.gameObject.tag == "PuzzleActivator")
                {
                    target = hit.transform.gameObject;
                    target.GetComponentInChildren<PuzzleActivator>().IniciarPuzzle(target.GetComponentInChildren<PuzzleActivator>().puzzleNumber);
                    Player.instance.SetState(PlayerState.inDialogue);
                    dialogueIsActive = true;
                }
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            ReturnToGame();
        }
    }
    public void ReturnToGame()
    {
        if(target != null && dialogueIsActive && target.tag == "Dialogue")
            target.GetComponentInChildren<Canvas>().enabled = false;
        if(target != null && dialogueIsActive && target.tag == "PuzzleActivator")
            target.GetComponentInChildren<PuzzleActivator>().IniciarPuzzle(3);
        Player.instance.SetState(PlayerState.moving);
        dialogueIsActive = false;
    }
    #region Cursor Control
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}
