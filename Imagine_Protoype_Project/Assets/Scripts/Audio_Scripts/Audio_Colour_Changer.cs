using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Colour_Changer : MonoBehaviour {

     public Color Primary;
     public Color Secondary;

[Header("Images")]
     public Image[] PrimaryImages;
     public Image[] SecondaryImages;


     void Start() {

          foreach (Image I in PrimaryImages) {

               I.color = Primary;

          }

          foreach (Image I in SecondaryImages) {

               I.color = Secondary; 

          }
          
          
          
     }


}
