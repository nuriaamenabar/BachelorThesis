using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioFeedbackPulse2 : IPulseFeedback
{

    public AudioSource audioSource;
    public bool shouldPlay = true;
    public float? pulseDuration;
    public float? pulseStep = 0.1f;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public override void giveFeedback(float distance, float angle, GameObject placement)
    {
        //stereoPan = angle;

        audioSource = placement.GetComponent<AudioSource>();
        
        calcPulseStep(distance);
        pulsate();
       
    }

    public override void stopFeedback()
    {

    }
    /*public void calcPulseStep(float distance)
    {
        pulseStep = Mathf.Abs(mapToZeroOne(distance, 0, 1) - 1);
    }*/

    public override void pulsate()
    {

        if (pulseDuration == null)
        {
            pulseDuration = Time.time + pulseStep;
        }

        if (Time.time < pulseDuration && shouldPlay)
        {
            shouldPlay = false;
            audioSource.Play();
        }


        if (Time.time > pulseDuration)
        {
            shouldPlay = true;
            pulseDuration = Time.time + pulseStep;
        }

    }

    public void calcPulseStep(float distance)
    {
        pulseStep = Mathf.Abs(mapToZeroOne(distance, 0, 1) - 1);
    }
}
