using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private static string _transitionPath;

    public static Game_Manager Instance;

    public static bool isPC;


    public GameObject TransitionTemplate;
 
    void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }
        else
        {
            
            DestroyImmediate(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (Application.isEditor) {

            isPC = false;
            
            Debug.Log("Is Editor");
            
            

        } else if (Application.isMobilePlatform) {

            isPC = false;

            Debug.Log("Is Mobile");
            

        } else {

            isPC = true;

            Debug.Log("Is PC");

        }


    }

    public  void LoadScene(string SceneName){
        //StartCoroutine here on the instance
        
      // instance = new Game_Manager();

        StartCoroutine(LoadInTime(SceneName));
    }

    public IEnumerator LoadInTime(string name)
    {

       // GameObject temp = (GameObject) Resources.Load(_transitionPath);

        Instantiate(TransitionTemplate);

         yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(time);
        AsyncOperation loading = SceneManager.LoadSceneAsync(name);

       
        
        while (!loading.isDone) {

            yield return null;

        }


    }

    //arrayToCurve is original Vector3 array, smoothness is the number of interpolations.
    public static Vector3[] MakeSmoothCurve(Vector3[] arrayToCurve, float smoothness)
    {
        List<Vector3> points;
        List<Vector3> curvedPoints;
        int pointsLength = 0;
        int curvedLength = 0;

        if (smoothness < 1.0f) smoothness = 1.0f;

        pointsLength = arrayToCurve.Length;

        curvedLength = (pointsLength * Mathf.RoundToInt(smoothness)) - 1;
        curvedPoints = new List<Vector3>(curvedLength);

        float t = 0.0f;
        for (int pointInTimeOnCurve = 0; pointInTimeOnCurve < curvedLength + 1; pointInTimeOnCurve++)
        {
            t = Mathf.InverseLerp(0, curvedLength, pointInTimeOnCurve);

            points = new List<Vector3>(arrayToCurve);

            for (int j = pointsLength - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    points[i] = (1 - t) * points[i] + t * points[i + 1];
                }
            }

            curvedPoints.Add(points[0]);
        }

        return (curvedPoints.ToArray());
    }

    public static float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
        
        
        //wut?
        
    }
}
