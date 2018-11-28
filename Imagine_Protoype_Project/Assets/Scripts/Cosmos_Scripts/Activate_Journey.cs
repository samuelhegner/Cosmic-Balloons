using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Journey : MonoBehaviour {

    Camera cam;
    GameObject player;
    Animator anim;

    private AudioManager AM;
    
    public GameObject Player;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = cam.GetComponent<Animator>();
	     AM = GetComponent<AudioManager>();

	}

    void OnMouseDown()
    {
        anim.SetTrigger("Start");
        StartCoroutine("StopAnimation");
        transform.GetChild(0).GetComponent<DrawRay>().drawLine = true;
        AM.Play("Activate_Journey");
        AM.Play("Beam", true, 0.5f, 0.15f);
        AM.Stop("Wobble", true, 1f, 0.5f);
        Debug.Log("Begining Journey");
        
        
        
    }

    IEnumerator StopAnimation() {
        yield return new WaitForSeconds(3.1f);
        cam.GetComponent<Animator>().enabled = false;
        cam.GetComponent<Follow_Player_Camera>().enabled = true;
        
        Player.GetComponent<AudioManager>().Play("Flame_Mid");
       AM.Stop("Beam", true, 0.5f, 0.15f);
        
        
        
    }
}
