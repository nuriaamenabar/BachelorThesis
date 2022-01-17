
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;



//[RequireComponent(typeof(AudioSource))]
//public class FeedbackController : MonoBehaviour
//{
//    public bool AudioFeedback;
//    public bool VisualFeedback;
//    public bool pulsated;

//    public GameObject notifR;
//    public GameObject notifL;
//    private GameObject currentnotif;
//    public AudioSource audioSource;


//    private float time = 0f;
//    public float InterpolationTime = 15f;
//    public float VisualDuration = 2f;// For non pulsated one
//    private bool last;
//    private int numpulses = 5;
   
  



//    // Start is called before the first frame update
//    void Start()
//    {
//        notifR.SetActive(false);
//        notifL.SetActive(false);
//        last = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        time += Time.deltaTime;
 
//            if (time >= InterpolationTime)
//            {

//                if (pulsated)
//                {

//                    WhichChannel();
//                    if (AudioFeedback) { DoDelayActionAudio(0.15f); }
//                    if (VisualFeedback) { DoDelayAction(0.15f); }
//                    time = 0;
                  
//                }
//                else
//                {
//                    WhichChannel();
//                    if (AudioFeedback) { audioSource.Play(); }
//                    if (VisualFeedback) {DoDelayAction(VisualDuration);}
//                    time = 0;
//                }

//            }
//        }

        

//    void WhichChannel()
//    {
//        if (last)
//        {
//            audioSource.panStereo = -1;
//            currentnotif = notifL;
//            last = false;
//        }
//        else
//        {
//            audioSource.panStereo = 1;
//            currentnotif = notifR;
//            last = true;
//        }

//    }



//    void DoDelayAction(float delayTime)
//    {
//        StartCoroutine(DelayAction(delayTime));
//    }

//    IEnumerator DelayAction(float delayTime)
//    {


//        if (pulsated) {
//            for (int i = 0; i < numpulses; i++) {
//                yield return new WaitForSeconds((8-i)/3); currentnotif.SetActive(true); yield return new WaitForSeconds(delayTime); currentnotif.SetActive(false); }
           
//        }

//       else {
//            currentnotif.SetActive(true);
//            yield return new WaitForSeconds(delayTime);
//            currentnotif.SetActive(false);
//        }
//    }



//    void DoDelayActionAudio(float delayTime)
//    {
//        StartCoroutine(DelayActionAudio(delayTime));
//    }

//    IEnumerator DelayActionAudio(float delayTime)
//    {

//            for (int i = 0; i < numpulses; i++)
//            {
//                yield return new WaitForSeconds((8 - i) / 3); audioSource.Play();
//            }
//    }


//}





