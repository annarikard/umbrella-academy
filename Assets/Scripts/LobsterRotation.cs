using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterRotation : MonoBehaviour
{

    private GameObject lobster;
    private Transform cam;
    public float speed;
    private float timeElapsed;
    //public Vector3 vector { get; set; };
    

    // Start is called before the first frame update
    
    void Start()
    {
        timeElapsed = 0;
        speed = 0.8f;
        cam = Camera.main.transform;
        transform.rotation = cam.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime*speed);
        transform.Rotate(new Vector3(0*timeElapsed, 0, 3*timeElapsed));
        timeElapsed += Time.deltaTime;

    }
}
