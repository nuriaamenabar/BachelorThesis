using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


/*
 * 
 * The publisher of the robot. It publishes every time the robot has finished the previous trajectory, as long as none of the boxes are full.
 * If some box is full, it doesn´'t start again until it is emptied 
 * 
 * 
 */
public class prova : MonoBehaviour
{
    public TrajectoryPlannerUr5 trajplan; 
    public int CubesToStop = 5;//Cubes it takes for robot to stop
    private float clock = 0f;
    private int i = 0;//Auxiliar, to count how many cubes have been sorted
    public GameObject[] TargetArray;//Array with all grabbables, ordered
    public GameObject Greenplacement;
    public GameObject Pinkplacement;
    public int cont = 0;
    public bool greenfull = false;//Auxiliary bools
    public bool pinkfull = false;
    public CubesInside green;
    public CubesInside pink;

    public TextMeshProUGUI UIGreen;//For the second surveilance mode (not used)
    public TextMeshProUGUI UIPink;



    private bool justemptiedg=true;//Auxiliary bools
    private bool justemptiedp=true;
  
    void Start() { SetCountText(); }//FOr the surveilance with numbers, sets UI to cubes in each box


    void Update()
    {
        clock += Time.deltaTime;
        SetCountText();
        if (clock >= 1f)// Waiting a second to start otherwise it gets a bit crazy
        {

            //Checks if any of the boxes are full. If they are full it checks if they have already been emptied completely
            if (green.CubesInBox >= CubesToStop && justemptiedg) { greenfull = true; justemptiedg=false; PlayerStats.pilotStats.GreenBoxFilled.Add(clock); }
            if (pink.CubesInBox >= CubesToStop && justemptiedp) { pinkfull = true;  justemptiedp = false; PlayerStats.pilotStats.PinkBoxFilled.Add(clock); }
            if (greenfull && green.CubesInBox ==0 && justemptiedg ==false ) { greenfull = false; justemptiedg = true; PlayerStats.pilotStats.GreenBoxEmptied.Add(clock); }
            if (pinkfull && pink.CubesInBox==0 && justemptiedp == false) { pinkfull = false; justemptiedp = true; PlayerStats.pilotStats.PinkBoxEmptied.Add(clock); }


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


