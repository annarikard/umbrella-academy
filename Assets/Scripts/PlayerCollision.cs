using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    public bool immortal;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !immortal)
        {
            Debug.Log("UMBRELLA_DEBUG: Bullet position: " + collision.gameObject.transform.position + " our position: " + this.transform.position + " contact position: " + collision.GetContact(0).point + " contact separation: " + collision.GetContact(0).separation);
            SceneManager.LoadScene("death");
        }
    }
}

