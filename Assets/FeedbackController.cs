
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using Uduino;
using UnityEngine.UI;



[RequireComponent(typeof(AudioSource))]
public class FeedbackController : MonoBehaviour
{
    public bool AudioFeedback;
    public bool VisualFeedback;
    public bool EMSFeedback;
    public bool pulsated;
    public bool surveilance;


    public GameObject notifGreen;
    public GameObject notifPink;
    public GameObject surveilanceObj;
    public prova prov;
    private GameObject currentnotif;
    public GameObject Uduino;
    public AudioSource audioSource;
    public Lookray look;
    


   
    public float VisualDuration = 2f;// For non pulsated one
    private int numpulses = 5;
   
    private float clock = 0f;
    public float FeedbackActivatedIn=0;


    void Start()
    {
        if (AudioFeedback) PlayerStats.pilotStats.scene.Add("Audio");
        if (VisualFeedback) PlayerStats.pilotStats.scene.Add("Visual");
        if (EMSFeedback) PlayerStats.pilotStats.scene.Add("Haptic");
        if (surveilance) { PlayerStats.pilotStats.surveilance = "yes"; surveilanceObj.SetActive(true); }
        else { PlayerStats.pilotStats.surveilance = "no"; surveilanceObj.SetActive(false); } 


        notifGreen.SetActive(false);
        notifPink.SetActive(false);

        
        audioSource.panStereo = 1;

    }

    void Update()
    {
        clock += Time.deltaTime;

        if ((prov.pinkfull  || prov.greenfull) && (clock-FeedbackActivatedIn)>5 && look.inrobot==false ) // if a box is full and the last notification has been over 5 secs (so that notifications while you havent acted dont overlap)
        {
            print("INSIDE");
            if (prov.pinkfull) currentnotif = notifPink;
            if (prov.greenfull) currentnotif = notifGreen;
            FeedbackActivatedIn = clock;
            PlayerStats.pilotStats.Feedback.Add(clock);
            System.Random rd = new System.Random();
            


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
        yield return new WaitForSeconds(VisualDuration);
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







