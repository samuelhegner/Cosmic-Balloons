using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Position : MonoBehaviour {

	public bool activated;

	public float yBuffer = 10;
	public float xBuffer = 0f;

	GameObject player;

	Camera cam;

	// Use this for initialization
	void Start () {
		activated = false;
		cam = Camera.main;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(activated == false){
			Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
			newPos.z = 1;
			newPos.x -= xBuffer;
			newPos.y += yBuffer;
			transform.position = newPos;
		}

		if(gameObject.tag == "Planet"){
			float planetStart = player.GetComponent<Player_Movement_Cosmos>().ReachedPlanet();
			if(planetStart <= 0){
				activated = true;
				gameObject.GetComponent<Activate_Endgame>().enabled = true;
			}
		}

	}
}
