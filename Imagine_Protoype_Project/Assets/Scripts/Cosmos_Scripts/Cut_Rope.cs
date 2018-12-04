using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Rope : MonoBehaviour {
    bool cutLeft;
    bool cutRight;
    bool cutRopes;

    bool off;

    float a;

    int numberRopesCut;

    GameObject player;
    float yPos;
    float xPos;

    public float dist;

    public bool rise;

    void Start()
    {
        a = 1;
        player = GameObject.Find("Player");
        yPos = player.transform.position.y;
        xPos = player.transform.position.x;
        GetComponent<TrailRenderer>().enabled = false;
        off = true;
        rise = false;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if(Game_Manager.isPC){
            if(Input.GetMouseButton(0)){
                if(off){
                    GetComponent<TrailRenderer>().enabled = true;
                    off = false;
                }
                Vector3 placeToBe = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector3 placeToMove = new Vector3(placeToBe.x, placeToBe.y, 0);
                transform.position = placeToMove;
            }
        }else{
            if(Input.touchCount == 1){
                if(off){
                    GetComponent<TrailRenderer>().enabled = true;
                    off = false;
                }

                Touch finger = Input.GetTouch(0);

                Vector3 placeToBe = Camera.main.ScreenToWorldPoint(finger.position);

                Vector3 placeToMove = new Vector3(placeToBe.x, placeToBe.y, 0);
                transform.position = placeToMove;
            }
        }
        if(rise){
            BaloonRise();
        }
        
	}

    void LateUpdate(){
        if (numberRopesCut == 2) {
            cutRopes = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement_Cosmos>().JourneyStarted = true;
            GameObject.FindGameObjectWithTag("Ray").GetComponent<LineRenderer>().enabled = false;

            GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

            for(int i = 0; i < anchors.Length; i++){
                anchors[i].GetComponent<Destroy_Self>().enabled = true;
                for(int j = 0; j < anchors[i].transform.childCount; j++){
                    anchors[i].transform.GetChild(j).GetComponent<Destroy_Self>().enabled = true;
                }
            }


            Tutorial_Manager TM = FindObjectOfType<Tutorial_Manager>(); 
                TM.TiltPhone = true; 
            TM.StartPlayingTutorials();
            
            
            
            
            Destroy(GetComponent<TrailRenderer>());
            Destroy(this);
  
        }
    }

    void BaloonRise(){
        float xOffset;
        if(cutLeft == true){
            xOffset = 7.5f;
            dist = 8f;
        }else if(cutRight == true){
            xOffset = -7.5f;
            dist = 8f;
        }else{
            xOffset = 0f;
        }
        Vector3 goTo = new Vector3(xPos + xOffset, yPos + dist, player.transform.position.z);

        player.transform.position = Vector3.Lerp(player.transform.position, goTo, Time.fixedDeltaTime * 2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Link"){
            if (collision.transform.parent.name == "Anchor Left" && cutLeft == false)
            {
                cutLeft = true;
                numberRopesCut++;

                GetComponent<AudioManager>().Play("Cut");

            }

            if (collision.transform.parent.name == "Anchor Right" && cutRight == false)
            {
                cutRight = true;

                numberRopesCut++;

                GetComponent<AudioManager>().Play("Cut");

            }

            Destroy(collision.gameObject);
        }
    }
}
