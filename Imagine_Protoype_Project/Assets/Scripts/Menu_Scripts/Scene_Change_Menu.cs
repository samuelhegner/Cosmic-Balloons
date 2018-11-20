using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Menu : MonoBehaviour {


    public GameObject TransitionPrefab;
    
    public void StartGame() {

       // StartCoroutine(StartGameDelay());

      //  Instantiate(TransitionPrefab);
        
        Game_Manager.Instance.LoadScene("Map_Scene");


    }


    IEnumerator StartGameDelay() {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Map_Scene");
        
        
    }

}
