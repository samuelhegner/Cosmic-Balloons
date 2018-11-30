using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


            }
        }
    }
}
