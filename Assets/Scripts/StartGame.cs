using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "start" && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("landscape");
        }
    }
}
