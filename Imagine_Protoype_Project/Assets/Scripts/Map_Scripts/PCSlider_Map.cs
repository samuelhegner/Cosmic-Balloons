using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PCSlider_Map : MonoBehaviour {

    Camera cam;
    Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        slider.minValue = cam.GetComponent<Pinch_Zoom_Camera>().minZoom;
        slider.maxValue = cam.GetComponent<Pinch_Zoom_Camera>().maxZoom;

        cam.orthographicSize = slider.value;
    }
}
