using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]

public class QrCodeTracking : MonoBehaviour
{
    private ARTrackedImageManager trackImageManager;

    public GameObject currentPosition;

    private void Awake() 
    {
        trackImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable() {

        trackImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable() {

        trackImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs args) {

        currentPosition.transform.position = new Vector3(7.56f, 2, 2.25f);  // move current position
    }
}