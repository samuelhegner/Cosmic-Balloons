using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Clouds : MonoBehaviour {

	float countdown;
	public float maxCountdown;
	public float speed;
	float a;

	float dist;
	public float maxDist;

	public bool x;

	Vector3 idlePos;
	Vector3 movePos;

	GameObject player;

	SpriteRenderer rend;

	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		rend = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}

	void Start () {
		a = 0;
		idlePos = transform.position;
		if(x){
			movePos = new Vector3(transform.parent.transform.position.x, transform.position.y, 0);
		}else{
			movePos = new Vector3(transform.position.x, transform.parent.transform.position.y, 0);
		}
	}
	
	void Update () {
		dist = Vector2.Distance(player.transform.position, transform.position);
		Color col = new Color(1, 1, 1, a);

		if(dist < maxDist){
			if(a < 1)
			a += Time.deltaTime;
		}else{
			if(a > 0)
			a -= Time.deltaTime/3f;
		}

		if(x){
			idlePos.y = player.transform.position.y;
			movePos.y = player.transform.position.y;
		}else{
			idlePos.x = player.transform.position.x;
			movePos.x = player.transform.position.x;
		}



		if(countdown > 0){
			countdown -= Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * speed);
		}else{
			transform.position = Vector3.Lerp(transform.position, idlePos, Time.deltaTime * speed/2f);
		}

		rend.color = col;
	}

	public void ResetTimer(){
		countdown = maxCountdown;
	}
}
