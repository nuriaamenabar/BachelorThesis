using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VisualController : MonoBehaviour
{
   // [HideInInspector] public AudioSource source;

    public GameObject notifR;
    public GameObject notifL;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    private bool active;
    private bool last;


    void Start()
    {
       notifR.SetActive(false);
       notifL.SetActive(false);
       active = false;
       last = false;
    }

     void Update()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            if (!active)
            {
                if (last)
                {
                    notifR.SetActive(true);
                    active = true;
                    last = false;
                }
                else
                {
                    notifL.SetActive(true);
                    active = true;
                    last = true;
                }

            }
            else
            {
                notifR.SetActive(false);
                notifL.SetActive(false);
                active = false; 
            }


        }
    }
}


