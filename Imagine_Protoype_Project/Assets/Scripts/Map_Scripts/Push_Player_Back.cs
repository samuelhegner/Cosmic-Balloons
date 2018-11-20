using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Player_Back : MonoBehaviour
{

    float xPush;
    float yPush;

    public float pushBackDist;
    public float speed;

    GameObject player;

    Vector2 traget;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        string name = gameObject.name;

        if (name == "North")
        {
            yPush = -pushBackDist;
            xPush = 0;
        }
        else if (name == "South")
        {
            yPush = pushBackDist;
            xPush = 0;

        }
        else if (name == "West")
        {
            xPush = pushBackDist;
            yPush = 0;
        }
        else if (name == "East")
        {
            xPush = -pushBackDist;
            yPush = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player_Movement_Map>().enabled = false;
            traget = SetPushBackPoint();
            transform.GetChild(0).GetComponent<Move_Clouds>().ResetTimer();
            StartCoroutine(MoveThePlayerBack());
        }
    }

    Vector2 SetPushBackPoint()
    {
        Vector2 point = new Vector2(player.transform.position.x + xPush, player.transform.position.y + yPush);
        return point;
    }

    IEnumerator MoveThePlayerBack()
    {
        bool done = false;
        while (done == false)
        {
            player.transform.position = Vector2.Lerp(player.transform.position, traget, Time.deltaTime * speed);
            if (Vector2.Distance(player.transform.position, traget) > 1f)
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                done = true;
                player.GetComponent<Player_Movement_Map>().enabled = true;
                player.GetComponent<Player_Movement_Map>().ResetLocation();
            }
        }
    }
}
