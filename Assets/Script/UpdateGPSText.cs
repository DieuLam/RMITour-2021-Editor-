using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates;

    private void Update()
    {
        // raw data from sensor
        float lat = GPS.Instance.latitude;
        float lon = GPS.Instance.longitude;

        // calculate to fit in unity
        float z = ((lat - 10.72900f) * 100000);   // latitude
        float x = ((lon - 106.69600f) * 100000);  // longitude
        
        // display
        coordinates.text = "Lat: " + z.ToString() + "\nLon: " + x.ToString();
    }
}
