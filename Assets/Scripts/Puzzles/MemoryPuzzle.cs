using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoryPuzzle : MonoBehaviour
{
    public static MemoryPuzzle instance; 
    public GameObject memoryPuzzleCanvas;
    public GameObject memoryConfirmCanvas;
    public GameObject memoryVictoryCanvas;
    public GameObject memoryPyramidPiece;
    //Resposaveis por guardar informações do Puzzle
    public byte variavelControle;
    public byte variavelControle2;
    public byte points;
    public Button[] puzzleCards;
    public Sprite[] buttonSprites;
    public AudioClip[] feedbacks;
    public AudioSource audioSource;

    private void Awake() 
    {
        instance = this;
    }
    private void Start() 
    {
        puzzleCards[0].GetComponent<Image>().sprite = buttonSprites[1];
        puzzleCards[1].GetComponent<Image>().sprite = buttonSprites[2];
        puzzleCards[2].GetComponent<Image>().sprite = buttonSprites[3];
        puzzleCards[3].GetComponent<Image>().sprite = buttonSprites[4];
        puzzleCards[4].GetComponent<Image>().sprite = buttonSprites[5];
        puzzleCards[5].GetComponent<Image>().sprite = buttonSprites[1];
        puzzleCards[6].GetComponent<Image>().sprite = buttonSprites[2];
        puzzleCards[7].GetComponent<Image>().sprite = buttonSprites[3];
        puzzleCards[8].GetComponent<Image>().sprite = buttonSprites[4];
        puzzleCards[9].GetComponent<Image>().sprite = buttonSprites[5];
    }
    public void StartMemoryPuzzleButton()
    {
        StartCoroutine(StartMemoryPuzzle());
    }
    public IEnumerator StartMemoryPuzzle()
    {
        if(points < 50)
            points = 0;
        yield return new WaitForSeconds(1f);
        Debug.Log("Esperei e fiz");
        for(int i = 0; i < puzzleCards.Length; i++)
        {                   
            puzzleCards[i].interactable = true;
            puzzleCards[i].GetComponent<Image>().sprite = buttonSprites[0];
        }
    }
    void Update()
    {
        PuzzleCheck();
    }
    void PuzzleCheck()
    {
        //Acertou - Feedback Positivo, texto e sonoro
        if (variavelControle == variavelControle2 && variavelControle > 0 && variavelControle2 > 0)
        {
            //Troca o texto do Feedback pra ser algo positivo
            //Toca som de feedback positivo
            variavelControle = 0;
            variavelControle2 = 0;
            points += 10;
            AudioManager.instance.PlaySound(1);
        }
        //Errou - Feedback Negativo, texto e sonoro
        if (variavelControle != variavelControle2 && variavelControle > 0 && variavelControle2 > 0)
        {
            //Troca o texto do Feedback pra ser algo negativo
            //Toca som de feedback negativo
            variavelControle = 0;
            variavelControle2 = 0;
            AudioManager.instance.PlaySound(2);
        }
        //Ativa a vitoria, Feedback de vitorio adicionado no call de "VitoriaPuzzle"
        if (points == 50)
        {
            //Criar o canvas de vitoria para ativar lá
            VitoriaPuzzle();
        }
    }
        
    public void voltarParaOMenu()
    {
        memoryPuzzleCanvas.SetActive(false);
        for(int i = 0; i < puzzleCards.Length; i++)               
            puzzleCards[i].interactable = false;

        puzzleCards[0].GetComponent<Image>().sprite = buttonSprites[1];
        puzzleCards[1].GetComponent<Image>().sprite = buttonSprites[2];
        puzzleCards[2].GetComponent<Image>().sprite = buttonSprites[3];
        puzzleCards[3].GetComponent<Image>().sprite = buttonSprites[4];
        puzzleCards[4].GetComponent<Image>().sprite = buttonSprites[5];
        puzzleCards[5].GetComponent<Image>().sprite = buttonSprites[1];
        puzzleCards[6].GetComponent<Image>().sprite = buttonSprites[2];
        puzzleCards[7].GetComponent<Image>().sprite = buttonSprites[3];
        puzzleCards[8].GetComponent<Image>().sprite = buttonSprites[4];
        puzzleCards[9].GetComponent<Image>().sprite = buttonSprites[5];      
    }
    void VitoriaPuzzle()
    {
        memoryPuzzleCanvas.SetActive(false);
        memoryVictoryCanvas.SetActive(true);
        points ++;
        memoryPyramidPiece.SetActive(true);
        AudioManager.instance.PlaySound(1);
        // PuzzleManager.instance.PyramidState();
        // PuzzleManager.instance.pyramidState++;
        
    }
    public void b1()
    {
        if (variavelControle == 0)
            variavelControle = 1;
        else if (variavelControle2 == 0)
            variavelControle2 = 1;
        AudioManager.instance.PlaySound(0); 
    }

    public void b2()
    {
        if (variavelControle == 0)
            variavelControle = 2;
        else if (variavelControle2 == 0)
            variavelControle2 = 2;
        AudioManager.instance.PlaySound(0);
    }
    public void b3()
    {
        if (variavelControle == 0)
            variavelControle = 3;
        else if (variavelControle2 == 0)
            variavelControle2 = 3;
        AudioManager.instance.PlaySound(0);
    }

    public void b4()
    {
        if (variavelControle == 0)
            variavelControle = 4;
        else if (variavelControle2 == 0)
            variavelControle2 = 4;
        AudioManager.instance.PlaySound(0);
    }
    public void b5()
    {
        if (variavelControle == 0)
            variavelControle = 5;
        else if (variavelControle2 == 0)
            variavelControle2 = 5;
        AudioManager.instance.PlaySound(0);
    }
}