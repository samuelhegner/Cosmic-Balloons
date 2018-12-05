using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSwitch : MonoBehaviour {

     public RectTransform Button;

     private RectTransform _thisRectTransform;

     private void Start() {
          _thisRectTransform = GetComponent<RectTransform>();
     }

     public void ToggleTutorials(bool b) {


          Audio_Settings_Manager.CurrrentSettings.ShowTutorials = b;

          if (b) {

               Button.SetAsFirstSibling();

          } else {

               Button.SetAsLastSibling();
               
          }


     }
     
     
     
     
}
