using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class player_move_flap_volume_speed : MonoBehaviour {


	public AudioSource Source;

	private Player_Movement_Map _PMM; 
	
	// Use this for initialization
	void Start () {

		_PMM = GetComponent<Player_Movement_Map>();

	}
	
	// Update is called once per frame
	void Update () {

		float newVolume = Game_Manager.Map(_PMM.movementSpeed, _PMM.MinSpeed, _PMM.MaxSpeed, 0f, 1f);

		Source.volume = newVolume; 





	}
}
