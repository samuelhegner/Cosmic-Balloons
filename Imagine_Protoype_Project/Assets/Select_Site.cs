using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Site : MonoBehaviour
{

    bool showing;

    public bool loadScene;

    public float popupSpeed;
    public float offset;

    public GameObject popUp;
    public GameObject top;

    float topStartY;

    public Camera cam;

    Vector3 abovePopUp;
    Vector3 belowPopUp;




    GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        loadScene = false;
        topStartY = top.transform.position.y;
        abovePopUp = popUp.transform.position;
        belowPopUp = new Vector3(abovePopUp.x, abovePopUp.y - offset, 0);
    }

    void Update()
    {
        if (loadScene)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 1f)
            {
                transform.GetComponent<Site_Info>().LoadCorrespondingScene();
            }
        }

        if (showing)
        {
            Vector3 topScreen = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 0));

            float topScreenY = topScreen.y;


            if(topStartY>= topScreenY)
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
        player.GetComponent<Player_Movement_Map>().SetActiveSite(transform.parent.gameObject.name);
    }

    public void TurnOffPopUp()
    {
        showing = false;
        popUp.SetActive(showing);
        popUp.transform.position = abovePopUp;
    }

    public void MoveToSite()
    {
        player.GetComponent<Player_Movement_Map>().location = transform.position;
        player.GetComponent<Player_Movement_Map>().SetMoveSpeed(6, player.GetComponent<Player_Movement_Map>().MaxSpeed, transform.position, player.transform.position);
        player.GetComponent<Player_Movement_Map>().DropFlag();


        if (GetComponent<Site_Info>().sceneName != null)
        {
            loadScene = true;
        }
    }
}
