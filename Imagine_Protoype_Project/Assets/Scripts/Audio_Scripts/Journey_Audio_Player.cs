using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(AudioManager))]
public class Journey_Audio_Player : MonoBehaviour {

     public string CurrentJourneyName;
     public bool PlayJourneyOnAwake = false; 

     [HideInInspector]
public bool playing;

     private bool hidden = true;

     private AudioManager _audioManager;

     private Animator _animator;


     public Sprite PauseButton;
     public Sprite PlayButton;

     public Image PausePlayButton;

     [Space] public Sprite UpArrow;
     public Sprite DownArrow;

     public Image Arrow; 
     
[Space]
     public GameObject EndSceneUI;

   //  public EventSystem ES;

     void Start() {


          _audioManager = GetComponent<AudioManager>();
          _animator = GetComponent<Animator>();

          if (PlayJourneyOnAwake) {

               PlayJourney();
               
          }

          // soundInfo SI = _audioManager.GetSoundData(CurrentJourneyName);

          



     }


     public void PlayJourney() {

          if (!playing) {
               _audioManager.Play(CurrentJourneyName, true, 2f);
               playing = true;

               StartCoroutine(waitForEndOfJourney());

          }

     }

     IEnumerator waitForEndOfJourney() {


         // while (true) {
               while (playing) {


yield return new WaitForSeconds(0.5f);

                    soundInfo SI = _audioManager.GetSoundData(CurrentJourneyName);

                    if (SI.currentTime >= SI.length * 0.99f) {


                         EndSceneUI.SetActive(true);

                    }


               }
       //   }

     }


     public void TogglePause() {

          if (playing) {

               _audioManager.Pause(CurrentJourneyName);

               PausePlayButton.sprite = PlayButton;


          } else {

               _audioManager.Play(CurrentJourneyName);
               PausePlayButton.sprite = PauseButton;
               
               
          }

          playing = !playing;
          
          
          
          
          
          


     }


     public void StopAudio() {

          _audioManager.Stop(CurrentJourneyName);

          playing = false;

     }


     public void ToggleMenu() {


          hidden = !hidden;
          
          _animator.SetBool("Hidden", hidden);

          if (!hidden) {
               
               GetComponent<AudioManager>().Play("Open");

               StartCoroutine(AutoHide(4f));

               //Arrow.sprite = UpArrow;

          } else {

               GetComponent<AudioManager>().Play("Close");

              // Arrow.sprite = DownArrow;
               

          }

          GetComponent<Audio_Settings_Manager>().WriteSettings();


     }
     
     
     
    


     public void ReturnToMap() {

          Game_Manager.Instance.LoadScene("Map_Scene");
          
          //SceneManager.LoadScene("Map_Scene");
          
     }


     IEnumerator AutoHide(float time) {

          while (time > 0) {


            //  if (ES.isFocused) {
                //    time = 4f;

             // }

               time -= Time.deltaTime;

               yield return null;

               if (hidden) {

                    yield break;
                    
               }

          }
          
          
//ToggleMenu();
          
          

     }



}
