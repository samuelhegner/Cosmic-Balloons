using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
		Game_Manager.Instance.LoadScene("Menu_Scene");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
