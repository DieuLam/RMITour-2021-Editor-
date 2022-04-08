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
        float lat = GPS.Instance.latitude;
        float lon = GPS.Instance.longitude;
        float x = 41.0f;
        float y = 630.00f;
        transform.position = new Vector3(x, 2f, y);
    }
}
