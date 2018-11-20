using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Site_Info : MonoBehaviour {

    public enum TypeOfSite {
        Sacred,
        Regional
    }

    public TypeOfSite site;


    public string sceneName;

    bool loadedOnce;

    void Start(){
        loadedOnce = false;
    }


    public void LoadCorrespondingScene() {
       // SceneManager.LoadScene(sceneName);
       if(loadedOnce == false){
            Game_Manager.Instance.LoadScene(sceneName);
            loadedOnce = true;
       }
       
    }
}
