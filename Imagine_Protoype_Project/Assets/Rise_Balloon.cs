using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise_Balloon : MonoBehaviour
{

    public Cut_Rope cutter;
    public bool leggo = false;

    // Start is called before the first frame update
    public void Update(){
        if(leggo){
            cutter.rise = true;
            leggo = false;
        }
    }
}
