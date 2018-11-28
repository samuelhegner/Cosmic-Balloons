using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp_Camera : MonoBehaviour
{
    public Vector3 maxValues;
    public Vector3 minValues;

    Vector3 camMin;
    Vector3 camMax;

    public Camera cam;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // camMax = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
        // camMin = cam.ScreenToWorldPoint(Vector3.zero);

        //Vector3 middleCam = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minValues.x, maxValues.x), Mathf.Clamp(transform.position.y, minValues.y, maxValues.y), -10);
    }
}