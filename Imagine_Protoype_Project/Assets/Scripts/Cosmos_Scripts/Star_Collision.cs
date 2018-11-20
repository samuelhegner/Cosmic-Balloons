using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Collision : MonoBehaviour {
    public Animator anim;
    private bool starHit = false;
    public GameObject starEmitterParent;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (starHit == true)
		{
            starEmitterParent.SetActive(true);

		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            starHit = true;
            
            int ran = Random.Range(0, 2);

            if (ran < 1f)
            {
                anim.SetTrigger("CollisionRight");
            }
            else {
                anim.SetTrigger("CollisionLeft");
            }
            StartCoroutine(KillGameObject());
        }
    }

    IEnumerator KillGameObject() {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    } 
}
