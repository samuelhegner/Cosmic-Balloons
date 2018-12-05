using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Sprite : MonoBehaviour
{

    public float rotateSpeed;
    // Start is called before the first frame update
    void Awake()
    {

        int ran = Random.Range(0, 2);
        if (ran < 1)
        {
            rotateSpeed *= -1;
        }
        else
        {
            rotateSpeed *= 1;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( (Vector3.forward * rotateSpeed));   
    }
}
