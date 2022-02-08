using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float clock = 0;
    private bool ison = false;
    public float StartAt=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         clock += Time.deltaTime;
        if (clock - StartAt > 5*60) { print("END"); UnityEditor.EditorApplication.isPlaying = false; }
        

    }
    void StartTime()
    {
        PlayerStats.pilotStats.startTime = clock;
        StartAt = clock;
        ison =true;

    }


}


