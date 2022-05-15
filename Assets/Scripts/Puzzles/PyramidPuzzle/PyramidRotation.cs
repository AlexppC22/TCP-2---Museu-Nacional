using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PyramidRotation : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool permiterotinaauxiliar;
    private int facedocubo;

    void Start()
    {
        permiterotinaauxiliar = true;
        facedocubo = 1;
    }
    

    private void OnMouseDown()
    {
        if (permiterotinaauxiliar)
        {
            StartCoroutine("Rodacubo");
            AudioManager.instance.PlaySound(3);
        }
    }
    //Fazer com que possa rodar para os 2 lados
    //Do modo que preferir/saber/conseguir
    public IEnumerator Rodacubo()
    {
        permiterotinaauxiliar = false;
        for (int i = 0; i < 9; i++)
        {
            transform.Rotate(0, 0, -10f);
            yield return new WaitForSeconds(0.10f);
        }
        permiterotinaauxiliar = true;
        facedocubo += 1;
        if (facedocubo > 4)
        {
            facedocubo = 1;
        }
        Rotated(name, facedocubo);
    }

}