using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Transitioner_Script : MonoBehaviour {

	[Range(-80,1)]
	public float masterVol = 1;

	public AudioMixer AMG;
	
	// Use this for initialization
	void Start () {
		
		
		DontDestroyOnLoad(gameObject);
		
		
		
		
		
	}
	
	// Update is called once per frame

	public void KillMe() {

		Destroy(gameObject);
		
	}

	private void Update() {


		AMG.SetFloat("Master", masterVol);

	}


	void OnEnable() {
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		Debug.Log("Level Loaded: " + scene.name);


		GetComponent<Animator>().SetTrigger("TransIn");
		
	}

}
