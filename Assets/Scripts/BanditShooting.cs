using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditShooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    public GameObject bullet;
    private float timeElapsed;
    public float speed;
    public float shottingCooldown;
    public GameObject playerPosition;
    private Vector3 bulletSpawnPosition;

    public GameObject DEBUG_character_position;


    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        timeElapsed = 0;
        playerPosition = GameObject.FindWithTag("MainCamera");
        DEBUG_character_position = GameObject.FindWithTag("Character");


    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= shottingCooldown)
        {
            Debug.Log("UMBRELLA_DEBUG: Debug character position: " + DEBUG_character_position.transform.position + " camera position: " + playerPosition.transform.position);
            bulletSpawnPosition = transform.Find("ProjectileSpawner").position;


            UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.identity;
            //newRotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.y, newRotation.w);

            Debug.Log(bulletSpawnPosition);
            var newMob = Instantiate(bullet, bulletSpawnPosition, newRotation);
            this.transform.LookAt(playerPosition.transform);
            newMob.transform.LookAt(playerPosition.transform);
            newMob.transform.Rotate(new Vector3(90, 0, 0));

            gameObject.GetComponent<Animator>().SetTrigger("Attack");
            
            timeElapsed = 0;
        }
    }
}
