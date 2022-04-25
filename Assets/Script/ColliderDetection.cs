using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        
    }

    private void MyFunction()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm the trigger, someone has enter");

        if (other.tag == "Player") {

            cam.cullingMask = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8 | 1 << 9 | 1 << 11 | 1 << 13 | 1 << 14;
          
        }

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit Event");

        if (other.tag == "Player")
        {
            cam.cullingMask = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 8 | 1 << 9 | 1 << 11 | 1 << 14;


        }


    }
}
