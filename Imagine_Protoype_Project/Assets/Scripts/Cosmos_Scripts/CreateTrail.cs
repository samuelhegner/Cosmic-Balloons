using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour
{

    public int length;
    public float distanceBetweenPoints = 10f;
    public float rangeX;
    public int smoothness;
    public float MatXScale = 1;
    public float MatYScale = 1;

    float lineWidth;

    LineRenderer rend;

    float randomXOffset;

    Vector3[] Points;

    public GameObject box;

    private void Awake()
    {
        rend = GetComponent<LineRenderer>();
        Vector3 [] TempPoints = new Vector3[length];
        for (int i = 0; i < TempPoints.Length; i++) {

            float lastX = transform.position.x;
            float firstY = transform.position.y;

            if (i == 0)
            {
                TempPoints[i] = transform.position;
            }
            else {
                randomXOffset = Random.Range(-(rangeX), (rangeX));
                TempPoints[i] = new Vector3(lastX + randomXOffset, firstY + distanceBetweenPoints * i, 0);
                lastX = TempPoints[i].x;
            }
        }

        Points = Game_Manager.MakeSmoothCurve(TempPoints, (float)smoothness);

        for (int i = 0; i < Points.Length -1; i++){
            GameObject boxTemp = Instantiate(box, Points[i], transform.rotation);
            boxTemp.transform.parent = transform;
            
            
        }

        for (int i = 0; i < transform.childCount -1 ; i++)
        {
            
            
            if(i < transform.childCount){
                Vector3 toVector = Points[i + 1] - Points[i];
                float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;
                Quaternion NewRot = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.GetChild(i).transform.rotation = NewRot;
            }
        }

        transform.GetChild(transform.childCount-1).transform.rotation = transform.GetChild(transform.childCount-2).transform.rotation;
        

        rend.positionCount = Points.Length;
        rend.SetPositions(Points);
        rend.startWidth = 5f;
        rend.endWidth = 5f;

        lineWidth = rend.startWidth;
        
       //Attempt at scaling
        rend.material.mainTextureScale = new Vector2(MatXScale,MatYScale);
    }
}