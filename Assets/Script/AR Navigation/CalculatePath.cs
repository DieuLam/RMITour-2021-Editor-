using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatePath : MonoBehaviour
{
    [SerializeField]
    private Transform Destination;

    [SerializeField]
    private Text DistanceText;

    private float distance;

    private void Update()
    {
        if (SetNavigationTarget.tempDes != null)
        {
            Destination = SetNavigationTarget.tempDes;
            distance = (Destination.transform.position - transform.position).magnitude;
            DistanceText.text = "Distance: " + distance.ToString("F1") + " m";
        }
        else
        {
            DistanceText.text = "Distance: 0m";
        }

    }
}
