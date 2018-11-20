using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRope : MonoBehaviour {

    LineRenderer renderer;
    Vector3 lastPos;

    public float width;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<LineRenderer>();
        lastPos = transform.position;
        
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        renderer.material = whiteDiffuseMat;
        renderer.startWidth = width;
        renderer.endWidth = width;
    }
	
	// Update is called once per frame
	void Update () {
        renderer.positionCount = transform.childCount + 1;
        for (int i = 0; i <= transform.childCount; i++) {
            renderer.SetPosition(i, lastPos);
            if (i < renderer.positionCount - 1) {
                lastPos = transform.GetChild(i).transform.position;
            }
        }
    }
}
