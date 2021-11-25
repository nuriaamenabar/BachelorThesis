using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VisualController : MonoBehaviour
{
   // [HideInInspector] public AudioSource source;

    public GameObject notif;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;
    private bool active;


    void Start()
    {
       notif.SetActive(false);
        active = false;
    }

     void Update()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            if (active == false)
            {
                notif.SetActive(true);
                active = true;

            }
            else
            {
                notif.SetActive(false); 
                active = false; 
            }


        }
    }
}


