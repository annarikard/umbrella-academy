using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    private Vector3 camRotation;
    private Transform cam;
    private Vector3 moveDirection;

    [Range(-179, 0)]
    public int minAngle = -30;
    [Range(0, 179)]
    public int maxAngle = 45;
    [Range(50, 500)]
    public int sensitivity = 200;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Debug.Log(Cursor.lockState);
        //Press the space bar to apply no locking to the Cursor
        // Debug stff (YEET this later)
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        Rotate();
    }

    private void Rotate()
    {
        //transform.Rotate(Vector3.up * sensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));

        camRotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        camRotation.y -= Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime * -1f;
        
        
         camRotation.x = Mathf.Clamp(camRotation.x, -90f, 0f);
        // camRotation.y = Mathf.Clamp(camRotation.y, -180f, 180f);


        cam.localEulerAngles = camRotation;
        
        
    }
}