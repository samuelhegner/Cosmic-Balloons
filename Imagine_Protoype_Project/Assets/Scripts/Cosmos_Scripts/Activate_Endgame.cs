using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Activate_Endgame : MonoBehaviour
{

    bool fade;
    bool halfWay;

    bool setTime;

    public float fadeTime;
    float startTime;

    public Image fadeImage;

	private bool _tutorialTriggered = false; 

    bool _AudioTriggered = false;

    bool _GetRidOfObjects = false;

    public float startAudioSeconds;

     public AudioManager AM;
    

	GameObject player;
    GameObject beam;

    Transform[] points;
    int waypoint;
    // Use this for initialization
    void Start()
    {   
        // beam = GameObject.Find("Beam");
        // int count = 0; 
        // for(int i = 0; i< transform.childCount; i++){
        //     if(transform.GetChild(i).tag == "Point"){
        //         count++;
        //     }
        // }
        // points = new Transform[count];

		// halfWay = false;
        // for (int i = 0,  k = 0; i < transform.childCount; i++)
        // {
        //     if(transform.GetChild(i).tag == "Point"){
        //         points[k] = transform.GetChild(i);
        //         k++;
        //     }
        // }
		
		player = GameObject.FindGameObjectWithTag("Player");
        fade = false;
        setTime = false;
        
       // GetComponent<AudioManager>().Play("Beam_On");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (halfWay)
        // {
		// 	player.GetComponent<Player_Movement_Cosmos>().enabled = false;
		// 	player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		// 	player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.identity, Time.deltaTime);

        //     player.transform.position = Vector2.MoveTowards(player.transform.position, points[waypoint].position, Time.deltaTime * player.GetComponent<Player_Movement_Cosmos>().risingSpeed);

        //     if(waypoint == 1){
        //         beam.GetComponent<Beam_Detection>().enabled = true;
        //     }else if(waypoint == 2){
        //         beam.GetComponent<Beam_Detection>().playerArrived = true;
        //     }

        //     if (waypoint < points.Length-1 && Vector2.Distance(player.transform.position, points[waypoint].transform.position) < 1f)
        //     {
        //         waypoint = (waypoint + 1);
        //     }
        // }

		if(player.transform.position.y >= transform.position.y - gameObject.GetComponent<Set_Position>().yBuffer){
			fade = true;
            if(setTime == false){
                startTime = Time.time;
                setTime = true;

                 GameObject.Find("Player").GetComponent<AudioManager>().Stop("Flame_Mid", true, 3f);
                 
            }
		}

        if(fade){
            if(fadeImage.color.a < 1f){
                float t = (Time.time - startTime) / fadeTime;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.SmoothStep(0, 1, t));
            } else {
                 
                 

	            if (!_tutorialTriggered) {

		            _tutorialTriggered = true;

		            Tutorial_Manager TM = FindObjectOfType<Tutorial_Manager>();
		            TM.TiltPhone = false;
		            TM.CloseEyes = true; 
		            TM.StartPlayingTutorials();
	            }

                if(!_AudioTriggered){
                    _AudioTriggered = true;

                    Invoke("StartAudio", startAudioSeconds);
                }

                if(!_GetRidOfObjects){
                    _GetRidOfObjects = true;

                    Invoke("TurnOffObj", startAudioSeconds + 1f);
                }
            }
        }
    }

    void StartAudio(){
        // the place to start the audio
        Game_Manager.Instance.LoadScene("Map_Scene");
         //FindObjectOfType<Journey_Audio_Player>().PlayJourney();
         
         AM.Stop("Balloon_Rise_Music", true, 3f);

    }

    void TurnOffObj(){
        GameObject[] objToTurnOff = GameObject.FindGameObjectsWithTag("Parent");

        foreach(GameObject obj in objToTurnOff){
            Destroy(obj);
        }

        Camera.main.GetComponent<Follow_Player_Camera>().enabled = false;

        GameObject player = GameObject.Find("Player");
        Destroy(player);
        Destroy(this.gameObject);
    }
}
