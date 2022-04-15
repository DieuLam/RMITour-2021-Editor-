using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates; 

    private void Update() {
        coordinates.text = "Lat: " + GPS.Instance.z.ToString() + " Lon:" + GPS.Instance.x.ToString();
    }
}
