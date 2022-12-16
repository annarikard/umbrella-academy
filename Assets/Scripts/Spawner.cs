using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.ARFoundation;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject mob;
    public float distance;
    public float timeInterval;
    public int maxEnemies;
	private ARAnchorManager anchorManager;
    private ARPlaneManager planeManager;
    private float timeRemaining;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeInterval;
        playerPosition = GameObject.Find("Character").transform.position;

        planeManager = GetComponent<ARPlaneManager>();
		anchorManager = GetComponent<ARAnchorManager>();

        Spawn();

        enemies = GameObject.FindGameObjectsWithTag("BasicBandido");
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
        enemies = GameObject.FindGameObjectsWithTag("BasicBandido");

        if(enemies.Length < maxEnemies)
        {
            var planes = planeManager.trackables;

            int rand = Random.Range(0, planes.count - 1);
            int i = 0;

            ARPlane randPlane = null;

            foreach (ARPlane plane in planes)
            {
                if (i == rand)
                {
                    randPlane = plane;
                }

                Debug.Log("Detected plane: " + plane.name);

                i++;
            }

            if(randPlane != null)
            {
                GameObject newMob = Instantiate(mob, randPlane.center, Quaternion.identity);
				
                newMob.transform.LookAt(playerPosition);
				
				newMob.AddComponent<ARAnchor>();
				anchorManager.AttachAnchor(randPlane, new Pose(newMob.transform.position, newMob.transform.rotation));

                var animator = newMob.GetComponent<Animator>();
            }
            
            // animator.SetBool("Walk", false);
            // animator.SetBool("SprintJump", false);
            // animator.SetBool("SprintSlide", false);
        }
    }

    Vector3 CalculateMobPosition(float angle, bool isSphere = false){

        if (isSphere){
            // This is not implemented
            return new Vector3(10, 10, 10);
        } else {
            return new Vector3(distance * Mathf.Cos(angle) + playerPosition.x, playerPosition.y, distance * Mathf.Sin(angle) + playerPosition.z);
        }
    }
}
