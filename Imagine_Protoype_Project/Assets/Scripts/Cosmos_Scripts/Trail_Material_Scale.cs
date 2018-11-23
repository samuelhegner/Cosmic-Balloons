using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail_Material_Scale : MonoBehaviour
{
    private LineRenderer myLine;
    
    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector3.Distance(transform.position)
    }
}
