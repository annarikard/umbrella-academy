using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fold"))
            {
                _animator.SetTrigger("Attack");

                Quaternion quaternion = Quaternion.identity;
                quaternion.Set(transform.rotation.x, transform.rotation.y, transform.rotation.y, quaternion.w);
                Instantiate(bullet, transform.position, quaternion);
            }
        }
    }
}
