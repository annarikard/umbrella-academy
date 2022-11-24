using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject mob;
    public float distance;
    public float timeInterval;

    private float timeRemaining;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeInterval;
        playerPosition = new Vector3(0, 0, 0);

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeRemaining <= 0){
            timeRemaining = timeInterval;
            Spawn();
        }        

        timeRemaining -= Time.deltaTime;

    }

    // Create a new mob in the distance and rotate towards the player
    void Spawn(){


        float randomAngle = Random.Range(0f, 2f*Mathf.PI);
        Debug.Log(randomAngle);
        Vector3 newPosition = CalculateMobPosition(randomAngle);

        GameObject newMob = Instantiate(mob, newPosition, Quaternion.identity);
        newMob.transform.LookAt(playerPosition);

    }

    Vector3 CalculateMobPosition(float angle, bool isSphere = false){

        if (isSphere){
            // This is not implemented
            return new Vector3(10, 10, 10);
        } else {
            Vector3 test = new Vector3(distance * Mathf.Cos(angle) + playerPosition.x, playerPosition.y, distance * Mathf.Sin(angle) + playerPosition.z);
            Debug.Log("X: " + test.x + " " + "Z: " + test.z);
            return test;
        }
        //Vector3 newPosition = new Vector3();

    }
}
