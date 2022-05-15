using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragNDrop : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler

{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Canvas puzzleCanvas;
    [SerializeField] private CanvasGroup canvasGroup;
    
    public void OnBeginDrag(PointerEventData evenData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData evenData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnDrag(PointerEventData evenData)
    {
        _transform.anchoredPosition += evenData.delta / puzzleCanvas.scaleFactor;
    }



}
