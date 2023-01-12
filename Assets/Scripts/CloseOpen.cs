using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpen : MonoBehaviour
{
   private Animator _animator;
   public GameObject bullet;
   public bool attacking;
    public float attackSpeedModifier;
    // Completely arbitrary, must be set to 1.2/attackSpeedModifier
    private float attackSpeedSeconds;

    private int i  = 0;
    private float doubleTapThreshold = 0.3f;
    private int tapCount;
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
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                tapCount++;
                StartCoroutine(SingleOrDoubleTap());
            }
        }
    }

    public void OpenClose() {
        UmbrellaCollisionHandler umbrellaCollisionHandler = (UmbrellaCollisionHandler) GetComponent("UmbrellaCollisionHandler");
        if (i % 2 == 0)
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

    public void Attack() {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Fold"))
        {
            attacking = true;
            _animator.SetTrigger("Attack");
            StartCoroutine(SpawnBullet());        
        }
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

    IEnumerator SingleOrDoubleTap()
    {
        yield return new WaitForSeconds(doubleTapThreshold);
 
        if (tapCount == 1)
        {
            Debug.Log("SingleTap");
            OpenClose();
            tapCount = 0;
        }
        else if (tapCount == 2)
        {
            Debug.Log("Double Tap");
            Attack();
            tapCount = 0;
        }
 
    }
}
