
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


    public GameObject notifR;
    //public GameObject notifL;
    private GameObject currentnotif;
    public GameObject Uduino;
    public AudioSource audioSource;
    public bool JustChanged = true;


    private float time = 0f;
    public float InterpolationTime = 15f;
    public float VisualDuration = 2f;// For non pulsated one
    private bool last;
    private int numpulses = 5;
    private float timetochange=0;


    // Start is called before the first frame update
    void Start()
    {
        notifR.SetActive(false);
        //notifL.SetActive(false);
        last = false;
        audioSource.panStereo = 1;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timetochange += Time.deltaTime;
        if (time >= InterpolationTime)
        {
            System.Random rd = new System.Random();
            int rand = rd.Next(30,60);
            InterpolationTime=rand;
            //WhichChannel();
            JustChanged = true;

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
            time = 0;

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
        
        //WhichChannel();
        for (int i = 1; i <= numpulses; i++)
        {
            audioSource.Play();
            yield return new WaitForSeconds(1);
        }


        
    }

    IEnumerator VisualLoopPulse()
    {
        
        //WhichChannel();
        for (int i = 1; i <= numpulses; i++)
        {
            currentnotif.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            currentnotif.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            

            }
    }


    //void WhichChannel()
    //{
    //    if (last)
    //    {
    //        audioSource.panStereo = -1;
    //        currentnotif = notifL;
    //        last = false;
    //    }
    //    else
    //    {
    //        audioSource.panStereo = 1;
    //        currentnotif = notifR;
    //        last = true;
    //    }

    //}

  

}









