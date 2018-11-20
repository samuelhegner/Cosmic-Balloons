using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Info : MonoBehaviour {

    LineRenderer rend;

    float width = 0.1f;


    public GameObject PreviousPoint;


	// Use this for initialization
	void Start () {
        rend = GetComponent<LineRenderer>();
        //Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        //rend.material = whiteDiffuseMat;
        rend.startWidth = width;
        rend.endWidth = width;
    }
	
	// Update is called once per frame
	void Update () {


        if (PreviousPoint == null)
        {
            Destroy(GetComponent<LineRenderer>());
        }
        else {
            rend.positionCount = 2;
            rend.SetPosition(0, transform.position);
            rend.SetPosition(1, PreviousPoint.transform.position);
        }
	}
}
