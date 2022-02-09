
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


    public GameObject notifGreen;
    public GameObject notifPink;
    public prova prov;
    private GameObject currentnotif;
    public GameObject Uduino;
    public AudioSource audioSource;
    


   
    public float VisualDuration = 2f;// For non pulsated one
    private int numpulses = 5;
    private float timetochange=0;
    private float clock = 0f;
    public float FeedbackActivatedIn=0;


    void Start()
    {
        if (AudioFeedback && !EMSFeedback && !VisualFeedback) PlayerStats.pilotStats.scene = "Audio";
        else if (VisualFeedback&& !EMSFeedback && !AudioFeedback) PlayerStats.pilotStats.scene = "Visual";
        else if (EMSFeedback && AudioFeedback && !VisualFeedback) PlayerStats.pilotStats.scene = "Haptic";
        else if (AudioFeedback && VisualFeedback && EMSFeedback) PlayerStats.pilotStats.scene = "Multimodal";
        else PlayerStats.pilotStats.scene = "NoFeedback";

        notifGreen.SetActive(false);
        notifPink.SetActive(false);

        
        audioSource.panStereo = 1;

    }

    void Update()
    {
        clock += Time.deltaTime;

        if ((prov.pinkfull  || prov.greenfull) && (clock-FeedbackActivatedIn)>5) // if a box is full and the last notification has been over 5 secs (so that notifications while you havent acted dont overlap)
        {
            print("INSIDE");
            if (prov.pinkfull) currentnotif = notifPink;
            if (prov.greenfull) currentnotif = notifGreen;
            FeedbackActivatedIn = clock;
            PlayerStats.pilotStats.interpolationFeedback.Add(clock);
            System.Random rd = new System.Random();
            //int rand = rd.Next(30, 60);
            //InterpolationTime = rand;


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
            //time = 0;
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


















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;



//[RequireComponent(typeof(AudioSource))]
//public class FeedbackEvent : MonoBehaviour
//{
//    public FeedbackController feedb;
//    public prova prov;
//    public bool AudioFeedback;
//    public bool VisualFeedback;
//    public bool pulsated;


//    public GameObject notifR;
//    public GameObject notifL;
//    private GameObject currentnotif;
//    public AudioSource audioSource;
//    public bool JustChanged = true;


//    private float time = 0f;
//    public float InterpolationTime = 15f;
//    public float VisualDuration = 2f;// For non pulsated one
//    private bool inbutton;
//    private int numpulses = 5;
//    private float timetochange = 0;






//    // Start is called before the first frame update
//    void Start()
//    {
//        notifR.SetActive(false);
//        notifL.SetActive(false);
//        inbutton = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (prov.cont >= 4 && inbutton == true)
//        {

//            audioSource.panStereo = 1;
//            currentnotif = notifR;
//            inbutton = false;
//            JustChanged = true;


//            if (pulsated)
//            {
//                if (AudioFeedback) { StartCoroutine(AudioLoopPulse()); }
//                if (VisualFeedback) { StartCoroutine(VisualLoopPulse()); }
//            }
//            else
//            {
//                if (AudioFeedback) { audioSource.Play(); }
//                if (VisualFeedback) { StartCoroutine(VisualLoop()); }
//            }

//            prov.cont = 0;

//        }





//    }


//    IEnumerator VisualLoop()
//    {


//        currentnotif.SetActive(true);
//        yield return new WaitForSeconds(VisualDuration);
//        currentnotif.SetActive(false);


//    }


//    IEnumerator AudioLoopPulse()
//    {

//        //WhichChannel();
//        for (int i = 1; i <= numpulses; i++)
//        {
//            audioSource.Play();
//            yield return new WaitForSeconds(1);
//        }



//    }

//    IEnumerator VisualLoopPulse()
//    {

//        // WhichChannel();
//        for (int i = 1; i <= numpulses; i++)
//        {
//            currentnotif.SetActive(true);
//            yield return new WaitForSeconds(0.5f);
//            currentnotif.SetActive(false);
//            yield return new WaitForSeconds(0.5f);


//        }
//    }



//}




//void Update()
//{
//    time += Time.deltaTime;
//    clock += Time.deltaTime;
//    timetochange += Time.deltaTime;
//    if (time >= InterpolationTime)
//    {
//        FeedbackActivatedIn = clock;
//        PlayerStats.pilotStats.interpolationFeedback.Add(clock);
//        System.Random rd = new System.Random();
//        int rand = rd.Next(30, 60);
//        InterpolationTime = rand;


//        if (pulsated)
//        {
//            if (AudioFeedback) { StartCoroutine(AudioLoopPulse()); }
//            if (VisualFeedback) { StartCoroutine(VisualLoopPulse()); }
//        }
//        else
//        {
//            if (AudioFeedback) { audioSource.Play(); }
//            if (VisualFeedback) { StartCoroutine(VisualLoop()); }
//            if (EMSFeedback) { StartCoroutine(EMSLoop()); }
//        }
//        time = 0;

//    }
//}
