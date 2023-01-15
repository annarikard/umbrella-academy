using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    bool slowDown = false;
    public float slowDownTime;
    float slowDownTimeRemaining;

    public CameraPostProcess cameraEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slowDown){
            slowDownTimeRemaining -= Time.deltaTime;

            if (slowDownTimeRemaining <= 0f){
                slowDown = false;
                cameraEffect.enabled = false;
            }
        }
    }

    public void enableSlowDown(){
        slowDown = true;
        slowDownTimeRemaining = slowDownTime;
        cameraEffect.enabled = true;
    }

    public bool isSlowDown(){
        return slowDown;
    }

}
