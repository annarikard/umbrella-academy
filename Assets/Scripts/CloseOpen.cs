using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpen : MonoBehaviour
{
    private Animator _animator;
    private int i  = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(i % 2 == 0)
            {
                Debug.Log("space");

                if (_animator != null)
                {
                    _animator.SetTrigger("Fold");
                }
            }
            else
            {
                _animator.SetTrigger("Unfold");
            }
            i++;
        }
    }
}
