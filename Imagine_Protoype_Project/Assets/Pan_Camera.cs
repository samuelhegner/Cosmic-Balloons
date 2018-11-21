using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan_Camera : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 0.025f;

    float camMin;
    float camMax;

    public GameObject camObj;

    Camera cam;

    void Start()
    {
        camMax = camObj.GetComponent<Pinch_Zoom_Camera>().maxZoom;
        camMin = camObj.GetComponent<Pinch_Zoom_Camera>().minZoom;
        cam = camObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = Game_Manager.Map(cam.orthographicSize, camMin, camMax, 0.025f, 0.1f);

        if(Input.touchCount > 1){
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }
        
    }
}
