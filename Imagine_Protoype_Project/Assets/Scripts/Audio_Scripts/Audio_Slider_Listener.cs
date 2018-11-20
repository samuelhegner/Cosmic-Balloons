using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audio_Slider_Listener : MonoBehaviour {


     public enum Type {

          Journey,
          Sfx,
          Music


     }


     public AudioMixer MainMixer;

     public Type SliderType;

     public void ChangeVolume(float newVolume) {


          if (newVolume == GetComponent<Slider>().minValue) {

               newVolume = -80;

          }


          switch (SliderType) {

               case Type.Journey:

                    Audio_Settings_Manager.CurrrentSettings.JourneyVolume = newVolume;

                    MainMixer.SetFloat("Journey_Audio_Volume", newVolume);

                    break;

               case Type.Sfx:

                    Audio_Settings_Manager.CurrrentSettings.SfxVolume = newVolume;

                    MainMixer.SetFloat("SFX_Volume", newVolume);
                    
                    
                    break;

               case Type.Music:

                    Audio_Settings_Manager.CurrrentSettings.MusicVolume = newVolume;

                    MainMixer.SetFloat("Music_Volume", newVolume);

                    break;


          }
          
          
          //FindObjectOfType<Audio_Settings_Manager>().WriteSettings();


     }
     
     
    
     
     
}