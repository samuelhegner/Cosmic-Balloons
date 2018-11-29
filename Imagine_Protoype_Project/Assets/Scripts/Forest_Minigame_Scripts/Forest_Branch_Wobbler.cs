using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Branch_Wobbler : MonoBehaviour {

	 GameObject Wind;

	private bool wobbling;

	public float MinA, MaxA;

	public float speed;

	private Quaternion _desiredRotation;
	
	// Use this for initialization
	void Start () {
	//	yield return null;

		Wind = FindObjectOfType<Forest_Touch_Manager>().Wind.gameObject;

		if (Wind == null) {

			DestroyImmediate(gameObject);
			
		}

		StartCoroutine(Wobble());


	}
	
	// Update is called once per frame
	void Update () {


		if (Wind.active) {

			wobbling = true;


			transform.localRotation = Quaternion.Lerp(transform.localRotation, _desiredRotation, speed * Time.deltaTime);


		} else {

			wobbling = false;

		}


	}


IEnumerator Wobble() {

	while (true) {

		if (wobbling) {

			 _desiredRotation = Quaternion.AngleAxis(Random.Range(MinA, MaxA), Vector3.forward);
			
			
			
			


		}
		
		
		yield return new WaitForSeconds(0.1f);


	}




}
	
	


}
