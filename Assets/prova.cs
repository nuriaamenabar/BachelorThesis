using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class prova : MonoBehaviour
{
    public TrajectoryPlannerUr5 trajplan;
    private float Timing = 0f;
    private int i = 0;
    public GameObject[] TargetArray;
    public GameObject Greenplacement;
    public GameObject Pinkplacement;
    public int cont = 0;
    



    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Timing += Time.deltaTime;
        if (Timing >= 1f)
        {
            if (trajplan.is_executing == false)
            {
                //System.Random rd = new System.Random();

                //int rand = rd.Next(100);

                trajplan.Target = TargetArray[i]; 
                if (TargetArray[i].tag == "PinkT" | TargetArray[i].tag == "PinkS")
                {
                    //if (rand < 75) { trajplan.TargetPlacement = Pinkplacement; }
                    //else { trajplan.TargetPlacement = Greenplacement;
                    trajplan.TargetPlacement = Pinkplacement;
                }
                if (TargetArray[i].tag == "GreenT" | TargetArray[i].tag == "GreenS")
                {
                    //if (rand < 75) { trajplan.TargetPlacement = Greenplacement; }
                    //else { trajplan.TargetPlacement = Pinkplacement;
                    trajplan.TargetPlacement = Greenplacement;
                }

                i++;
                cont++;
                trajplan.PublishJoints();
                
            }


        }
    }
}


