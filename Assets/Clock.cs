using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Logs the start time and finishes gameplay once 5 mins have passed since the start
 * Called by the start button´s onPushed()
 */

public class Clock : MonoBehaviour
{
    public float clock = 0;
    public float StartAt=0;
  
    void Update()
    {
        clock += Time.deltaTime;
        if (clock - StartAt > 3 * 60) { print("END"); UnityEditor.EditorApplication.isPlaying = false; }//  A}

    }
    void StartTime()
    {
        PlayerStats.pilotStats.startTime = clock;
        StartAt = clock;
    }


}


