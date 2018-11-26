using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy_Start : MonoBehaviour {

    Vector3[] setPos;

    public float speed = 20f;
	public float x_left = -20f;
	public float x_right = 20f;
	public float y_down = 10f;
	public float y_up = 50f;



    bool start;

    // Use this for initialization
    void Awake () {
        for (int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).gameObject.AddComponent<Galaxy_Child>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(start){
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject current = transform.GetChild(i).gameObject;
                current.transform.position = Vector3.MoveTowards(current.transform.position, setPos[current.GetComponent<Galaxy_Child>().index], Time.deltaTime * speed);

                if (Vector3.Distance(current.transform.position, setPos[current.GetComponent<Galaxy_Child>().index]) < 0.1f)
                {
                    current.GetComponent<Galaxy_Child>().SetFree();

                    current.transform.parent = null;
                }
            }

            if(transform.childCount == 0){
                start = false;
            }
        }

    }

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			CreateUniverse();
		}
	}

	void CreateUniverse(){

        setPos = new Vector3[transform.childCount];


		for(int i = 0; i < transform.childCount; i++){
            float ranX;
            float ranY;

            

            ranX = transform.position.x + Random.Range(x_left, x_right);
            ranY = transform.position.y + Random.Range(y_down, y_up);

            setPos[i] = new Vector3(ranX, ranY, 0);
            transform.GetChild(i).GetComponent<Galaxy_Child>().index = i;

            transform.GetChild(i).GetComponent<Galaxy_Child>().moveDir = setPos[i] - transform.GetChild(i).transform.position;
            transform.GetChild(i).GetComponent<Galaxy_Child>().moveDir.Normalize();
            GameObject.Find("Galaxy Background").GetComponent<Set_Position>().activated = true;
		}

        start = true;
	     
	 GetComponent<AudioManager>().Play("Galaxy");
		
    }
            
        

}
