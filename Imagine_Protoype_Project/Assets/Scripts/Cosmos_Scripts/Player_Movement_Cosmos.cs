using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement_Cosmos : MonoBehaviour
{
   // public bool PC;
    public bool JourneyStarted;

    public bool trail;
    public float trailMod;

    float acc;

    public float playerHeight;
    float playerStartHeight;
    public float risingSpeed = 0;

    float cameraZoomInc;

    float cameraZoomStart;
    [Range(0, 100)]
    public float cameraZoomPercentage;
    public float maxCameraSize;

    public float tiltSpeed;

    private bool loadingScene;

    float timer;

    float planetHeight;

    public float angleOffSet;

    [Header("Time to Reach Planet")]
    [Tooltip("Set the minutes required untill the player reaches the planet endgame")]
    [Range(0, 59)]
    public int minutes;
    [Tooltip("Set the seconds required untill the player reaches the planet endgame")]
    [Range(0, 59)]
    public int seconds;

    Camera cam;

    Rigidbody2D rb;


    void Start()
    {
        cam = Camera.main;

        playerStartHeight = transform.position.y;
        planetHeight = PlanetDistanceCalculation(minutes, seconds, risingSpeed);

        SetZoomSpeed(planetHeight, minutes, seconds);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerHeight = transform.position.y;

        if (JourneyStarted)
        {
            if (Game_Manager.isPC)
            {
                float hAxis = Input.GetAxis("Horizontal");
                if (trail == false)
                {
                    if (acc + risingSpeed > risingSpeed)
                    {
                        acc -= Time.fixedDeltaTime * 0.75f;
                    }
                    rb.velocity = new Vector2(hAxis * tiltSpeed, risingSpeed + acc);
                }
                else
                {
                    if (acc + risingSpeed < risingSpeed * trailMod)
                    {
                        acc += Time.fixedDeltaTime * 0.75f;
                    }
                    rb.velocity = new Vector2(hAxis * tiltSpeed * trailMod, risingSpeed + acc);
                }

                Vector3 toVector = Vector3.up;
                float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;

                angleOffSet = (-hAxis * 15f) - 90f;
                Quaternion NewRot = Quaternion.AngleAxis(angle + angleOffSet, Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, NewRot, Time.fixedDeltaTime * tiltSpeed);

            }
            else
            {
                if (trail == false)
                {
                    if (acc + risingSpeed > risingSpeed)
                    {
                        acc -= Time.fixedDeltaTime * 0.75f;
                    }

                    rb.velocity = new Vector2(Input.acceleration.x * tiltSpeed, risingSpeed + acc);

                }
                else
                {
                    if (acc + risingSpeed < risingSpeed * trailMod)
                    {
                        acc += Time.fixedDeltaTime * 0.75f;
                    }

                    rb.velocity = new Vector2(Input.acceleration.x * tiltSpeed * trailMod, risingSpeed + acc);

                }

                Vector3 toVector = Vector3.up;
                float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;

                angleOffSet = (-Input.acceleration.x * 15f) - 90f;
                Quaternion NewRot = Quaternion.AngleAxis(angle + angleOffSet, Vector3.forward);

                transform.rotation = Quaternion.Slerp(transform.rotation, NewRot, Time.fixedDeltaTime * tiltSpeed);
            }

            if (cameraZoomStart <= playerHeight - playerStartHeight && cam.orthographicSize <= maxCameraSize)
            {
                cam.orthographicSize += cameraZoomInc;
            }
        }
    }

    public float ReachedPlanet()
    {
        return planetHeight - (playerHeight - playerStartHeight);
    }

    public float PlanetDistanceCalculation(float min, float sec, float speed)
    {
        float totalSeconds = (min * 60f) + sec;
        float distanceToSet = totalSeconds * speed;
        return distanceToSet;
    }

    void SetZoomSpeed(float planetY, float min, float sec)
    {
        float totalSeconds = (min * 60f) + sec;


        cameraZoomStart = planetY * (cameraZoomPercentage / 100);


        float timeToShift = totalSeconds - (totalSeconds * (cameraZoomPercentage / 100));

        cameraZoomInc = (maxCameraSize - cam.orthographicSize) / (timeToShift / 0.02f);
    }
}
