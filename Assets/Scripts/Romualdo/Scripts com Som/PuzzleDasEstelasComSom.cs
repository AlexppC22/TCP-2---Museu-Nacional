using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PuzzleDasEstelasComSom : MonoBehaviour
{
    #region Variaveis



    //canvas do Jogo da Memória
    public GameObject PuzzleUI;

//________________________________________________________________________________________________________________________________________________
    //Canvas do Menu de Botões
    public GameObject MenuBotõesUI;
//_________________________________________________________________________________________________________________________________________________
      
   //Variavel responsavel por guardar o valor que o botão vai retornar em seu primeiro click
    private byte variavelControle;

//_________________________________________________________________________________________________________________________________________________
    //Variavel responsavel por guardar o valor que o botão vai retornar em seu segundo click
    private byte variavelControle2;

//__________________________________________________________________________________________________________________________________________________
    //Variavel responsavel por armazenar a pontuação do jogo, isso vai servir para saber se ele ganhou o puzzle ou não
    private byte pontuacaojogo;
 //__________________________________________________________________________________________________________________________________________________


 //Botão de Retorno no canto da tela | para voltar para o menu antes da tela de puzzle
    public Button BotaoRetornoParaOMenu;
//___________________________________________________________________________________________________________________________________________________
    //Array que armaneza TODOS os botões do jogo da memoria| Usados nas operações com os botões
    public Button[] botao;
//____________________________________________________________________________________________________________________________________________________
    //Array que armazena TODOS os sprites usados no jogo da memoria| Usado para mudar os sprites dos botões quando os mesmos são apertados
    public Sprite[] spritesBotoes;
 //____________________________________________________________________________________________________________________________________________________
    
        
//Variaveis de Textos| São Usados para trocar o texto do botão de "Iniciar Jogo" para "Reinicar Jogo" e vice-versa
    public Text TextoBotaoOriginal, TextoBotaoReiniciar, TextoIniciar;
//Essa é a parte que eu deixei pra você, associa nessa variavel o objeto que o jogador vai ganhar quando ele ganhar o puzzle do jogo da memória
    public GameObject ParteDaPiramide;
    public AudioSource AudioHoovering, AudioScore, AudioFailure, AudioVictory;


    #endregion

    #region Código
 //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
    void Start()
    {
        //Para soltar o mouse quando o jogador entra na tela de menus
        Cursor.lockState = CursorLockMode.None;
        pontuacaojogo = 0;
        #region BlocoDeMudançaDeSprites
        //nesse bloco estão postos os sprites originais de cada peça antes do jogo iniciar, para que o jogador veja a resposta antes de realmente fazer o puzzle
        //Estão dispostas em forma de Array e cada um dos elementos vinculados ao inspector
        botao[0].GetComponent<Image>().sprite = spritesBotoes[1];
        botao[1].GetComponent<Image>().sprite = spritesBotoes[2];
        botao[2].GetComponent<Image>().sprite = spritesBotoes[3];
        botao[3].GetComponent<Image>().sprite = spritesBotoes[4];
        botao[4].GetComponent<Image>().sprite = spritesBotoes[5];
        botao[5].GetComponent<Image>().sprite = spritesBotoes[1];
        botao[6].GetComponent<Image>().sprite = spritesBotoes[2];
        botao[7].GetComponent<Image>().sprite = spritesBotoes[3];
        botao[8].GetComponent<Image>().sprite = spritesBotoes[4];
        botao[9].GetComponent<Image>().sprite = spritesBotoes[5];
        #endregion

        #region TravaDosBotões 
        //bloco responsável por travar os botões assim que o puzzle inicia, para que o jogador não possa clicar antes de realmente ter iniciado o puzzle
        botao[0].interactable = false;
        botao[1].interactable = false;
        botao[2].interactable = false;
        botao[3].interactable = false;
        botao[4].interactable = false;
        botao[5].interactable = false;
        botao[6].interactable = false;
        botao[7].interactable = false;
        botao[8].interactable = false;
        botao[9].interactable = false;
        #endregion
        //para lockar o botão caso o jogador ja tenha ganhado o puzzle
        if(pontuacaojogo >= 50)
        {
            botao[12].interactable = false;
        }
    }
 //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

    //Método chamado quando o Botão "Iniciar Jogo" é pressionado| Faz com que o Puzzle Starte
    public void iniciarjogo()
    {
       TextoBotaoOriginal.text = TextoBotaoReiniciar.text;
        pontuacaojogo = 0;

        #region MudançaDeSprite
        //Bloco Responsável pela mudança de Sprites quando o jogo inicia para o Sprite "virado"
        botao[0].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[1].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[2].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[3].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[4].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[5].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[6].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[7].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[8].GetComponent<Image>().sprite = spritesBotoes[6];
        botao[9].GetComponent<Image>().sprite = spritesBotoes[6];
        #endregion

        #region LiberarBotões

        //Bloco Responsável por liberar os botões para Clicks do jogador
        botao[0].interactable = true;
        botao[1].interactable = true;
        botao[2].interactable = true;
        botao[3].interactable = true;
        botao[4].interactable = true;
        botao[5].interactable = true;
        botao[6].interactable = true;
        botao[7].interactable = true;
        botao[8].interactable = true;
        botao[9].interactable = true;
        #endregion
    }

 //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

    void FixedUpdate()
    {





        #region ProJogadorPontuar

        //Condicional para indicar que o jogador pontuou

        if (variavelControle == variavelControle2 && variavelControle > 0 && variavelControle2 > 0)
        {
            Debug.Log("Acertoumizeravi");
            variavelControle = 0;
            variavelControle2 = 0;
            pontuacaojogo += 10;
            AudioScore.PlayOneShot(AudioScore.clip);
        }
        #endregion

        #region OJogadorErrou

        //Condicional para dizer que o jogador errou

        if (variavelControle != variavelControle2 && variavelControle > 0 && variavelControle2 > 0)
        {
          
            Debug.Log("Erou");
            variavelControle = 0;
            variavelControle2 = 0;
            AudioFailure.PlayOneShot(AudioFailure.clip);

        }
        #endregion


        //Chama o método de vitória do jogo
        if (pontuacaojogo == 50)
        {
            VitoriaPuzzle();
            AudioVictory.PlayOneShot(AudioVictory.clip);
        }


    }


 //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


    //Método que faz com que você saia do menu e volte para o jogo
    public void saidoMenu()
    {

        MenuBotõesUI.SetActive(false);
        PlaySoundWhenHoovering();
    }
 //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


    //Método que faz com que o canvas do Jogo da memória seja ativado
    public void puzzleStart()
    {
        PuzzleUI.SetActive(true);
        MenuBotõesUI.SetActive(false);
        //PlaySoundWhenHoovering();
    }
//_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
    
            
   //Método Chamado quando o jogador aperta o botão "Retornar" quando ta na tela do jogo da memória em si| faz com que volte pro menu principal antes do puzzle
    public void voltarParaOMenu()
    {
        PuzzleUI.SetActive(false);
        MenuBotõesUI.SetActive(true);
        PlaySoundWhenHoovering();

        #region ReiniciarJogo
        //Condicional que serve para saber se o puzzle tem que ser reiniciado| Usado para reiniciar o jogo da memória

        if (pontuacaojogo < 50)
        {
            TextoBotaoOriginal.text = TextoIniciar.text;
            pontuacaojogo = 0;
            botao[0].interactable = false;
            botao[1].interactable = false;
            botao[2].interactable = false;
            botao[3].interactable = false;
            botao[4].interactable = false;
            botao[5].interactable = false;
            botao[6].interactable = false;
            botao[7].interactable = false;
            botao[8].interactable = false;
            botao[9].interactable = false;
           


        #region BlocoDeMudançadeSprite
            //bloco responsavel por mudar as sprites quando o botão retornar é pressionado
            botao[0].GetComponent<Image>().sprite = spritesBotoes[1];
            botao[1].GetComponent<Image>().sprite = spritesBotoes[2];
            botao[2].GetComponent<Image>().sprite = spritesBotoes[3];
            botao[3].GetComponent<Image>().sprite = spritesBotoes[4];
            botao[4].GetComponent<Image>().sprite = spritesBotoes[5];
            botao[5].GetComponent<Image>().sprite = spritesBotoes[1];
            botao[6].GetComponent<Image>().sprite = spritesBotoes[2];
            botao[7].GetComponent<Image>().sprite = spritesBotoes[3];
            botao[8].GetComponent<Image>().sprite = spritesBotoes[4];
            botao[9].GetComponent<Image>().sprite = spritesBotoes[5];
            #endregion
        }
        else if (pontuacaojogo >= 50)
        {
            botao[10].interactable = false;
        }
        #endregion
       
    }
   //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
   
        
        
        #region MétodoDosBotões

    //Cada método desse retorna um valor especifico para a variavel de controle 1 ou dois, caso qualquer uma dessas tenha seu valor inicial "0"| Cada método desse deve ser assimilado através do inspector pelo botão a qual ele é responsavel
    //Para dar certo 
    public void b1()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
     

        if (variavelControle == 0)
        {
            variavelControle = 1;
        }
        else if (variavelControle2 == 0)
        {
            variavelControle2 = 1;
        }
        
        


    }

    public void b2()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
        if (variavelControle == 0)
        {
            variavelControle = 2;
        }
        else if (variavelControle2 == 0)
        {
            variavelControle2 = 2;
        }
    }
    public void b3()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
        if (variavelControle == 0)
        {
            variavelControle = 3;
        }
        else if (variavelControle2 == 0)
        {
            variavelControle2 = 3;
        }
    }

    public void b4()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
        if (variavelControle == 0)
        {
            variavelControle = 4;
        }
        else if (variavelControle2 == 0)
        {
            variavelControle2 = 4;
        }
    }
    public void b5()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
        if (variavelControle == 0)
        {
            variavelControle = 5;
        }
        else if (variavelControle2 == 0)
        {
            variavelControle2 = 5;
        }
    }
    #endregion

    //Método chamado quando o puzzle é ganho
    void VitoriaPuzzle()
    {
        AudioVictory.PlayOneShot(AudioVictory.clip);
        Debug.Log("Vitória");
        //Instantiate(ParteDaPiramide.gameObject);
       // PuzzleUI.SetActive(false);
       
    }

    public void PlaySoundWhenHoovering()
    {
        AudioHoovering.PlayOneShot(AudioHoovering.clip);
    }

    #endregion
}