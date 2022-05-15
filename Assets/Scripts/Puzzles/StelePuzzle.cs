using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StelePuzzle : MonoBehaviour
  

{
    public static StelePuzzle instance;
    //--> Canvas
    public GameObject steleConfirmCanvas;
    public GameObject stelePuzzleCanvas;
    public GameObject pyramidPart;
    public GameObject[] steleCanvas;
    public GameObject steleInventoryCanvas;
    public GameObject stelePuzzleVictoryCanvas;
    public Button[] inventoryButtons;
    
    #region Variaveis  

    

    //Armazena o objeto Imagem dentro do canvas de cada estela
    public GameObject[] plaqueImages;

    //Botões para fazer a primeira coleta dentro de cada Canvas do puzzle
    public GameObject BotaoDeColeta1, BotaoDeColeta2, BotaoDeColeta3;

    //Botões para posicionar as estelas dentro de cada canvas do puzzle
    public GameObject BotaoPosicionar1, BotaoPosicionar2, BotaoPosicionar3;
    
    //Botões de pegar, aparecem quando o jogador erra para que ele possa pegar de volta a estela que ele colocou errado e tentar de novo
    public GameObject BotaoPegar1, BotaoPegar2, BotaoPegar3;

    //botões no primeiro menu ao interagir com o objeto alvo do canvas
    public Button[] changeCanvasButtons;

    //Variaveis que armazenam valores pré-definidos quando clica nos botões do inventario, Serve pra controlar o acerto do jogador
    private byte VariavelControle1, VariavelControle2, VariavelControle3;

    //Constantes que serão usadas pra determinar se o jogador acertou ou não a posição das Estelas
    private byte valorPedestal1, valorPedestal2, ValorPedestal3;

    //Variavel que armazena a pontuação atual do jogador no puzzle das estelas, serve para condicionais pra saber se ele venceu, se ele acertou
    public byte points;

    //Armazena os sprites para troca deles de acordo com a colocação quando o player estiver realizando o puzzle
    public Sprite[] buttonSprites; 

    //Essa Variavel esta sendo usada pra saber qual foi o ultimo botão a qual o jogador apertou, dessa maneira vai retornar o sprite de acordo com o botão
    public byte UltimoSpriteRecebido;
    //Essa variavel ta sendo usada pra saber qual das estelas esta em qual dos pedestais, para que o jogador possa coletar elas caso ele erre com precisão
    private byte UltimaEstelaNoPedestal1, UltimaEstelaNoPedestal2, UltimaEstelaNoPedestal3;

    //Array de objetos que faz referencia aos objetos 3D das estelas na cena
    public GameObject[] EstelasNaCenaDoJogo;

    //Variavel que faz referencia a posição do objeto 3D  das estelas na cena
   private Vector3 Posicaoestela1, Posicaoestela2, Posicaoestela3;
 
    // public byte UltimoBotaoInventario1, UltimoBotaoInventario2, UltimoBotaoInventario3;
    #endregion

    private void Awake() 
    {
        instance = this;
    }   
    void Start()
    {
        //Variaveis começam com o valor simbólico de 50 porque elas estão fazendo referência aos valores de Arrays utilizados pelo "Sprite de botoes" e "Botões de Inventario"
        UltimoSpriteRecebido = 3;
        Posicaoestela1 = new Vector3(8.7f, 2.2f, 1.5f);
        Posicaoestela2 = new Vector3(8.7f, 2.2f, 0f);
        Posicaoestela3 = new Vector3(8.7f, 2.2f, -1.5f);
        //Desabilitar de inicio os botões do inventário
        inventoryButtons[0].interactable = false;
        inventoryButtons[1].interactable = false;
        inventoryButtons[2].interactable = false;

        //Variaveis começam com o valor simbólico de 50 porque elas estão fazendo referência aos valores de Arrays utilizados pelo "Sprite de botoes" e "Botões de Inventario"
        UltimaEstelaNoPedestal1 = 50;
        UltimaEstelaNoPedestal2 = 50;
        UltimaEstelaNoPedestal3 = 50;
    }
    void Update() 
    {
        //if(points == 30)
        //{
        //    VictoryUpdate();
        //    Debug.Log("GANHEI");
        //}
    }
    public void VictoryUpdate()
    {
        SelectCanvas(4);
        points ++;
        pyramidPart.SetActive(true);
        AudioManager.instance.PlaySound(1);
    }
    #region Estelas
    public void SelectCanvas(int selection)
    {
        switch(selection)
        {
            case 0:
            stelePuzzleCanvas.SetActive(false); 
            steleCanvas[0].SetActive(true);
            break;
            case 1:
            stelePuzzleCanvas.SetActive(false); 
            steleCanvas[1].SetActive(true);
            break;
            case 2:
            stelePuzzleCanvas.SetActive(false); 
            steleCanvas[2].SetActive(true);
            break;
            case 3:
            if(steleCanvas[0] != null)
                steleCanvas[0].SetActive(false);
            if(steleCanvas[1] != null)
                steleCanvas[1].SetActive(false);
            if(steleCanvas[2] != null)
                steleCanvas[2].SetActive(false);
            stelePuzzleCanvas.SetActive(true);
            break;
            case 4:
            if(steleCanvas[0] != null)
                steleCanvas[0].SetActive(false);
            if(steleCanvas[1] != null)
                steleCanvas[1].SetActive(false);
            if(steleCanvas[2] != null)
                steleCanvas[2].SetActive(false);
            if(stelePuzzleCanvas != null)
                stelePuzzleCanvas.SetActive(false);
            stelePuzzleVictoryCanvas.SetActive(true);
            break;      
        }
    }

    public void ColetarEstela1()
    {
        plaqueImages[1].GetComponent<Image>().sprite = buttonSprites[3];
        inventoryButtons[0].GetComponent<Image>().sprite = buttonSprites[0]; 
        changeCanvasButtons[1].GetComponent<Image>().sprite = buttonSprites[3];
        BotaoDeColeta2.SetActive(false);
        BotaoPosicionar2.SetActive(true);
        inventoryButtons[0].interactable = true;
        EstelasNaCenaDoJogo[0].SetActive(false);
        AudioManager.instance.PlaySound(0);
    }
    public void ColetarEstela2()
    {

        plaqueImages[2].GetComponent<Image>().sprite = buttonSprites[3];
        inventoryButtons[1].GetComponent<Image>().sprite = buttonSprites[1];
        changeCanvasButtons[2].GetComponent<Image>().sprite = buttonSprites[3];
        BotaoDeColeta3.SetActive(false);
        BotaoPosicionar3.SetActive(true);
        EstelasNaCenaDoJogo[1].SetActive(false);
        inventoryButtons[1].interactable = true;
        AudioManager.instance.PlaySound(0);

    }
    public void ColetarEstela3()
    {
        
        plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[3];
        //Coloca a imagem da Estela 3 no lugar do inventario 3
        inventoryButtons[2].GetComponent<Image>().sprite = buttonSprites[2];
        //Coloca o Sprite do Canvas principal como vazio
        changeCanvasButtons[0].GetComponent<Image>().sprite = buttonSprites[3];
        //Desativa o botão de coleta
        BotaoDeColeta1.SetActive(false);
        //Ativa o botão de posicionar
        BotaoPosicionar1.SetActive(true);
        inventoryButtons[2].interactable = true;
        EstelasNaCenaDoJogo[2].SetActive(false);
        AudioManager.instance.PlaySound(0);
    }

    #endregion

    #region Botões do Inventário

    //Métodos Chamados quando os respectivos botões do inventario são apertados, todos os botões do inventario SEMPRE irão receber uma UNICA imagem e retornar um UNICO valor
    // Dessa maneira se torna Intuitívo saber qual dos botões foi apertado e se o jogador pontuou ou não

    #region Botão 1
    public void ApertarBotao1Inventario()
    {
        VariavelControle1 = 1;
        UltimoSpriteRecebido = 1;
        AudioManager.instance.PlaySound(0);
       
    }
    #endregion

    #region Botão 2
    public void ApertarBotao2Inventario()
    {
        VariavelControle2 = 2;
        UltimoSpriteRecebido = 2;
        AudioManager.instance.PlaySound(0);
    }
    #endregion

    #region Botão 3
    public void ApertarBotao3Inventario()
    {
        VariavelControle3 = 3;
        UltimoSpriteRecebido = 3;
        AudioManager.instance.PlaySound(0);
    }
    #endregion

    #endregion

    #region Botões de Posicionar

    #region Botão Posicionar Nº1
    public void Posicionar0()
    {
        AudioManager.instance.PlaySound(0);
        
        switch(UltimoSpriteRecebido)
        {
            #region case0
            case 0:
                Debug.Log("Não tem nada ai bobo");
                break;
            #endregion
            #region case1
            case 1:
                inventoryButtons[0].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[0].interactable = false;
                plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[0];
                BotaoPosicionar1.SetActive(false);
                valorPedestal1 = 1;
                changeCanvasButtons[0].GetComponent<Image>().sprite = buttonSprites[0];
                EstelasNaCenaDoJogo[0].SetActive(true);
                EstelasNaCenaDoJogo[0].transform.position = new Vector3(8.7f, 2.2f, 1.5f);
                if (VariavelControle1 == valorPedestal1)
                {
                    pontuar();
                }
                break;
            #endregion
            #region case2
            case 2:
                inventoryButtons[1].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[1].interactable = false;
                plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[1];
                valorPedestal1 = 2;
                changeCanvasButtons[0].GetComponent<Image>().sprite = buttonSprites[1];
                EstelasNaCenaDoJogo[1].SetActive(true);
                EstelasNaCenaDoJogo[1].transform.position = new Vector3(8.7f, 2.2f, 1.5f); 
                if (VariavelControle1 != valorPedestal1)
                {
                    BotaoPosicionar1.SetActive(false);
                    BotaoPegar1.SetActive(true);
                    UltimaEstelaNoPedestal1 = 1;
                    AudioManager.instance.PlaySound(2);
                }
                UltimoSpriteRecebido = 0;
                break;
            #endregion
            #region case3
            case 3:
                inventoryButtons[2].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[2].interactable = false;
                plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[2];
                valorPedestal1 = 3;
                changeCanvasButtons[0].GetComponent<Image>().sprite = buttonSprites[2];
                EstelasNaCenaDoJogo[2].SetActive(true);
                EstelasNaCenaDoJogo[2].transform.position = new Vector3(8.7f, 2.2f, 1.5f);
                if (VariavelControle1 != valorPedestal1)
                {
                    BotaoPosicionar1.SetActive(false);
                    BotaoPegar1.SetActive(true);
                    UltimaEstelaNoPedestal1 = 2;
                    AudioManager.instance.PlaySound(2);
                }
                UltimoSpriteRecebido = 0;
                break;
            #endregion
        }
        UltimoSpriteRecebido = 3;
    }
    #endregion

    #region Botão Posicionar Nº2
    public void Posicionar1()
    {
        AudioManager.instance.PlaySound(0);
        switch(UltimoSpriteRecebido)
        {
            #region case0
            case 0:
                Debug.Log("Não tem nada ai bobo");
                break;
            #endregion
            #region case1
            case 1:
                inventoryButtons[0].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[0].interactable = false;
                plaqueImages[1].GetComponent<Image>().sprite = buttonSprites[0];
                valorPedestal2 = 1;
                changeCanvasButtons[1].GetComponent<Image>().sprite = buttonSprites[0];
                EstelasNaCenaDoJogo[0].SetActive(true);
                EstelasNaCenaDoJogo[0].transform.position = new Vector3(8.7f, 2.2f, 0f);
                if (VariavelControle2 != valorPedestal2)
                {
                    BotaoPosicionar2.SetActive(false);
                    BotaoPegar2.SetActive(true);
                    UltimaEstelaNoPedestal2 = 0;
                    AudioManager.instance.PlaySound(2);
                }
                break;
            #endregion
            #region case2
            case 2:
                inventoryButtons[1].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[1].interactable = false;
                plaqueImages[1].GetComponent<Image>().sprite = buttonSprites[1];
                valorPedestal2 = 2;
                changeCanvasButtons[1].GetComponent<Image>().sprite = buttonSprites[1];
                EstelasNaCenaDoJogo[1].SetActive(true);
                EstelasNaCenaDoJogo[1].transform.position = new Vector3(8.7f, 2.2f, 0f);
                if (VariavelControle2 == valorPedestal2)
                {
                    BotaoPosicionar2.SetActive(false);
                    pontuar();
                }
                break;
            #endregion
            #region case3
            case 3:
                inventoryButtons[2].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[2].interactable = false;
                plaqueImages[1].GetComponent<Image>().sprite = buttonSprites[2];
                ValorPedestal3 = 3;
                changeCanvasButtons[1].GetComponent<Image>().sprite = buttonSprites[2];
                EstelasNaCenaDoJogo[2].SetActive(true);
                EstelasNaCenaDoJogo[2].transform.position = new Vector3(8.7f, 2.2f, 0f);
                if (VariavelControle2 != valorPedestal2)
                {
                    BotaoPosicionar2.SetActive(false);
                    BotaoPegar2.SetActive(true);
                    UltimaEstelaNoPedestal2 = 2;
                    AudioManager.instance.PlaySound(2);
                }
                break;
                #endregion

        }
        UltimoSpriteRecebido = 3;
    }
    #endregion

    #region Botão Posicionar Nº3

        #region Erro
    public void Posicionar2()
    {
        switch(UltimoSpriteRecebido)
        {
            #region case0
            case 0:
                Debug.Log("Não tem nada ai bobo");
                break;
            #endregion
            #region case1
            case 1:
                inventoryButtons[0].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[0].interactable = false;
                plaqueImages[2].GetComponent<Image>().sprite = buttonSprites[0];
                ValorPedestal3 = 1;
                changeCanvasButtons[2].GetComponent<Image>().sprite = buttonSprites[0];
                EstelasNaCenaDoJogo[0].SetActive(true);
                EstelasNaCenaDoJogo[0].transform.position = new Vector3(8.7f, 2.2f, -1.5f);
                if (VariavelControle3 != ValorPedestal3)
                {
                    BotaoPosicionar3.SetActive(false);
                    BotaoPegar3.SetActive(true);
                    UltimaEstelaNoPedestal3 = 0;
                    AudioManager.instance.PlaySound(2);
                }
                break;
            #endregion
            #region case2
            case 2:
                inventoryButtons[1].GetComponent<Image>().sprite = buttonSprites[3];
                inventoryButtons[1].interactable = false;
                plaqueImages[2].GetComponent<Image>().sprite = buttonSprites[1];
                ValorPedestal3 = 2;
                changeCanvasButtons[2].GetComponent<Image>().sprite = buttonSprites[1];
                EstelasNaCenaDoJogo[1].SetActive(true);
                EstelasNaCenaDoJogo[1].transform.position = new Vector3(8.7f, 2.2f, -1.5f);
                if (VariavelControle1 != valorPedestal1)
                {
                    BotaoPosicionar3.SetActive(false);
                    BotaoPegar3.SetActive(true);
                    UltimaEstelaNoPedestal3 = 1;
                    AudioManager.instance.PlaySound(2);
                }
                break;
            #endregion
            #region case3
            case 3:
                inventoryButtons[2].interactable = false;
                inventoryButtons[2].GetComponent<Image>().sprite = buttonSprites[3];
                plaqueImages[2].GetComponent<Image>().sprite = buttonSprites[2];
                ValorPedestal3 = 3;
                changeCanvasButtons[2].GetComponent<Image>().sprite = buttonSprites[2];
                EstelasNaCenaDoJogo[2].SetActive(true);
                EstelasNaCenaDoJogo[2].transform.position = new Vector3(8.7f, 2.2f, -1.5f);
                if (VariavelControle3 == ValorPedestal3)
                {
                    BotaoPosicionar3.SetActive(false);
                    pontuar();
                }
                break;
            #endregion
        }
        UltimoSpriteRecebido = 3;
    }
    #endregion

    #endregion
    #endregion
    #region Botões de Pegar

    #region Botão de Pegar1
    public void ApertarBotaoPegar1()
    {
        AudioManager.instance.PlaySound(0);
        //Desabilitar o botão pegar 1
        BotaoPegar1.SetActive(false);
        //Troca de sprite na placa no menu principal (Pode causar confusão de acordo com a maneira que foi atribuida no inspector)
        plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[3];
        //Habilita o botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal1].interactable = true;
        //Troca de sprite do botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal1].GetComponent<Image>().sprite = buttonSprites[UltimaEstelaNoPedestal1];
        //Habilitar o botao posicionar
        BotaoPosicionar1.SetActive(true);
        //Troca de sprite da estela no Menu principal
        changeCanvasButtons[0].GetComponent<Image>().sprite = buttonSprites[3];
        EstelasNaCenaDoJogo[UltimaEstelaNoPedestal1].SetActive(false);
    }
    #endregion

    #region Botão de Pegar2
    public void ApertarBotaoPegar2()
    {
        AudioManager.instance.PlaySound(0);
        //Desabilitar o botão pegar 2
        BotaoPegar2.SetActive(false);
        //Troca de sprite na placa no menu principal (Pode causar confusão de acordo com a maneira que foi atribuida no inspector)
        plaqueImages[0].GetComponent<Image>().sprite = buttonSprites[3];
        //Habilita o botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal2].interactable = true;
        //Troca de sprite do botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal2].GetComponent<Image>().sprite = buttonSprites[UltimaEstelaNoPedestal2];
        //Habilitar o botao posicionar
        BotaoPosicionar2.SetActive(true);

        //Troca de sprite da estela no Menu principal
        changeCanvasButtons[1].GetComponent<Image>().sprite = buttonSprites[3];
        EstelasNaCenaDoJogo[UltimaEstelaNoPedestal2].SetActive(false);
    }
    #endregion

    #region Botão de Pegar 3
    public void ApertarBotaoPegar3()
    {  
        AudioManager.instance.PlaySound(0);
        //Desabilitar o botão pegar 3
        BotaoPegar3.SetActive(false);
        //Troca de sprite na placa no menu principal (Pode causar confusão de acordo com a maneira que foi atribuida no inspector)
        plaqueImages[1].GetComponent<Image>().sprite = buttonSprites[3];
        //Habilita o botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal3].interactable = true;
        //Troca de sprite do botão do inventario de acordo com o valor que a variavel "Ultima Estela no Pedestal" recebe, ou seja o ultimo botão apertado
        inventoryButtons[UltimaEstelaNoPedestal3].GetComponent<Image>().sprite = buttonSprites[UltimaEstelaNoPedestal3];
        //Habilitar o botao posicionar
        BotaoPosicionar3.SetActive(true);

        //Troca de sprite da estela no Menu principal
        changeCanvasButtons[2].GetComponent<Image>().sprite = buttonSprites[3];
        EstelasNaCenaDoJogo[UltimaEstelaNoPedestal3].SetActive(false);
    }
    #endregion
    #endregion
    void pontuar()
    {
        AudioManager.instance.PlaySound(1);
        Debug.Log("Acertou");
        points += 10;
        if(points == 30)
        {
            VictoryUpdate();
        }
    }
}
