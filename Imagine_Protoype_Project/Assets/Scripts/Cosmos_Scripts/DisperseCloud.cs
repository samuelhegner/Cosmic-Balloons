using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisperseCloud : MonoBehaviour {

    bool finished;
    private bool played;

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 6f;
    private float startTime;
    private ParticleSystem part;
    private ParticleSystem.MainModule mm;

    public SpriteRenderer sprite;

    private void Awake()
    {
        finished = true;
        part = GetComponent<ParticleSystem>();
        mm = part.main;
        played = false;
    }

    private void Update()
    {
        if (!finished) {
            FadeSprite();
            if (sprite.color.a == 0) {
                finished = true;
                Invoke("DestroyObj", mm.duration);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player" && played == false) {
            Puff();
            played = true;

        }
    }

    void Puff() {
        ParticleSystem part = GetComponent<ParticleSystem>();
        startTime = Time.time;
        part.Play();
        finished = false;
        
        GetComponent<AudioManager>().Play("Puff");
        
        
    }

    void FadeSprite() {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    } 
}