using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Script that changes the math pannels once one button is pushed. Contains function "Change", called by each button when pushed (onPush())
 * Tracks scores, time when a button has been pushed and total buttons pushed. Component of the "ButtonsChangePannels" GameObject
 */ 
public class ChangePannels : MonoBehaviour
{
    public GameObject[] PannelsArray; //Array containing all the panels. 
    public Physicsbutton physbut;//When added to a button?s onPush, you have to put the corresponding button (See Button?s onpush), to track the tag of the button that has been pushed 
   
    public int score = 0; //Track of the score
    public TextMeshProUGUI countText; // UI where the score will be rendered
    public int TotalButtons; //Number of times a button has been pushed (correct or incorrect)
    public Lookray ray; //Ray element that tracks where the participant is watching (for logging things), attached to centereyeanchor frpm OVRCamera
    private float clock = 0;
    private int i;


    void Start()
    {
 	     // counter of which panel is active
        SetCountText(); //Sets score UI text to actual score

        foreach(GameObject Pannel in PannelsArray)//Unactivates all the panels except for the first one in the array
        {
            Pannel.SetActive(false);
        }
        PannelsArray[0].SetActive(true);
        int i = 0;
    }
    
    void Update() { clock += Time.deltaTime; }//to keep track of time

    void SetCountText()//Sets score UI text to actual score
    {
        countText.text =  score.ToString();

    }

    public void Change(GameObject button)//Called each time a button is pushed
    {
        TotalButtons++; 
        if (PannelsArray[i].tag == button.tag) score++;//If the tag of the button (number) is equal to the tag of the panel (solution of math problem)-->Correct answer
        PlayerStats.pilotStats.score.Add(score);//Add score to list
        PlayerStats.pilotStats.totalButton = TotalButtons;  //Update number of total buttons

        SetCountText(); //Update score
        PannelsArray[i].SetActive(false);//Unactivate already solved pannel and activate next one

        i = Random.Range(0, 59);
        print("NUmber"+i);
        PannelsArray[i].SetActive(true);
        
   
        if (ray.JustChangedVisionToPannels) //In case you have just changed your view to the pannel and it?s the first button pushed, log time (too keep log of time between seeing and acting)
        {
          PlayerStats.pilotStats.FirstButton.Add(clock); 
          ray.JustChangedVisionToPannels = false;

        }
       


    }

   



}
