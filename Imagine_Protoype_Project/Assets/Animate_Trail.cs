using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_Trail : MonoBehaviour
{

    Gradient grad;

    void Start()
    {
        grad = GetComponent<LineRenderer>().colorGradient;
    }

    void Update()
    {
        
    }
}
