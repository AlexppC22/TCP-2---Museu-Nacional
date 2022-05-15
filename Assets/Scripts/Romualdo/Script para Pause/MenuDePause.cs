using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuDePause : MonoBehaviour
{
    public GameObject CanvasDeMenuDePausa;
    public GameObject CanvasMenuDeCréditos;
    public bool MenuPrincipalAtivado, MenuDeCreditosAtivados, MenuDeExtraAtivado ;
    
    void Update()
    {
        #region Parar o Jogo apertando Esc e retornando ao voltar a apertar


        if (Input.GetKeyDown(KeyCode.Escape) && Player.instance.canPause)
        {
            if(MenuPrincipalAtivado == false)
            {
                CanvasDeMenuDePausa.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                MenuPrincipalAtivado = true;
            }
            else
            {
                MetodoBotaoRetornar();
            }
           if(MenuDeCreditosAtivados == true)
            {
                CanvasMenuDeCréditos.SetActive(false);
                CanvasDeMenuDePausa.SetActive(true);
                MenuDeCreditosAtivados = false;
                MenuPrincipalAtivado = true;
            }
        }
         
        #endregion


    }

    #region Metodo dos Botões presentes no menu
    
    public void MetodoBotaoRetornar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CanvasDeMenuDePausa.SetActive(false);
        Time.timeScale = 1;
        MenuPrincipalAtivado = false;

    }
    public void MetodoBotaoCreditos()
    {
        CanvasMenuDeCréditos.SetActive(true);
        CanvasDeMenuDePausa.SetActive(false);
        MenuDeCreditosAtivados = true;
        MenuPrincipalAtivado = false;
    }
   
    public void MetodoBotaoCreditosRetornar()
    {
        CanvasMenuDeCréditos.SetActive(false);
        CanvasDeMenuDePausa.SetActive(true);
        MenuPrincipalAtivado = true;
        MenuDeCreditosAtivados = false;
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
