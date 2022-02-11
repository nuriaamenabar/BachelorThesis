
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using Uduino;
using UnityEngine.UI;

/*
 * This script controlls all the feedback modalities and also the surveilance camera. You can activate/desactivate the
 * different modalities from the unity interface.
 * 
 * It also keeps log of when the feedback has been activated.
 * 
 * Feedback is activated if: One of the boxes is full && Last feedback was given over 5 seconds ago (no overlapping) && participant not looking at the robot
 * 
 * 
 */

[RequireComponent(typeof(AudioSource))]
public class FeedbackController : MonoBehaviour
{
    //Bools to decide from the unity interface which feedback should be activated and if there큦 surveilance or not.
    public bool AudioFeedback;
    public bool VisualFeedback;
    public bool EMSFeedback;
    public bool pulsated;
    public bool surveilance;

    //All of the feedbacks' gameobjects, that the script will activate/deactivate when necessary
    public GameObject notifGreen;
    public GameObject notifPink;
    public GameObject surveilanceObj;
    public GameObject Uduino;
    public AudioSource audioSource;

    //Auxiliary objects to help log and check when feedback is necessary
    public prova prov;//Robot큦 automatic publisher script
    public Lookray look;//To check where participant is looking, from OVRCameraRig큦 CenterEyeAnchor
    private GameObject currentnotif;//Auxiliary 
    public float FeedbackActivatedIn = 0;//Auxiliary
    private float clock = 0f;
    
    //Parameters of the feedback it큦elf
    private float VisualDuration = 2f;// For non pulsated visual feedback, how long does the visual feedback last
    private int numpulses = 5;//For pulsated one, how many pulses per feedback
    
    


    void Start()
    {
        //Checks which feedback modality to log it
        if (AudioFeedback) PlayerStats.pilotStats.scene.Add("Audio");
        if (VisualFeedback) PlayerStats.pilotStats.scene.Add("Visual");
        if (EMSFeedback) PlayerStats.pilotStats.scene.Add("Haptic");

        //Checks if surveilance is active and activates the gameobject if it큦 the case, also logs if it is.
        if (surveilance) { PlayerStats.pilotStats.surveilance = "yes"; surveilanceObj.SetActive(true); }
        else { PlayerStats.pilotStats.surveilance = "no"; surveilanceObj.SetActive(false); } 

        //Desactivates notifications (until feedback has to be activated) and sets the stereo to one so audio comes dfrom right side
        notifGreen.SetActive(false);
        notifPink.SetActive(false);
        audioSource.panStereo = 1;

    }

    void Update()
    {
        clock += Time.deltaTime;

        // if a box is full and the last notification has been over 5 secs (so that notifications while you havent acted dont overlap), give feedback. Feedback stops when u look at robot
        if ((prov.pinkfull  || prov.greenfull) && (clock-FeedbackActivatedIn)>5 && look.inrobot==false )
        {
            if (prov.pinkfull) currentnotif = notifPink;
            if (prov.greenfull) currentnotif = notifGreen;//Sets which notification has to be activated depending on which box is full
            FeedbackActivatedIn = clock;
            PlayerStats.pilotStats.Feedback.Add(clock);//logs when its been activated
        
            //Depending on the feedback that has been chosen in unity, activates the corresponding coroutine  
            if (pulsated)
            {
                if (AudioFeedback) { StartCoroutine(AudioLoopPulse()); }
                if (VisualFeedback) { StartCoroutine(VisualLoopPulse()); }
            }
            else
            {
                if (AudioFeedback) { audioSource.Play(); }
                if (VisualFeedback) { StartCoroutine(VisualLoop()); }
                if (EMSFeedback) { StartCoroutine(EMSLoop()); }
            }
          
        }
        if(surveilance && look.inrobot) surveilanceObj.SetActive(false);
        if (surveilance && look.inrobot==false) surveilanceObj.SetActive(true);


    }
    



    IEnumerator VisualLoop()
    {
        currentnotif.SetActive(true);
        yield return new WaitForSeconds(VisualDuration);
        currentnotif.SetActive(false);
    }

    IEnumerator EMSLoop()
    {
        UduinoManager.Instance.digitalWrite(6, State.HIGH);
        yield return new WaitForSeconds(3);
        UduinoManager.Instance.digitalWrite(6, State.LOW);
    }


    IEnumerator AudioLoopPulse()
    {
        for (int i = 1; i <= numpulses; i++)
        {
            audioSource.Play();
            yield return new WaitForSeconds(1);
        }   
    }

    IEnumerator VisualLoopPulse()
    {
        for (int i = 1; i <= numpulses; i++)
        {
            currentnotif.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            currentnotif.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}







