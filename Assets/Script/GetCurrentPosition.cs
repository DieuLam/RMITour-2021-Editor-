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
        float lat = ((GPS.Instance.latitude - 10.72900f) * 100000) - 6.41f;   // z
        float lon = ((GPS.Instance.longitude - 106.69000f) * 10000) + 15.52f;  // x
        // transform.position = new Vector3(lon, 2f, lat);

        // hard coded value
        float x = 60.00f + 1255.49f;
        float z = 30.00f + 1192.00f;
        float y = -1639.862f;
        transform.position = new Vector3(x, y, z);

    }
}
