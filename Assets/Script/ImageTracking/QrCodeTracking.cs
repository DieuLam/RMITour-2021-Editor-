using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]

public class QrCodeTracking : MonoBehaviour
{
    private ARTrackedImageManager trackImageManager;

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

        foreach (var trackedImage in args.added) {
            Debug.Log(trackedImage.name);
        }
    }
}