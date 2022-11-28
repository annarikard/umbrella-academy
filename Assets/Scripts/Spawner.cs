using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        playerPosition = GameObject.Find("Main Camera").transform.position;

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
        
        var animator = newMob.GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("SprintJump", true);
        animator.SetBool("SprintSlide", false);
        
        // newMob.AddComponent<Animation>();
        // var clips = Resources.Load("Assets/BasicBandit/DemoSceneBasicBandit/AnimationsDemoscene/SprintJump_ToLeft_R.fbx");
        // AminationClip[] animation = AnimationUtility.GetAnimationClips(clips);
        // newMob.GetComponent<Animation>().AddClip(animation[0], "run");
        //newMob.GetComponent<Animation>().Play("SprintJump_ToLeft_R");
        //newMob.animation["SprintJump_ToLeft_R"];
        //SprintJump_ToLeft_R.fbx

    }

    Vector3 CalculateMobPosition(float angle, bool isSphere = false){

        if (isSphere){
            // This is not implemented
            return new Vector3(10, 10, 10);
        } else {
            Vector3 test = new Vector3(distance * Mathf.Cos(angle) + playerPosition.x, playerPosition.y - 1, distance * Mathf.Sin(angle) + playerPosition.z);
            Debug.Log("X: " + test.x + " " + "Z: " + test.z);
            return test;
        }
        //Vector3 newPosition = new Vector3();

    }
}
