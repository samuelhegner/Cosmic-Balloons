using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Self : MonoBehaviour
{

    LineRenderer rend;
    SpriteRenderer rendS;

    void Start()
    {
        if (gameObject.GetComponent<LineRenderer>() != null)
        {
            rend = GetComponent<LineRenderer>();
        }

        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            rendS = GetComponent<SpriteRenderer>();
        }
        StartCoroutine(Fade());
    }

    float alpha = 1;

    IEnumerator Fade()
    {
        if (transform.tag == "Link")
        {
            while (alpha > 0.05f)
            {

                alpha -= 0.1f * Time.deltaTime;
                Color col = new Color(1, 1, 1, alpha);
                if (rend != null)
                {
                    rend.startColor = col;
                    rend.endColor = col;
                }
                yield return null;
            }

        }
        else
        {
            while (alpha > 0.05f)
            {
                alpha -= 0.1f * Time.deltaTime;
                Color col = new Color(1, 1, 1, alpha);
                rendS.color = col;
                rendS.color = col;
                yield return null;
            }
        }

        Destroy(gameObject);
    }
}
