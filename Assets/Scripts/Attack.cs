using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;
    public GameObject bullet;
    public bool attacking;
    public float attackSpeedModifier;
    // Completely arbitrary, must be set to 1.2/attackSpeedModifier
    private float attackSpeedSeconds;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        _animator = gameObject.GetComponent<Animator>();
        _animator.speed = attackSpeedModifier;

        attackSpeedSeconds = 1.2f/attackSpeedModifier;
    }

    // Update is called once per frame
    void Update()
    {		
		Debug.Log("I AM NOT RUNNNING!!!!!!!!");

		Debug.Log(attacking);
        /*if (!attacking)
        {
		Debug.Log("entering");
			if (Input.touchCount > 0) {
				Debug.Log("i have touchcount");
				Debug.Log(IsDoubleTap());
				Debug.Log("I am in first if");
            	if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fold"))
            	{
					Debug.Log("I am in second if");
                	attacking = true;

                	_animator.SetTrigger("Attack");
					Debug.Log("I am starting a coroutine");
                	StartCoroutine(SpawnBullet());
                
            	}
			}
        }*/
    }

    IEnumerator SpawnBullet()
    {
        GameObject bulletSpawner = GameObject.Find("BulletSpawner");

        UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.identity;
        newRotation.Set(bulletSpawner.transform.rotation.x, bulletSpawner.transform.rotation.y, bulletSpawner.transform.rotation.y, newRotation.w);

        // Swith to events rather than a hard-coded time value
        yield return new WaitForSeconds(attackSpeedSeconds);
        Instantiate(bullet, bulletSpawner.transform.position, newRotation);
        attacking = false;
    }

	public static bool IsDoubleTap(){
         bool result = false;
         float MaxTimeWait = 3;
         float VariancePosition = 3;
		float tapCount = 0;
		float touchTime = 0;
		float touchEndTime = 0;
 
		Debug.Log("in dt");
		Debug.Log(Input.touchCount);
         if(Input.touchCount == 1)
        {
			Debug.Log("touchcount");
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tapCount++;
				Debug.Log("inc tapcount");
                touchTime = Time.time;
            }
 
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (tapCount == 1)
                {
                    touchEndTime = Time.time;
 
                    if (touchEndTime - touchTime < 1.2f)
                    {
                        Debug.Log("Single Tap");
                    }
                }
 
                if (tapCount == 2)
                {
                    Debug.Log("Double Tap");
					result = true;
                }
            }
       
        }

		Debug.Log("Result from IsDoubleTap:");
		Debug.Log(result);
         return result;
     }
}
