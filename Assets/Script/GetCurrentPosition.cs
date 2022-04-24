using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCurrentPosition : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);

        // raw data from sensor
        // float lat = GPS.Instance.latitude;
        // float lon = GPS.Instance.longitude;

        // hard code position
        float lat = 10.729429626517074f;
        float lon = 106.69643573403546f;

        // calculate to fit in unity
        float z = ((lat - 10.72900f) * 100000) - 35;   // latitude
        float x = ((lon - 106.69600f) * 100000) - 25 - 13;  // longitude
        float y = 2;  // height of current location

        transform.position = new Vector3(x, y, z);  // move the current location in Unity

    }
}
