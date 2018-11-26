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
    public GameObject pin;



    GameObject player;

    public Vector3 above;
    public Vector3 below;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        loadScene = false;
        above = new Vector3(pin.transform.position.x, popUp.transform.position.y, 0);
        below = new Vector3(pin.transform.position.x, popUp.transform.position.y - offset, 0);

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
            if (player.transform.position.y > pin.transform.position.y)
            {
                //player is above the pin
                popUp.GetComponent<RectTransform>().position = Vector3.Lerp(popUp.GetComponent<RectTransform>().position, above, Time.deltaTime * popupSpeed);
            }
            else
            {
                popUp.GetComponent<RectTransform>().position = Vector3.Lerp(popUp.GetComponent<RectTransform>().position, below, Time.deltaTime * popupSpeed);
            }
        }
    }

    public void SelectTheSite()
    {
        showing = true;
        popUp.SetActive(showing);
        player.GetComponent<Player_Movement_Map>().SetActiveSite(transform.parent.gameObject.name);

        if (player.transform.position.y > pin.transform.position.y)
        {
            //player is above the pin
            popUp.GetComponent<RectTransform>().position = above;
        }
        else
        {
            popUp.GetComponent<RectTransform>().position = below;
        }
    }

    public void TurnOffPopUp()
    {
        showing = false;
        popUp.SetActive(showing);
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
