//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;


//[RequireComponent(typeof(AudioSource))]
//public class AudioManager : MonoBehaviour
//{
//    public AudioSource audioSource;
//    public float TimeBetweenPulse = 15f;
//    public float TimeBetweenPi = 0.5f;
//    private bool Left = true;
//    private float Timing = 0f;
//    private float TimeOff = 10f;
//    public bool pulsated;
//    public float pulsedurtion = 2f;




//    // Start is called before the first frame update
//    void Start()
//    {
//        Timing = 0f;
//        WhichChannel();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Timing += Time.deltaTime;
//        if (Timing >= TimeBetweenPulse)
//        {
//            if (pulsated)
//            {

//                Pulsate();
//                if (Timing >= TimeBetweenPulse + pulsedurtion)//Cambiar el 5 si vull menys temps de pulse
//                {
//                    Timing = 0;
//                    WhichChannel();

//                }
//            }
//            else
//            {
//                audioSource.Play();
//                Timing = 0;
//                WhichChannel();
//            }

//        }
//    }



//    void Pulsate()
//    {

//        if (TimeOff <= TimeBetweenPi)
//        {
//            TimeOff += Time.deltaTime;
//        }

//        else
//        {
//            audioSource.Play();
//            TimeOff = 0f;
//        }

//    }






//    void WhichChannel()
//    {
//        if (Left)
//        {
//            audioSource.panStereo = -1;
//            Left = false;
//        }
//        else
//        {
//            audioSource.panStereo = 1;
//            Left = true;
//        }

//    }




//}
