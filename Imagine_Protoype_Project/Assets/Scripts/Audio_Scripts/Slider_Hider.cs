using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Hider : MonoBehaviour {

	public GameObject Slider;
	
	// Use this for initialization
	void Start () {

		if (Game_Manager.isPC) {

			Slider.SetActive(true);
		} else {
		Slider.SetActive(false);
		
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
