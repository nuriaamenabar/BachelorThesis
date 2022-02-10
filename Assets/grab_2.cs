using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Since the robot crashes if the cubes he has to pick up are too close, and also there´s not so much space to put
 * the grabbables and the robot can reach them, Not so many grabbables can be at the table at the same time
 * 
 * Thats why there´s 4 different sets of cubes, that appear consecutevely: once first set has been sorted by the robot,
 * the second appears, etc.
 * 
 * This script activates the grabbables once the previous set has been already sorted by the robot--> robot has no moe cubes to sort
 * 
 * It has the 2d, 3rd and 4th sets of grabbables (Since first one will be always active) as arguments, as well as prova (The robot´s automatic publisher) to keep track of 
 * if the activation is necessary.
 * 
 * It is a component of the first set of grabbable (Grab)
 * 
 * 
 */



public class grab_2 : MonoBehaviour
{
    public GameObject grab2;
    public GameObject grab3;
    public GameObject grab4;
    public prova pr;


    void Start()
    {
        grab2.SetActive(false);
        grab3.SetActive(false);
        grab4.SetActive(false);

    }

    void Update()
    {
        if (pr.cont > 15) grab2.SetActive(true);

        if (pr.cont > 29) grab3.SetActive(true);

        if (pr.cont > 42) grab4.SetActive(true);


    }
}
