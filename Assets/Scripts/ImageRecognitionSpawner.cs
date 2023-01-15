using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionSpawner : MonoBehaviour
{

    public PowerupManager powerupManager;

    [SerializeField] ARTrackedImageManager m_TrackedImageManager;

    void Awake(){

    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
{
    foreach (var newImage in eventArgs.added)
    {
        Debug.Log("UMBRELLA_DEBUG: newImage");
        powerupManager.enableSlowDown();
    }

    foreach (var updatedImage in eventArgs.updated)
    {
        Debug.Log("UMBRELLA_DEBUG: updatedImage");
        // Handle updated event
    }

    foreach (var removedImage in eventArgs.removed)
    {
        // Handle removed event
    }
}
}
