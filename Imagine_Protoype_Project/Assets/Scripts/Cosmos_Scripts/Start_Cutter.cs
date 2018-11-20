using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Cutter : MonoBehaviour {

	public GameObject cutter;
	public bool start;

	// Use this for initialization
	void Start () {
		start = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(start){
			cutter.SetActive(true);
			Destroy(this);
		}
	}
}
