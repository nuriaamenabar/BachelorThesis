using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class EMSTestScript : MonoBehaviour
{
    private void Start()
    {
        UduinoManager.Instance.pinMode(6, PinMode.Output);
        StartCoroutine(BlinkLoop());
        // StartCoroutine(EMSLoop());
    }

    IEnumerator BlinkLoop()
    {
        while (true)
        {
            UduinoManager.Instance.digitalWrite(6, State.HIGH);
            yield return new WaitForSeconds(5f);
            UduinoManager.Instance.digitalWrite(6, State.LOW);
            yield return new WaitForSeconds(5f);

        }
    }
}
