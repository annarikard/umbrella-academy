using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobsterRotation : MonoBehaviour
{
    private Transform cam;
    public float speed;

    public GameObject explosion;

    private float timeElapsed;
    
    void Start()
    {
        timeElapsed = 0;
        speed = 5f;
        cam = Camera.main.transform;
        transform.rotation = cam.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime*speed);
        transform.Rotate(new Vector3(0*timeElapsed, 0, 3*timeElapsed));
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 10f){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BasicBandido")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console

            GameObject tempExplosion = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);

            // The second parameter corresponds to playback time of the explosion effect
            // Change accordingly, or couple it together somehow
            Destroy(tempExplosion, 4f);
   
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
