using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    public Camera cam;

    private void Start() {}

    private void MyFunction() {}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside Trigger Zone");

        if (other.tag == "Player") 
        {
            cam.cullingMask = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 5 |  // default requirement
                                1 << 13 | 1 << 11 | 1 << 16;  // floor & wall
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Outside Trigger Zone");

        if (other.tag == "Player")
        {
            cam.cullingMask =  1 << 0 | 1 << 1 | 1 << 2 | 1 << 4 | 1 << 5 | // default requirement
                               1 << 11 | 1 << 14 | 1 << 17;  // floor & wall
        }
    }
}