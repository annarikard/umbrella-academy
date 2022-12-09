using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachUmbrella : MonoBehaviour
{
    Camera arCam;
    public GameObject galaxyUmbrella;
    public float distance = 1;

    // Start is called before the first frame update
    void Start()
    {
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        galaxyUmbrella = GameObject.FindGameObjectWithTag("GalaxyUmbrella");
    }

    // Update is called once per frame
    void Update()
    {
        galaxyUmbrella.transform.position = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * distance;
        galaxyUmbrella.transform.SetParent(GetComponent<Camera>().transform);
        galaxyUmbrella.transform.localPosition = Vector3.forward * distance;
    }
}
