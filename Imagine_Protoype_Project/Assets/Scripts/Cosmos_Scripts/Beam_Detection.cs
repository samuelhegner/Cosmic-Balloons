using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Detection : MonoBehaviour {

	Vector3 origin;
	Vector3 upperPoint;

	GameObject circle;

	float yPos;

	public bool playerArrived;

	LineRenderer rend;

	GameObject player;

	private bool played;

	void Start () {
		circle = transform.GetChild(0).gameObject;
		playerArrived = false;
		player = GameObject.FindGameObjectWithTag("Player");
		rend = GetComponent<LineRenderer>();


		//GetComponent<AudioManager>().Play("Beam_On");
	}
	
	void Update () {
		origin = transform.position;

		rend.SetPosition(0, origin);
		rend.SetPosition(1, upperPoint);
		rend.startWidth = 0.1f;
		rend.endWidth = 5f;

		circle.transform.position = upperPoint;


		if(playerArrived == false){
			if(yPos < player.transform.position.y + 300){
				yPos += Time.deltaTime * 50f;
			}

			upperPoint = new Vector3(transform.position.x, transform.position.y + yPos, 0);
		}else{

			if (!played) {

				GetComponent<AudioManager>().Play("Beam_On");
				played = true;
			}

			upperPoint = Vector3.Lerp(upperPoint, player.transform.position, Time.deltaTime * 4f);
		}

	}
}
