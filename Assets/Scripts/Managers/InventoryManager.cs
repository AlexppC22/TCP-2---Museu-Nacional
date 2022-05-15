using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itens
{
    pyramid0,
    pyramid1,
    pyramid2
}

public class InventoryManager : MonoBehaviour
{
    Itens itens;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void PickUpItem()
    {
        switch(itens)
        {
            case Itens.pyramid0:
            break;
            case Itens.pyramid1:
            break;
            case Itens.pyramid2:
            break;
        }
    }
        public void PutkDownItem()
    {
        switch(itens)
        {
            case Itens.pyramid0:
            break;
            case Itens.pyramid1:
            break;
            case Itens.pyramid2:
            break;
        }
    }
}
