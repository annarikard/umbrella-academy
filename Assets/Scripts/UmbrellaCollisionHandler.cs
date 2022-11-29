using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaCollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isFolded;
    void Start()
    {
        isFolded = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!isFolded)
            {
                Destroy(collision.gameObject);
            }

        }
    }
}

