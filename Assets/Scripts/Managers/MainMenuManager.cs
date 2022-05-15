using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject CanvasDeMenuPrincipal;
    public GameObject CanvasMenuDeCréditos;
    public GameObject CanvasMenuDeExtra;
    public bool MenuPrincipalAtivado, MenuDeCreditosAtivados, MenuDeExtraAtivado;

  
    void Update()
    {
        #region Controle do Menu através do Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (MenuDeCreditosAtivados == true)
            {
                CanvasMenuDeCréditos.SetActive(false);
                CanvasDeMenuPrincipal.SetActive(true);
                MenuDeCreditosAtivados = false;
                MenuPrincipalAtivado = true;
            }
            if (MenuDeExtraAtivado == true)
            {

                CanvasMenuDeExtra.SetActive(false);
                CanvasDeMenuPrincipal.SetActive(true);
                MenuDeExtraAtivado = false;
                MenuPrincipalAtivado = true;

            }
        }
        #endregion


    }


    #region Metodo dos Botões presentes no menu

    //Créditos
    public void MetodoBotaoCreditos()
    {
        CanvasMenuDeCréditos.SetActive(true);
        CanvasDeMenuPrincipal.SetActive(false);
        MenuDeCreditosAtivados = true;
        MenuPrincipalAtivado = false;
    }
    //Retornar dos Creditos
    public void MetodoBotaoCreditosRetornar()
    {
        CanvasMenuDeCréditos.SetActive(false);
        CanvasDeMenuPrincipal.SetActive(true);
        MenuPrincipalAtivado = true;
        MenuDeCreditosAtivados = false;
    }


    //Extras
    public void MetodoBotaoDeExtras()
    {
        CanvasMenuDeExtra.SetActive(true);
        CanvasDeMenuPrincipal.SetActive(false);
        MenuPrincipalAtivado = false;
        MenuDeExtraAtivado = true;
    }
   //Retornar dos Extras
    public void MetodoBotaoDeExtrasRetornar()
    {
        CanvasMenuDeExtra.SetActive(false);
        CanvasDeMenuPrincipal.SetActive(true);
        MenuPrincipalAtivado = true;
        MenuDeExtraAtivado = false;
    }
    #endregion

    #region Inicio do Jogo (PRECISA DE AJUSTE)
    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void SairDoJogo()
    {

    }

    #endregion

    #region Sair do Jogo



    public void QuitGame()
    {

        Application.Quit();
    }




    #endregion

}
