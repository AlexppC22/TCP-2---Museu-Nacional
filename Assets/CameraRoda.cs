using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoda : MonoBehaviour
{
    public float rotateSpd = 1;
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 0.5f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -0.5f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0, 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3(0, -0.1f, 0);
        }


        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= new Vector3(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(0.1f, 0, 0);
        }
    }
}
