
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;



[RequireComponent(typeof(AudioSource))]
public class FeedbackController : MonoBehaviour
{
    public AudioSource audioSource;
    public float TimeBetweenPulse = 15f;
    public float TimeBetweenPi = 0.5f;

    public bool pulsated;
    public float pulsedurtion = 2f;

    public GameObject notifR;
    public GameObject notifL;
    private GameObject currentnotif;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    private bool active;
    private bool last;

    public bool AudioFeedback;
    public bool VisualFeedback;
    private float TimeOff;


    // Start is called before the first frame update
    void Start()
    {

        WhichChannel();
        notifR.SetActive(false);
        notifL.SetActive(false);
        active = false;
        last = false;
        TimeOff = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (AudioFeedback)
        {

            if (time >= TimeBetweenPulse)
            {
                if (pulsated)
                {

                    Pulsate();
                    if (time >= TimeBetweenPulse + pulsedurtion)//Cambiar el 5 si vull menys temps de pulse
                    {
                        time = 0;
                        WhichChannel();

                    }
                }
                else
                {
                    audioSource.Play();
                    time = 0;
                    WhichChannel();
                }

            }
        }

        if (VisualFeedback)

            if (time >= interpolationPeriod)
            {
                WhichChannel();
                time = 0.0f;
               
                DoDelayAction(2f);
                
        
            }
    }


    



    void Pulsate()
    {

        if (TimeOff <= TimeBetweenPi)
        {
            TimeOff += Time.deltaTime;
        }

        else
        {
            audioSource.Play();
            TimeOff = 0f;
        }

    }

    void WhichChannel()
    {
        if (last)
        {
            audioSource.panStereo = -1;
            currentnotif = notifL;
            last = false;
        }
        else
        {
            audioSource.panStereo = 1;
            currentnotif = notifR;
            last = true;
        }

    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        currentnotif.SetActive(true);
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        currentnotif.SetActive(false);
        //Do the action after the delay time has finished.
    }


}





