using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Raycast_Animation_Trigger : MonoBehaviour {


	private List<Animator> heldAnimators = new List<Animator>();
	
	
	private void Update() {
		if (Input.GetMouseButtonDown(0)) {

AttemptTrigger();
			
			
		}

		if (Input.touchCount == 1) {

			if (Input.GetTouch(0).phase == TouchPhase.Began) {

				AttemptTrigger();
				
			}

		}

	}


	void AttemptTrigger() {

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {

			if (hit.collider.gameObject.CompareTag("Map_Interactable")){


				hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Animate");
				hit.collider.gameObject.GetComponent<Animator>().SetBool("Held", true);
heldAnimators.Add(hit.collider.gameObject.GetComponent<Animator>());
				
				
				
			}


		}



	}

	private void OnMouseUp() {

		foreach (Animator A in heldAnimators) {
			A.SetBool("Held", false);
			
			
		}
		
		
		heldAnimators.Clear();
		
		
	}


}
