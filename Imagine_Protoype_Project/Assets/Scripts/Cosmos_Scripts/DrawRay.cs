using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour {

    bool mid;

    LineRenderer rend;

    public GameObject BalloonPoint;
    public GameObject Prism;
    public float startW, endW;

    Vector3 midPoint;

    Vector3 endPoint;

    public float lightSpeed;

    public bool drawLine;

	// Use this for initialization
	void Start () {
        rend = GetComponent<LineRenderer>();
        //Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        //rend.material = whiteDiffuseMat;
        rend.positionCount = 3;
        drawLine = false;
        midPoint = transform.position;
        endPoint = transform.position;
        mid = false;
    
    }

    // Update is called once per frame
    void Update () {


        rend.startWidth = startW;
        rend.endWidth = endW;
        Vector3[] positions = new Vector3[] {
            transform.position,
            midPoint,
            endPoint
             };

        if (drawLine) {
            rend.SetPositions(positions);
            if (mid == false)
            {
                midPoint = Vector3.MoveTowards(midPoint, Prism.transform.position, Time.deltaTime * lightSpeed);
                if (Vector3.Distance(midPoint, Prism.transform.position) < 0.1)
                {
                    midPoint = Prism.transform.position;
                    endPoint = Prism.transform.position;
                    mid = true;
                }
            }
            else if (mid == true)
            {
                endPoint = Vector3.MoveTowards(endPoint, BalloonPoint.transform.position, Time.deltaTime * lightSpeed);
            }
        }

        
	}
}
