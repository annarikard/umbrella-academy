using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Swap the umbrella for closed one
            //May be done by having both versions and hiding/showing the neccessary one
            Debug.Log("henlo");
        }        
    }
}
