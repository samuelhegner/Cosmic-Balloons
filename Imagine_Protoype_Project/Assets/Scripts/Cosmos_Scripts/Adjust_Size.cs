using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Size : MonoBehaviour {
	GameObject parent;
	
	BoxCollider2D col;

	public float height;
    public float buffer;
	int lastSeg;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
		col = GetComponent<BoxCollider2D>();

		lastSeg = parent.GetComponent<CreateTrail>().smoothness * parent.GetComponent<CreateTrail>().length;
		

		if(parent.transform.childCount == 1){
			StartCoroutine(GetHeight());
		}else if(parent.transform.childCount < lastSeg){
			height = Vector2.Distance(parent.transform.GetChild(0).transform.position, parent.transform.GetChild(1).transform.position) + buffer;
		}else if(parent.transform.childCount == lastSeg){
			height = parent.transform.GetChild(lastSeg-2).GetComponent<Adjust_Size>().height;
			transform.rotation = parent.transform.GetChild(lastSeg-2).transform.rotation;
		}

		float width = parent.GetComponent<LineRenderer>().startWidth;
		Vector2 reSize = new Vector2(height, width);
		col.size = reSize;
	}


	IEnumerator GetHeight(){
		yield return new WaitForEndOfFrame();
		height = parent.transform.GetChild(1).GetComponent<Adjust_Size>().height;
	}
}
