using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp_Camera : MonoBehaviour
{
    public Vector3 maxValues;
    public Vector3 minValues;

    Vector3 camMaxX;
    Vector3 camMaxY;

    public Camera cam;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camMaxX = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight/2, 0));
        camMaxY = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight, 0));

        Vector3 middleCam = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0));


        float xDistance = Vector2.Distance(camMaxX, middleCam);
        float yDistance = Vector2.Distance(camMaxY, middleCam);


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minValues.x + xDistance, maxValues.x - xDistance), Mathf.Clamp(transform.position.y, minValues.y + yDistance, maxValues.y -yDistance), -10);
    }
}