using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]

public class ImageTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private ARTrackedImageManager trackImageManager;

    private void Awake() {

        trackImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in placeablePrefabs) 
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);

            //sets the local scale of an object
            newPrefab.transform.localScale = new Vector3(0,0,0);

            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }  
    }

    private void OnEnable() {

        trackImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable() {

        trackImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs) {

        foreach(ARTrackedImage trackedImage in eventArgs.added) {
            UpdateImage(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.updated) {
            UpdateImage(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.removed) {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage) {

        string name = trackedImage.referenceImage.name;

        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];

        prefab.transform.position = position;

        // sets the local scale of an object
        prefab.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
        prefab.transform.rotation = trackedImage.transform.rotation;
        prefab.SetActive(true);

        // foreach(GameObject go in spawnedPrefabs.Values) {
        //     go.transform.rotation = trackedImage.transform.rotation;
        //     if (go.name != name) {
        //         go.SetActive(false);
        //     }
        // }
    }
}
