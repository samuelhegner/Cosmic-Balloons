using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Site : MonoBehaviour
{

    bool showing;

    public bool loadScene;

    public float popupSpeed;
    float offset;

    public float minOff;
    public float maxOff;

    public GameObject popUp;
    public GameObject top;

    float topStartY;

    public Camera cam;

    Vector3 abovePopUp;
    Vector3 belowPopUp;

    Animator anim;

    Pinch_Zoom_Camera pinch;




    GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        loadScene = false;
        anim = GetComponent<Animator>();
        abovePopUp = popUp.transform.position;
        pinch = cam.GetComponent<Pinch_Zoom_Camera>();
    }

    void Update()
    {
        offset = Game_Manager.Map(cam.orthographicSize, pinch.minZoom, pinch.maxZoom, minOff, maxOff);
        topStartY = top.transform.position.y;

        belowPopUp = new Vector3(abovePopUp.x, abovePopUp.y - offset, abovePopUp.z);
        
        if (loadScene)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 1f)
            {   
                Game_Manager.SavePlayerPos(transform.position);
                transform.GetComponent<Site_Info>().LoadCorrespondingScene();
            }
        }

        if (showing)
        {
            
            Vector3 topScreen = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 0));

            float topScreenY = topScreen.y + Game_Manager.Map(offset, minOff, maxOff, 5f, 45f);


            if(topStartY > topScreenY)
            {
                popUp.transform.position = belowPopUp;
            }else{
                popUp.transform.position = abovePopUp;
            }
        }
    }

    public void SelectTheSite()
    {
        showing = true;
        popUp.SetActive(showing);
        player.GetComponent<Player_Movement_Map>().SetActiveSite(transform.gameObject.name);
    }

    public void TurnOffPopUp()
    {
        showing = false;
        popUp.SetActive(showing);
        popUp.transform.position = abovePopUp;

        if(anim != null)
        anim.SetBool("Picked", false);
    }

    public void MoveToSite()
    {
        player.GetComponent<Player_Movement_Map>().location = transform.position;
        player.GetComponent<Player_Movement_Map>().SetMoveSpeed(6, player.GetComponent<Player_Movement_Map>().MaxSpeed, transform.position, player.transform.position);
        player.GetComponent<Player_Movement_Map>().DropFlag();

        if(anim != null)
        anim.SetBool("Picked", true);
        

        if (GetComponent<Site_Info>().sceneName != null)
        {
            loadScene = true;
        }
    }
}
