using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;


public class Map_Load_Manager : MonoBehaviour {



	void Start() {

		if (SceneManager.GetActiveScene().name == "Map_Scene") {
			//gameObject.hideFlags = HideFlags.DontSaveInBuild;
		}

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
//		Debug.Log("Level Loaded: " + scene.name);
	//	Debug.Log(scene.name);
		//Debug.Log(mode);
		
		
		CheckMap();
	}
	
	
	
	
	
	
	private void CheckMap() {
		
		//Debug.Log("Start triggered");
		
		DontDestroyOnLoad(gameObject);
		

		string currentSceneName = SceneManager.GetActiveScene().name;

		if (currentSceneName == "Map_Scene") {

			
			transform.GetChild(0).gameObject.SetActive(true);
			
			
			
		} else {

			transform.GetChild(0).gameObject.SetActive(false);
			
			
		}



	}

	
	
}
