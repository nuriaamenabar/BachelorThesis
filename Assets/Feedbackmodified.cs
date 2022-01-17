using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;



[RequireComponent(typeof(AudioSource))]
public class Feedbackmodified : MonoBehaviour
{
    public bool AudioFeedback;
    public bool VisualFeedback;
    public bool pulsated;

    public GameObject notifR;
    public GameObject notifL;
    private GameObject currentnotif;
    public AudioSource audioSource;


    private float time = 0f;
    public float InterpolationTime = 15f;
    public float VisualDuration = 2f;// For non pulsated one
    private bool last;
    private int numpulses = 5;





    // Start is called before the first frame update
    void Start()
    {
        notifR.SetActive(false);
        notifL.SetActive(false);
        last = false;
        if (pulsated) {
            if (AudioFeedback) { StartCoroutine(AudioLoopPulse()); }
            if (VisualFeedback) { StartCoroutine(VisualLoopPulse()); }
        }
        else
        {
            if (AudioFeedback) { StartCoroutine(AudioLoop()); }
            if (VisualFeedback) { StartCoroutine(VisualLoop()); }
        }
    }


    IEnumerator AudioLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(InterpolationTime);
            WhichChannel();
            audioSource.Play();

        }
    }

    IEnumerator VisualLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(InterpolationTime);
            WhichChannel();
            currentnotif.SetActive(true);
            yield return new WaitForSeconds(VisualDuration);
            currentnotif.SetActive(false);

        }
    }


    IEnumerator AudioLoopPulse()
    {
        while (true)
        {
            yield return new WaitForSeconds(InterpolationTime);
            WhichChannel();
            for (int i = 1; i <= numpulses; i++)
            {
                audioSource.Play();
                yield return new WaitForSeconds(1);
            }


        }
    }

    IEnumerator VisualLoopPulse()
    {
        while (true)
        {
            yield return new WaitForSeconds(InterpolationTime);
            WhichChannel();
            for (int i = 1; i<=numpulses; i++) {
                currentnotif.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                currentnotif.SetActive(false);
                yield return new WaitForSeconds(1);
            }

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
    }



    

 



