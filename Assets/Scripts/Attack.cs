using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;
    public GameObject bullet;

    public bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l") && !attacking)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fold"))
            {
                attacking = true;

                _animator.SetTrigger("Attack");

                StartCoroutine(SpawnBullet());
                
            }
        }
    }

    void attackOver(){

        attacking = false;

    }

    IEnumerator SpawnBullet()
    {

        GameObject bulletSpawner = GameObject.Find("BulletSpawner");


        UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.identity;
        newRotation.Set(bulletSpawner.transform.rotation.x, bulletSpawner.transform.rotation.y, bulletSpawner.transform.rotation.y, newRotation.w);

        // Swith to events rather than a hard-coded time value
        yield return new WaitForSeconds(1.2f);
        Instantiate(bullet, bulletSpawner.transform.position, newRotation);
        attackOver();
    }
}
