using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Info : MonoBehaviour {

    LineRenderer rend;

    public float width = 0.5f;


    public GameObject PreviousPoint;


	// Use this for initialization
	void Start () {
        rend = GetComponent<LineRenderer>();
        //Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        //rend.material = whiteDiffuseMat;

    }
	
	// Update is called once per frame
	void Update () {
        rend.startWidth = width;
        rend.endWidth = width;

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
