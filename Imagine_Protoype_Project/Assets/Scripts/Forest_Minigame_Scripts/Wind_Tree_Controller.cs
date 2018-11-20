using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wind_Tree_Controller : MonoBehaviour {

	public Transform WindZone;

	public float speed;
	public float maxAngle;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 VectorResult = WindZone.forward;
	/*	float   DotResult = Vector3.Dot(transform.forward, WindZone.forward);

		if (DotResult > 0) {
			VectorResult = transform.forward + WindZone.forward;
		} else {
			VectorResult = transform.forward -  WindZone.forward;
		}

		Debug.DrawRay(transform.position, VectorResult * 100, Color.green);*/

		if (WindZone.gameObject.active) {
			if (VectorResult.x < 0) {

				Shake("Right");

			} else {

				Shake("Left");

			}

		} else {

			Shake("NULL");
			
		}




		//	float angle = Vector3.Angle(WindZone.transform.forward, transform.position - WindZone.transform.position);

//Debug.Log(angle);
		//Debug.Log(VectorResult);



	/*	if (transform.position.x > WindZone.transform.position.x) {

			//wind is left

			if (VectorResult.x > 0) {

				//wind facing right
				
				Shake(true);
				
				
			} else {

				//wind facing left
				
				
				Shake(false);
				
			}



		} else {

			//wind is right

			if (VectorResult.x > 0) {

				//wind facing right

				Shake(true);
				
				

			} else {

				//wind facing left


				Shake(false);
				
				
				

			}
			
			
			
			
			
		}*/



	}


	void Shake(string direction) {

		Quaternion desiredRotation;

		if (direction == "Right") {

			desiredRotation = Quaternion.AngleAxis(-maxAngle, Vector3.forward);

		} else if (direction == "Left"){

			desiredRotation = Quaternion.AngleAxis(maxAngle, Vector3.forward);
			
			
		} else {

			desiredRotation = Quaternion.AngleAxis(0, Vector3.forward);
			
		}


		transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, speed * Time.deltaTime );
		
		
		
		
		
	}



}
