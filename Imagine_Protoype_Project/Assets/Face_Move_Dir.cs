using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face_Move_Dir : MonoBehaviour
{
    float myX;
    	
    Vector3 movingRight;
    Vector3 movingLeft;
    void Start()
    {
        movingLeft = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        movingRight = transform.localScale;
        myX = transform.position.x;
    }

    void Update()
    {
        float lastX = transform.position.x - myX;
        myX = transform.position.x;        

        if(0 > lastX){
            //moving left
            transform.localScale = movingLeft;
        }else if(lastX > 0){
            //moving right
            transform.localScale = movingRight;
        }
    }
}
