using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float clock = 0;
    private bool ison = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ison==false) { clock += Time.deltaTime; }


    }
    void StartTime()
    {
        PlayerStats.pilotStats.startTime = clock;
        ison =true;

    }


}


