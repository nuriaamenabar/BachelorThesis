using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioFeedbackPulse : IPulseFeedback
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

        audioSource.volume = Mathf.Abs(angle);

        if (angle < deadZone && angle > -deadZone)
        {
            audioSource.panStereo = 0;
            audioSource.volume = 1;
        }

        else if (angle > 0)
        {
            audioSource.panStereo = 1;
        }

        else
        {
            audioSource.panStereo = -1;
        }


        /*if (angle < 0)
        {
            audioSource.panStereo = Mathf.Pow(Mathf.Abs(angle), 1f / 3f) * (-1);
        }

        else
        {
            audioSource.panStereo = Mathf.Pow(angle, 1f/3f);
        }*/
        //audioSource.panStereo = angle;
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
