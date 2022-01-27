using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class EMSTestScript : MonoBehaviour
{
    private float time = 0f;
    public float InterpolationTime = 15f;
    public float VisualDuration = 2f;
    private void Start()
    {
        UduinoManager.Instance.pinMode(6, PinMode.Output);
        //StartCoroutine(BlinkLoop());
        // StartCoroutine(EMSLoop());
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= InterpolationTime)
        {
            StartCoroutine(BlinkLoop()); 
            time = 0;
        }
    }

    IEnumerator BlinkLoop()
    {
        
            UduinoManager.Instance.digitalWrite(6, State.HIGH);
            yield return new WaitForSeconds(VisualDuration);
            UduinoManager.Instance.digitalWrite(6, State.LOW);

        
    }
}
