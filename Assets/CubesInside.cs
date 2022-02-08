using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesInside : MonoBehaviour
{
    public WhereIsCube[] whereis;
    public int CubesInBox;
    public GameObject box;
    public Lookray look;
    public int CubesCorrectlyClass;
    public int CubesWronglyClass;

    void Start()
    {
        
    }

    void Update()
    {
        CubesInBox = 0;

        for (int i = 0; i < whereis.Length; i++) 
        {
           
            if (whereis[i].inGreenBox == true && box.tag=="GreenBox") CubesInBox++;
            if (whereis[i].inPinkBox == true  && box.tag =="PinkBox") CubesInBox++;
            if (whereis[i].inGreenText == true && box.tag == "GreenBoxTextured") CubesInBox++;
            if (whereis[i].inPinkText == true && box.tag == "PinkBoxTextured") CubesInBox++;
            if (whereis[i].inGreenSmooth == true && box.tag == "GreenBoxSmooth") CubesInBox++;
            if (whereis[i].inPinkSmooth == true && box.tag == "PinkBoxSmooth") CubesInBox++;


        }

        if (look.JustChangedVisionToRobot_count1 == true | look.JustChangedVisionToRobot_count2 == true) // Afegir que encara no ha agafat res
        {
            if (box.tag == "GreenBox") { PlayerStats.pilotStats.CubesInGreenBoxWhenStartedLooking.Add(CubesInBox); look.JustChangedVisionToRobot_count1 = false; } 
            if (box.tag == "PinkBox") { PlayerStats.pilotStats.CubesInPinkBoxWhenStartedLooking.Add(CubesInBox); look.JustChangedVisionToRobot_count2 = false; }
    

        }
        if (look.JustChangedVisionToPannels_count == true) // Afegir que encara no ha agafat res
        {
            for (int i = 0; i < whereis.Length; i++)
            {

                if (whereis[i].correctClas == true) CubesCorrectlyClass++;
                if (whereis[i].wrongClas == true) CubesWronglyClass++;
            }
            look.JustChangedVisionToPannels_count = false;
            PlayerStats.pilotStats.correctClass.Add(CubesCorrectlyClass);
            PlayerStats.pilotStats.mistakesClass.Add(CubesWronglyClass);

            CubesCorrectlyClass = 0;
            CubesWronglyClass = 0;
        }



    }
    
}

