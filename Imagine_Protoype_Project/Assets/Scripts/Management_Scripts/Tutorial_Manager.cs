using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial_Manager : MonoBehaviour {

    public bool PinchToZoom;
    public bool TwoFingersToMove;
    public bool TiltPhone;
    public bool CloseEyes;
    public bool Swipe;

    [Space] public float InitialDelay;
    public float DurationOfTutorial;
    public float DelayBetween; 
    

    [Space] public GameObject TutorialPinchToZoom;
    public GameObject TutorialTwoFingersToMove;
    public GameObject TutorialTiltPhone;
    public GameObject TutorialCloseEyes;
    public GameObject TutorialSwipe;

// Start is called before the first frame update


    void Start() {

        StartPlayingTutorials();
        
    }

    public void StartPlayingTutorials() {

        StartCoroutine(StartTutorials());

    }

    IEnumerator StartTutorials()
    {
        
        yield return new WaitForSeconds(InitialDelay);


        if (PinchToZoom) {

            TutorialPinchToZoom.SetActive(true);


            float delay = GetAimationLength(TutorialPinchToZoom);
            
            
            yield return new WaitForSeconds(delay);
     
            TutorialPinchToZoom.SetActive(false);
            
            yield return new WaitForSeconds(DelayBetween);

        }

        if (TwoFingersToMove) {

            TutorialTwoFingersToMove.SetActive(true);

            float delay = GetAimationLength(TutorialTwoFingersToMove);
            
            yield return new WaitForSeconds(delay);

            TutorialTwoFingersToMove.SetActive(false);

            yield return new WaitForSeconds(DelayBetween);

        }

        if (TiltPhone) {

            TutorialTiltPhone.SetActive(true);

            float delay = GetAimationLength(TutorialTiltPhone);

            yield return new WaitForSeconds(delay);

            TutorialTiltPhone.SetActive(false);

            yield return new WaitForSeconds(DelayBetween);

        }

        if (CloseEyes) {

            TutorialCloseEyes.SetActive(true);

            float delay = GetAimationLength(TutorialCloseEyes);

            yield return new WaitForSeconds(delay);

            TutorialCloseEyes.SetActive(false);

            yield return new WaitForSeconds(DelayBetween);

        }

        if (Swipe) {

            TutorialSwipe.SetActive(true);

            float delay = GetAimationLength(TutorialSwipe);

            yield return new WaitForSeconds(delay);

            TutorialSwipe.SetActive(false);

            yield return new WaitForSeconds(DelayBetween);

        }


    }


    public float GetAimationLength(GameObject Target) {

        try {
            if (Target.GetComponent<Animator>()) {
                AnimatorClipInfo[] ACI = Target.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

                float time = ACI[0].clip.length;

                return time;
            } else {

                return DurationOfTutorial;

            }
        } catch {

            return DurationOfTutorial; 

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    
    
}
