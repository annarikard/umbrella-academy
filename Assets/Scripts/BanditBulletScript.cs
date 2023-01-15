using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    private float timeElapsed;

    PowerupManager powerupManager;
    void Start()
    {
        powerupManager = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float tempSpeed = (powerupManager.isSlowDown()) ? (speed / 2f) : speed;

        timeElapsed += Time.deltaTime; 
        transform.Translate(new Vector3(0, 1, 0)*Time.deltaTime*tempSpeed);
        if (timeElapsed > lifetime) Destroy(this.gameObject);
    }
}
