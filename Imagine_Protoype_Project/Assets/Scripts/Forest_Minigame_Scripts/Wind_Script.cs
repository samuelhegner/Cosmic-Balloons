using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Script : MonoBehaviour {

	private void OnEnable() {
		AudioManager.Master.Play("Wind", true, 0.5f);
	}

	private void OnDisable() {
		AudioManager.Master.Stop("Wind", true, 1f);
	}

}
