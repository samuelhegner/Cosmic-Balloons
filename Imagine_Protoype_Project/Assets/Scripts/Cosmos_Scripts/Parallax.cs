using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;

    float[] parallaxScales;

    public float smoothing;

    Transform cam;

    Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float parallaxY = (previousCamPos.y - cam.position.y) * parallaxScales[i];

            float backgroundTargetPositionX = backgrounds[i].position.x + parallaxX;
            float backgroundTargetPositionY = backgrounds[i].position.y + parallaxY;


            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, backgroundTargetPositionY, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
