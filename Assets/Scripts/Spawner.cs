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
    public GameObject cameraPosition;
    public GameObject galaxyUmbrella;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeInterval;
        cameraPosition = GameObject.FindWithTag("GalaxyUmbrella");
        cameraPosition = GameObject.FindWithTag("MainCamera");

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

        cameraPosition.transform.SetParent(galaxyUmbrella.transform);
    }

    // Create a new mob in the distance and rotate towards the player
    void Spawn(){
        enemies = GameObject.FindGameObjectsWithTag("BasicBandido");

        if(enemies.Length < maxEnemies)
        {
            var planes = planeManager.trackables;

            if (planes.count < 2) {
                return;
            }

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
                //Get a random point on the plane
                Vector3 randPointOnPlane = randPlane.center;

                //Get a random position on the plane at a distance from the center
                Vector3 randPos = randPointOnPlane + new Vector3(Random.Range(-randPlane.extents.x, randPlane.extents.x), 0, Random.Range(-randPlane.extents.y, randPlane.extents.y));

                // spawn the enemy at the random position
                GameObject newMob = Instantiate(mob, randPos, Quaternion.LookRotation(Vector3.up));

                // Make the enemy face the player
                newMob.transform.LookAt(cameraPosition.transform);
                newMob.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // set the scale to half the original size

                var animator = newMob.GetComponent<Animator>();
            }
        }
    }
}
