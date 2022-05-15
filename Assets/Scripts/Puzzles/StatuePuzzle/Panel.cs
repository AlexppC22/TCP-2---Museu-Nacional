using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour , IDropHandler
{
    public GameObject correctImage;
    [SerializeField] private RectTransform _transform;
   
    public void OnDrop(PointerEventData evenData)
    {
        if(evenData.pointerDrag.gameObject == correctImage)
        {
            AudioManager.instance.PlaySound(1);
            AddPiece();
        }
        else
        {
            AudioManager.instance.PlaySound(2);
        }
        evenData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
    }
    
    void AddPiece()
    {
        StatuePuzzle.instance.imagesConnected++;
    }


    


   



}
