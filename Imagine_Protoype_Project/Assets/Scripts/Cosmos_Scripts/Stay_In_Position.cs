using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_In_Position : MonoBehaviour {

	bool seen;
	public float offSet;

	GameObject player;

	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(seen == false){
			Vector3 posToBe = new Vector3(player.transform.position.x + offSet, transform.position.y, 0);
			
			transform.position = posToBe;

			if(rend.isVisible){
				seen = true;
			}
		}
	}
}
