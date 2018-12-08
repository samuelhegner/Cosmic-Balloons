using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Script : MonoBehaviour {


	public AudioManager AM; 
	
	private void OnEnable() {
		AM.Play("Wind", true, 2f, 0.6f);
	}

	private void OnDisable() {
		AM.Stop("Wind", true, 4f);
	}

}
