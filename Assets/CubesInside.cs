using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Component of each of the boxe´s "floors". Keeps track of how many cubes there are in each box and logs different stuff
 * I´m sorry the code is really inefficient but I didnt know how to make it another way, I've tried to explain the mess as much as possible :)
 * 
 * 
 */



public class CubesInside : MonoBehaviour
{
    public WhereIsCube[] whereis; //Array containing all of the grabbables, each one has a ascript that defines where they are
    public int CubesInBox; //How many cubes are in the box
    public GameObject box;//Which box is it a component off (Add the same GameObject it is a component off)--> Which box is it tracking
    public Lookray look; //For log puropses, the ray attached to the centereyeanchor from OVR camera,  that detects where youre looking
    public int CubesCorrectlyClass;
    public int CubesWronglyClass;


    void Update() //Each frame, check for every cube in the array if it is in the box and update the value óf the cubesinBox
    {
        CubesInBox = 0; //Start count to 0

        for (int i = 0; i < whereis.Length; i++) //Go over all the cubes 
        {
            if (box.tag == "GreenBox"  && whereis[i].inGreenBox == true  ) CubesInBox++;//If the script belongs to the green box, it will check how many cubes are in the greeen box (etc)
            if (box.tag == "PinkBox" && whereis[i].inPinkBox == true ) CubesInBox++;
            if (box.tag == "GreenBoxTextured" && whereis[i].inGreenText == true ) CubesInBox++;
            if (box.tag == "PinkBoxTextured" && whereis[i].inPinkText == true) CubesInBox++;
            if (box.tag == "GreenBoxSmooth" && whereis[i].inGreenSmooth == true) CubesInBox++;
            if (box.tag == "PinkBoxSmooth" && whereis[i].inPinkSmooth == true) CubesInBox++;
        }

        if (look.JustChangedVisionToRobot_count1 == true | look.JustChangedVisionToRobot_count2 == true) // To log how many cubes where in the boxes when you started looking ()
        {
            if (box.tag == "GreenBox") { PlayerStats.pilotStats.CubesInGreenBoxWhenStartedLooking.Add(CubesInBox); look.JustChangedVisionToRobot_count1 = false; } 
            if (box.tag == "PinkBox") { PlayerStats.pilotStats.CubesInPinkBoxWhenStartedLooking.Add(CubesInBox); look.JustChangedVisionToRobot_count2 = false; }
    

        }
        if (look.JustChangedVisionToPannels_count == true) // To log how many cubes you have correctly and wrongly classified once u change back to the secondary task (total value)
        {
            for (int i = 0; i < whereis.Length; i++)// Forall cubes, check how many are correct and wrongly classified
            {

                if (whereis[i].correctClas == true) CubesCorrectlyClass++;
                if (whereis[i].wrongClas == true) CubesWronglyClass++;
            }
            look.JustChangedVisionToPannels_count = false;
            PlayerStats.pilotStats.correctClass.Add(CubesCorrectlyClass);
            PlayerStats.pilotStats.mistakesClass.Add(CubesWronglyClass);

            CubesCorrectlyClass = 0;//To re-start n´count for next time since every time it checks all the cubes and not only the recently classified
            CubesWronglyClass = 0;
        }



    }
    
}

