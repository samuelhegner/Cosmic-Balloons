using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Movement_Map : MonoBehaviour {
    
    [SerializeField]
    bool tilt;
    [SerializeField]
    bool selected;

    bool twoFingers;
    bool waitingForTouch;

    private bool loadingScene;

    Rigidbody2D rb;


  //  public bool PC;


    float dirX, dirY;

    GameObject SelectedSite;

    Touch touch;

    public Vector2 location;

    public GameObject Flag;
    public GameObject Basket;

    TrailRenderer trail;

    GameObject[] sites;
    GameObject activeSite;


    public float movementSpeed;

    public float MaxSpeed;
    public float MinSpeed;

    public float MaxDistance;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        selected = false;
        twoFingers = false;
        location = transform.position;
        waitingForTouch = true;
        trail = Basket.GetComponent<TrailRenderer>();
        sites = GameObject.FindGameObjectsWithTag("Site");
        activeSite = new GameObject();
	}
	
	void Update () {

        AdjustTrail();

        if (tilt == false)
        {

            if (selected == false)
            {
                //For Mobile input

                if (twoFingers == false)
                {
                    if (Input.touchCount == 0 && waitingForTouch == false)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                        if(hit.collider != null){
                            if(hit.collider.gameObject.tag != "Site" && hit.collider.gameObject.tag != "Button"){
                                location = SetPointToMove(touch.position);
                                waitingForTouch = true;
                                DropFlag();
                                TurnOffSites();
                                location -= new Vector2(Basket.transform.localPosition.x, Basket.transform.localPosition.y - 2f);
                            }
                        }else{
                            location = SetPointToMove(Input.mousePosition);
                            DropFlag();
                            location -= new Vector2(Basket.transform.localPosition.x, Basket.transform.localPosition.y - 2f);
                            TurnOffSites();
                        }
                    }
                }




                if (Input.touchCount > 1)
                {
                    twoFingers = true;
                    touch = new Touch();
                    waitingForTouch = false;

                }
                else if (Input.touchCount == 1 && twoFingers == false)
                {
                    waitingForTouch = false;
                    touch = Input.GetTouch(0);
                }
                else if (Input.touchCount == 0) {
                    twoFingers = false;
                    waitingForTouch = true;
                    touch = new Touch();
                }




                //For PC input

                if (Game_Manager.isPC) {
                    if (Input.GetMouseButtonUp(0))
                    {
                        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                        
                        if(hit.collider != null){
                            if(hit.collider.gameObject.tag != "Site" && hit.collider.gameObject.tag != "Button"){
                                location = SetPointToMove(Input.mousePosition);
                                DropFlag();
                                location -= new Vector2(Basket.transform.localPosition.x, Basket.transform.localPosition.y - 2f);
                                TurnOffSites();
                                print("test");
                            }
                        }else{
                            location = SetPointToMove(Input.mousePosition);
                            DropFlag();
                            location -= new Vector2(Basket.transform.localPosition.x, Basket.transform.localPosition.y - 2f);
                            TurnOffSites();
                        }


                    }
                }
                

                MoveToPoint(location); //Sets move towards location
            }
            else {
                if (Vector3.Distance(transform.position, SelectedSite.transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, SelectedSite.transform.position, movementSpeed * Time.deltaTime);
                }
                else {
                    if (!loadingScene)
                    {
                        SelectedSite.GetComponent<Site_Info>().LoadCorrespondingScene();
                        loadingScene = true;
                    }
                }
            }
            
        }
        else {
            if (selected == false) {
                dirX = Input.acceleration.x * movementSpeed;
                dirY = Input.acceleration.y * movementSpeed;
            }
        }


    }

    void FixedUpdate()
    {
        if (tilt == true) {
            if (selected == false) {
                rb.velocity = new Vector2(dirX, dirY);
            }
        }
    }


    public void MoveToClosestSite() {
        selected = true;
        SelectedSite = GetComponent<Site_Finder>().closestSite;
    }

    Vector2 SetPointToMove(Vector2 screenPosition) {
        Vector2 pointToMove = Camera.main.ScreenToWorldPoint(screenPosition);
        SetMoveSpeed(MinSpeed, MaxSpeed, pointToMove, transform.position);
        return pointToMove;
    }

    void MoveToPoint(Vector2 location) {
        transform.position = Vector2.MoveTowards(transform.position, location, movementSpeed * Time.deltaTime);
    }

    public void DropFlag() {

        //TODO: Instantiate flag prefab, flag prefab animates, flag prefab checks ground, flag prefab instantiates ground effect.

        Flag.transform.position = location;
        Flag.GetComponent<Animator>().SetTrigger("Drop");
        
        //Debug.Log("Dropping flag");
        
    }

    void SetMoveSpeed(float min, float max, Vector2 traget, Vector2 current){
        float dist = Vector2.Distance(traget, current);
        if(dist < MaxDistance){
            float speedPercent = dist/MaxDistance;
            movementSpeed = MaxSpeed * speedPercent;
        }else{
            movementSpeed = MaxSpeed;
        }

        if(movementSpeed < MinSpeed){
            movementSpeed = MinSpeed;
        }

    }



    void AdjustTrail(){
        float time;
        time = Game_Manager.Map(movementSpeed, MinSpeed, MaxSpeed, 0, 5);
        trail.time = time;
        float a;
        a = Game_Manager.Map(movementSpeed, MinSpeed, MaxSpeed, 0f, 1f);
        Color col = new Color(1, 1, 1, a);
        Color endCol = new Color(1, 1, 1, 0);
        
        //maybe add colours as public variables and have them settable in editor to any colour
        
        trail.startColor = col;
        trail.endColor = endCol;
    }

    public void ResetLocation(){
        location = transform.position;
    }

    void TurnOffSites(){
        GameObject[] sites = GameObject.FindGameObjectsWithTag("Site");

        for (int i = 0; i < sites.Length; i ++){
            Select_Site ss = sites[i].GetComponent<Select_Site>();

            if(ss != null){
                ss.TurnOffPopUp();
                ss.loadScene = false;
            }
        }
    }


    public void SetActiveSite(string siteName){
        for(int i = 0; i < sites.Length; i++){
            if(sites[i].transform.parent.gameObject.name == siteName){
                activeSite = sites[i];
            }else{
                sites[i].GetComponent<Select_Site>().TurnOffPopUp();
            }
        }
    }

}