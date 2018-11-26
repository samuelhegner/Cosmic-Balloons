using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy_Child : MonoBehaviour {
    public int index;
    public float speed;

    bool free;

    public Vector3 moveDir;

    void Start(){
        free = false;
    }

    void Update(){
        if(free == false && moveDir != Vector3.zero){
            Debug.Log("Test");
        }
        if(free){
            transform.Translate(moveDir * Time.deltaTime * speed);
        }
    }

    public void SetFree(){
        free = true;
    }
}
