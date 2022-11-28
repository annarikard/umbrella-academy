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
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            UmbrellaCollisionHandler umbrellaCollisionHandler = (UmbrellaCollisionHandler) GetComponent("UmbrellaCollisionHandler");
            if(i % 2 == 0)
            {
                if (_animator != null)
                {
                    _animator.SetTrigger("Fold");
                    umbrellaCollisionHandler.isFolded = true;
                }
            }
            else
            {
                _animator.SetTrigger("Unfold");
                umbrellaCollisionHandler.isFolded = false;
            }
            i++;
        }
    }
}
