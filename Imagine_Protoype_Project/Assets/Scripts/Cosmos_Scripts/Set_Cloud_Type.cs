using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Cloud_Type : MonoBehaviour {

	public GameObject[]pref;
	void Awake () {
		int ran = Random.Range(0, 3);
		Instantiate(pref[ran], transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
