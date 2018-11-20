using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Objects : MonoBehaviour {

    Camera cam;

    float yOffScreen;
    float extra;

    public GameObject testSquare;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight, 0));
		testSquare.transform.position = newPos;
	}
}
