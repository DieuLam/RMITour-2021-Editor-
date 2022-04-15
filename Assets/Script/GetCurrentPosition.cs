using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCurrentPosition : MonoBehaviour
{
    // Start is called before the first frame update

    void Start() {
        StartCoroutine(Teleport());
    }
    
    IEnumerator Teleport() {

        yield return new WaitForSeconds(2);
        float lat = ((GPS.Instance.latitude - 10.72900f) * 100000) - 6.41f;   // z
        float lon = ((GPS.Instance.longitude - 106.69000f) * 10000) + 15.52f;  // x
        
        // hard coded value
        // float x = 41.00f + 15.52f; 
        // float y = 500.00f - 6.41f;   

        transform.position = new Vector3(lon, 2f, lat);
    }
}
