using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch_Zoom_Camera : MonoBehaviour {

    public float orthoZoomSpeed = .5f;
    public float maxZoom = 20f;
    public float minZoom = 6f;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 2) {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
            cam.orthographicSize = Mathf.Max(cam.orthographicSize, minZoom);
            cam.orthographicSize = Mathf.Min(cam.orthographicSize, maxZoom);
        }
    }
}
