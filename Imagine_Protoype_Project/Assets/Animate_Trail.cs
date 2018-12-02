using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_Trail : MonoBehaviour
{
    public float changeRate;
    Gradient grad;

    LineRenderer lr;

    GradientColorKey[] ck = new GradientColorKey[2]{
        new GradientColorKey(new Color(1, 1, 1), 0f)
        ,new GradientColorKey(new Color(1, 1, 1), 1f)
        };
    List<GradientAlphaKey> ak = new List<GradientAlphaKey>();

    void Start()
    {
        lr = GetComponent<LineRenderer>();

        
        float percent = 1f/8f;

        for(int i = 0; i < 8; i++){
            GradientAlphaKey nk = new GradientAlphaKey(percent, percent);
            ak.Add(nk);
            percent += (1f/8f);
        }


        // GradientAlphaKey nk1 = new GradientAlphaKey(0.5f, 0);
        // GradientAlphaKey nk2 = new GradientAlphaKey(1, 0.05f);
        // GradientAlphaKey nk3 = new GradientAlphaKey(0.5f, 1f);

        // ak.Add(nk1);
        // ak.Add(nk2);
        // ak.Add(nk3);

        grad = new Gradient();
        grad.SetKeys(ck, ak.ToArray());

        lr.colorGradient = grad;
        InvokeRepeating("SwitchAlpha", 0f, changeRate);
    }

    void Update()
    {
        // float p = lr.colorGradient.alphaKeys[1].time;
        // print(lr.colorGradient.alphaKeys[1].time);
        
        // if(p > 0.95f){
        //     p = 0.05f;
        // }

        // p += changeRate *Time.deltaTime;

        // ak[1] = new GradientAlphaKey(1f, p);

        
        // Gradient newGrad = new Gradient();
        // newGrad.SetKeys(ck, ak.ToArray());
        
        // //grad.SetKeys(ck, ak.ToArray());
        // lr.colorGradient = newGrad;

        // print(lr.colorGradient.alphaKeys[1].time);
    }

    void SwitchAlpha(){


        float firstValue = 0;
        for(int i = 7; i >= 0; i--){
            if(i == 7){
                firstValue = lr.colorGradient.alphaKeys[i].alpha;
                float nextValue = lr.colorGradient.alphaKeys[i-1].alpha;
                ak[i] = new GradientAlphaKey(nextValue, lr.colorGradient.alphaKeys[i].time);
            }else if(i > 0){
                float nextValue = lr.colorGradient.alphaKeys[i-1].alpha;
                ak[i] = new GradientAlphaKey(nextValue, lr.colorGradient.alphaKeys[i].time);
            }else{
                ak[i] = new GradientAlphaKey(firstValue, lr.colorGradient.alphaKeys[i].time);
            }
        }
        grad.SetKeys(ck, ak.ToArray());
        lr.colorGradient = grad;
    }
}
