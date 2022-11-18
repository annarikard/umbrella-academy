using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 20;
        if (Input.GetKey("a"))
        {
            this.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            this.transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            this.transform.Translate(0, 0, 1 * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            this.transform.Translate(0, 0, -1 * speed * Time.deltaTime);
        }
        if (Input.GetKey("r"))
        {
            this.transform.Translate(0, 1 * speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("f"))
        {
            this.transform.Translate(0, -1 * speed * Time.deltaTime, 0);
        }

        if (Input.GetKey("q"))
        {
            this.transform.Rotate(0, -5 * speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("e"))
        {
            this.transform.Rotate(0, 5 * speed * Time.deltaTime, 0);
        }
    }
}
