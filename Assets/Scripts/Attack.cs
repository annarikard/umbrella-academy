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

                UnityEngine.Quaternion quaternion = UnityEngine.Quaternion.identity;
                quaternion.Set(transform.rotation.x, transform.rotation.y, transform.rotation.y, quaternion.w);
                StartCoroutine(waiter(quaternion));
                
            }
        }
    }

    void attackOver(){

        attacking = false;

    }

    IEnumerator waiter(UnityEngine.Quaternion quaternion)
    {
        yield return new WaitForSeconds(1.2f);
        Instantiate(bullet, transform.position, quaternion);
        attackOver();
    }
}
