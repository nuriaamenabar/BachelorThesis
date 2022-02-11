using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Script that changes the math pannels once one button is pushed. Contains function "Change", called by each button when pushed (onPush())
 * Tracks scores, time when a button has been pushed and total buttons pushed. Component of the "ButtonsChangePannels" GameObject
 */
public class DemoChangeP : MonoBehaviour
{
    public GameObject[] PannelsArray; //Array containing all the panels. 
    private int i = 0;




    void Start()
    {
       

        foreach (GameObject Pannel in PannelsArray)//Unactivates all the panels except for the first one in the array
        {
            Pannel.SetActive(false);
        }
        PannelsArray[0].SetActive(true);
    }


    public void Change()//Called each time a button is pushed
    {
       
        PannelsArray[i].SetActive(false);//Unactivate already solved pannel and activate next one
        PannelsArray[i + 1].SetActive(true);
        i++;


    }





}
