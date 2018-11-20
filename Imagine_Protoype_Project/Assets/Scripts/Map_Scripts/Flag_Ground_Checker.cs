using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Ground_Checker : MonoBehaviour {

     public RenderTexture RT;

     public Color col;

     [Range(0f,360f)]
     public float MinHue;

     [Range(0f, 360f)]
     public float MaxHue;


     public GameObject GroundObject;
     public GameObject WaterObject;

     [Header("Shake")] public float Magnitude;
     public float Roughness;
     public float Time = 0.5f;
     

    public enum Terrain {

          Ground,
          Water
          
     }

     public Terrain State;

     public void CompareColours() {

          Texture2D texture = new Texture2D(1,1, TextureFormat.RGB24, false);

          RenderTexture.active = RT;
          
          texture.ReadPixels(new Rect(0, 0, 1,1), 0, 0);
          texture.Apply();


          col = texture.GetPixel(0, 0);

          float h, s, v;
          
          Color.RGBToHSV(col, out h, out s, out v);


          

          h *= 360;

          //Debug.Log(h);
          
          
          if (h > MinHue && h < MaxHue) {

               //Debug.Log("Sploosh");

               State = Terrain.Water;

          } else {

               //Debug.Log("Thud");

               State = Terrain.Ground;
          }


          //texture.ReadPixels(RectReadPicture, 0, 0);
          //  texture. = RT; 



     }



     public void ChangeFooting() {


          EZCameraShake.CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, 0, Time);

          
          GroundObject.SetActive(false);
          WaterObject.SetActive(false);


          switch (State) {

               
               case (Terrain.Ground) :


                    GroundObject.SetActive(true);
                    GetComponent<AudioManager>().Play("Flag_Hit");
                    
                    
                    break;
               
               case (Terrain.Water):
                    
                    
                    WaterObject.SetActive(true);
                    GetComponent<AudioManager>().Play("Flag_Splash");
                    

                    break;
               
               
               
          }



     }




}
