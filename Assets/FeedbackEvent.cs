
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;



[RequireComponent(typeof(AudioSource))]
public class FeedbackEvent : MonoBehaviour
{
    public FeedbackController feedb;
    public prova prov;
    public ChangePannels panels;
    public bool AudioFeedback;
    public bool VisualFeedback;
    public bool pulsated;


    public GameObject notifR;
    public GameObject notifL;
    private GameObject currentnotif;
    public AudioSource audioSource;
    public bool JustChanged = true;


    private float time = 0f;
    public float InterpolationTime = 15f;
    public float VisualDuration = 2f;// For non pulsated one
    private bool inbutton;
    private int numpulses = 5;
    private float timetochange = 0;






    // Start is called before the first frame update
    void Start()
    {
        notifR.SetActive(false);
        notifL.SetActive(false);
        inbutton= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (prov.cont>=4 && inbutton == true)
        {

            audioSource.panStereo = 1;
            currentnotif = notifR;
            inbutton = false;
            JustChanged = true;
            panels.buttonspushed = 0;

                if (pulsated )
                {
                    if (AudioFeedback) { StartCoroutine(AudioLoopPulse()); }
                    if (VisualFeedback) { StartCoroutine(VisualLoopPulse()); }
                }
                else
                {
                    if (AudioFeedback) { audioSource.Play(); }
                    if (VisualFeedback) { StartCoroutine(VisualLoop()); }
                }

            //prov.cont = -50;
            
         }

        if (panels.buttonspushed>=4)
        {
            prov.cont = 0;
            audioSource.panStereo = -1;
            currentnotif = notifR;
            inbutton = true;
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
            }
            panels.buttonspushed = -50;

        }




    }


    IEnumerator VisualLoop()
    {


        currentnotif.SetActive(true);
        yield return new WaitForSeconds(VisualDuration);
        currentnotif.SetActive(false);


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

       // WhichChannel();
        for (int i = 1; i <= numpulses; i++)
        {
            currentnotif.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            currentnotif.SetActive(false);
            yield return new WaitForSeconds(0.5f);


        }
    }

    

}




