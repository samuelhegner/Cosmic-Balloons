using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Layer_manager : MonoBehaviour {

	//public int SL;
	
	
	private GameObject[] GameObjectsToSort;

	public layerSortOnY[] LSOY;

	// Use this for initialization
	IEnumerator Start () {

		yield return null;

		//GameObjectsToSort = FindGameObjectsWithLayer(SL);

		//GameObjectsToSort = FindGameObjectsWithObject();


		LSOY = FindObjectsOfType<layerSortOnY>();

	}
	
	// Update is called once per frame
	void Update () {

		foreach (layerSortOnY LS in LSOY) {

			try {
				//GO.GetComponentInChildren<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
				
				int idealOrder = Mathf.RoundToInt(LS.transform.position.y * 100f) * -1;
				
				LS.ReorderSprites(idealOrder);
				
				
			} catch {

				
				
			}
		}




	}


	GameObject[] FindGameObjectsWithLayer(int layer){
		Renderer[] goArray = FindObjectsOfType<Renderer>();
		var goList  = new List < GameObject > ();

		for (var i = 0; i < goArray.Length; i++) {
			if (goArray[i].sortingLayerID == layer) {
				goList.Add(goArray[i].transform.root.gameObject);
			}
		}

		if (goList.Count == 0) {
			return null;
		}

		return goList.ToArray();
	}


	GameObject[] FindGameObjectsWithObject() {

		layerSortOnY[] temp = FindObjectsOfType<layerSortOnY>();

		GameObject[] tempGO = new GameObject[temp.Length];

		for (int i = 0; i < temp.Length; i++) {


			tempGO[i] = temp[i].gameObject;


		}
		
	

		return tempGO;


	}





}
