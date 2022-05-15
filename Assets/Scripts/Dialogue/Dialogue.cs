using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour
{
    public Transform objPos;
    public Transform playerPos;
    public float distance;
    public GameObject interactionText;

    private void Update() 
    {
        distance = Vector3.Distance(playerPos.position, this.transform.position);
    }
}
