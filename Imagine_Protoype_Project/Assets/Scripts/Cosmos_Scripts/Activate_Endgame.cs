using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Endgame : MonoBehaviour
{

    bool halfWay;

	GameObject player;
    GameObject beam;

    Transform[] points;
    int waypoint;
    // Use this for initialization
    void Start()
    {   
        beam = GameObject.Find("Beam");
        int count = 0; 
        for(int i = 0; i< transform.childCount; i++){
            if(transform.GetChild(i).tag == "Point"){
                count++;
            }
        }
        points = new Transform[count];

		halfWay = false;
        for (int i = 0,  k = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).tag == "Point"){
                points[k] = transform.GetChild(i);
                k++;
            }
        }
		
		player = GameObject.FindGameObjectWithTag("Player");
        
       // GetComponent<AudioManager>().Play("Beam_On");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (halfWay)
        {
			player.GetComponent<Player_Movement_Cosmos>().enabled = false;
			player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.identity, Time.deltaTime);

            player.transform.position = Vector2.MoveTowards(player.transform.position, points[waypoint].position, Time.deltaTime * player.GetComponent<Player_Movement_Cosmos>().risingSpeed);

            if(waypoint == 1){
                beam.GetComponent<Beam_Detection>().enabled = true;
            }else if(waypoint == 2){
                beam.GetComponent<Beam_Detection>().playerArrived = true;
            }

            if (waypoint < points.Length-1 && Vector2.Distance(player.transform.position, points[waypoint].transform.position) < 1f)
            {
                waypoint = (waypoint + 1);
            }
        }

		if(player.transform.position.y >= transform.position.y){
			halfWay = true;
		}
    }
}
