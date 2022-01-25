using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class prova : MonoBehaviour
{
    public TrajectoryPlannerUr5 trajplan;
    private float Timing = 0f;
    public float interpolationPeriod = 4f;
    private int i = 0;
    public GameObject[] TargetArray;
    public GameObject Greenplacement;
    public GameObject Pinkplacement;
    



    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Timing += Time.deltaTime;
        if (Timing >= interpolationPeriod)
        {
            System.Random rd = new System.Random();

            int rand = rd.Next(100);

            trajplan.Target = TargetArray[i];
            if (TargetArray[i].tag == "Pink") {
                if (rand < 75) { trajplan.TargetPlacement = Pinkplacement; }
                else { trajplan.TargetPlacement = Greenplacement; }
                }
            if (TargetArray[i].tag == "Green") {
                if (rand < 75) { trajplan.TargetPlacement = Greenplacement; }
                else { trajplan.TargetPlacement = Pinkplacement; }
            }
            i++;
            trajplan.PublishJoints();
            Timing = 0;



        }
    }
}


