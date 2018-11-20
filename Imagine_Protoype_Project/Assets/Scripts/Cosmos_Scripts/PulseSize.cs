using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseSize : MonoBehaviour {

    public float maxSize = 2.0f;
    public float minSize = 0.2f;
    public float speed = 1.0f;

    void Update()
    {
        var range = maxSize - minSize;
        transform.localScale = new Vector3 (minSize + Mathf.PingPong(Time.time * speed, range), minSize + Mathf.PingPong(Time.time * speed, range), 0);
    }
}
