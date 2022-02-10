using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class prova : MonoBehaviour
{
    public TrajectoryPlannerUr5 trajplan;
    private float Timing = 0f;
    private int i = 0;
    public GameObject[] TargetArray;
    public GameObject Greenplacement;
    public GameObject Pinkplacement;
    public int cont = 0;
    public bool greenfull = false;
    public bool pinkfull = false;
    public CubesInside green;
    public CubesInside pink;

    public TextMeshProUGUI UIGreen;
    public TextMeshProUGUI UIPink;

    void Start() { SetCountText(); }


    void Update()
    {
        Timing += Time.deltaTime;
        SetCountText();
        if (Timing >= 1f)// Waiting a second to start otherwise it gets a bit crazy
        {
           
            //Checks if any of the boxes are full. If they are full it checks if they have already been emptied completely
            if (green.CubesInBox >= 5) greenfull =  true;
            if (pink.CubesInBox >= 5) pinkfull = true;
            if (greenfull && green.CubesInBox ==0) { greenfull = false; }
            if (pinkfull && pink.CubesInBox ==0) { pinkfull = false; }


            //If the robot is not executing the previous trajectory and none of the boxes are full,
            //calculate and run new trajectory (first checking the tag of the cub and to which box it goes)
            if (trajplan.is_executing == false & (pinkfull == false & greenfull==false ) )
            {
                trajplan.Target = TargetArray[i]; 
                if (TargetArray[i].tag == "PinkT" | TargetArray[i].tag == "PinkS") trajplan.TargetPlacement = Pinkplacement;
                if (TargetArray[i].tag == "GreenT" | TargetArray[i].tag == "GreenS") trajplan.TargetPlacement = Greenplacement;
               

                i++;
                cont++;
                trajplan.PublishJoints();
                
            }


        }
    }


    void SetCountText()
    {
        UIGreen.text = green.CubesInBox.ToString();
        UIPink.text = pink.CubesInBox.ToString();

    }
}


