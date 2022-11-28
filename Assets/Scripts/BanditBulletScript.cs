using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float timeElapsed;
    void Start()
    {
        speed = 0.8f;   
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime; 
        transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime*speed);
        if (timeElapsed > 10) Destroy(this.gameObject);
    }
}
