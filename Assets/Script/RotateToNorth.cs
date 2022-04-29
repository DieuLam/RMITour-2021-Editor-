using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToNorth : MonoBehaviour
{
    [SerializeField] private MinimapSettings settings;
    [SerializeField] private float cameraheight;


    private void Awake()
    {
        settings = GetComponentInParent<MinimapSettings>();
        cameraheight = transform.position.y;
    }

    private void Update()
    {
        Vector3 targetPosition = settings.targetToFollow.transform.position;


        transform.position = new Vector3(targetPosition.x, targetPosition.y + cameraheight, targetPosition.z);

        if (settings.rotateWithTheTarget)
        {
            Quaternion targetRotation = settings.targetToFollow.transform.rotation;

            transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 0);
        }
    }
}
