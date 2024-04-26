using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pose { A, B, C };


public class PersonajePoseScript : MonoBehaviour
{

    public pose poseActual;
    public Material[] renders;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            poseActual = pose.A;
            this.GetComponent<Renderer>().material = renders[0];
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            poseActual = pose.B;
            this.GetComponent<Renderer>().material = renders[1];
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            poseActual = pose.C;
            this.GetComponent<Renderer>().material = renders[2];
        } 

    }
}
