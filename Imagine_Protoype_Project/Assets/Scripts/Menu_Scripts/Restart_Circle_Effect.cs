using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_Circle_Effect : MonoBehaviour
{
    public float waitTime = 0;
    public float delay;
    private ParticleSystem ps;
    private float timeremaining;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        timeremaining = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        var emission = ps.emission;
        
        if (delay < 0)
        {
            
            timeremaining -= Time.deltaTime;
            emission.enabled = true;
        
            if (timeremaining < 0)
            {
                ps.Play();
                timeremaining = waitTime;
            } 
        }
        
       
    }
}
