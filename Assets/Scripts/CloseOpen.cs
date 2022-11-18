using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpen : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)){
            //Swap the umbrella for closed one
            //May be done by having both versions and hiding/showing the neccessary one
            Debug.Log("henlo");
        }
        */
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");

            if(_animator != null)
            {
                _animator.SetTrigger("Fold");
            }

            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Unfold"))
            {
                _animator.SetTrigger("Fold");
            }
        }

        if (Input.GetKey("l"))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fold"))
            {
                _animator.SetTrigger("Unfold");
            }
        }

        
    }
}
