using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float distance;
    public GameObject mob;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = transform.position + new Vector3(distance, 0, distance);

        //Fix the rotation
        Quaternion newRotation = Quaternion.identity * new Quaternion(transform.rotation.x, transform.position.y, transform.position.z, 1);
        //newRotation.Set(newRotation.x, 180 - transform.rotation.y, newRotation.z, newRotation.w);
        GameObject newMob = Instantiate(mob, newPosition, newRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
