using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Script : MonoBehaviour {


	public AudioManager AM; 
	
	private void OnEnable() {
		AM.Play("Wind", true, 0.8f, 0.8f);
	}

	private void OnDisable() {
		AM.Stop("Wind", true, 1.4f);
	}

}
