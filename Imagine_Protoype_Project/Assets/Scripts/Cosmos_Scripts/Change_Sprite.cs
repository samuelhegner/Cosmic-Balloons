using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Sprite : MonoBehaviour {

	//public Sprite[] sprites = new Sprite[3];
	public GameObject[] prefab;
	// Use this for initialization
	void Awake () {
		int ran = Random.Range(0, prefab.Length);

		/*GetComponent<SpriteRenderer>().sprite = sprites[ran];*/
		PolygonCollider2D col = gameObject.AddComponent<PolygonCollider2D>();
		col.isTrigger = true;

		
		//Disabled due to repeated error
	Instantiate(prefab[ran], transform.position, transform.rotation);
	}
}
