using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    private float timeElapsed;
    void Start()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime; 
        transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime*speed);
        if (timeElapsed > lifetime) Destroy(this.gameObject);
    }
}
