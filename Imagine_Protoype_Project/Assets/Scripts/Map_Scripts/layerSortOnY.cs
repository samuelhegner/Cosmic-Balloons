using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerSortOnY : MonoBehaviour {

	public SpriteRenderer[] SpritesToOrder;

	public bool SortOnUpdate;

	public void ReorderSprites(int order) {

		for (int i = 0; i < SpritesToOrder.Length; i++) {

			SpritesToOrder[i].sortingOrder = order - i;



		}


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
