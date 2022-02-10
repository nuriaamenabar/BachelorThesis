using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereIsCube : MonoBehaviour
{
    public bool inGreenBox=false;
    public bool inPinkBox = false;
    public bool inPinkSmooth = false;
    public bool inPinkText = false;
    public bool inGreenSmooth = false;
    public bool inGreenText = false;
    public bool inGrabbed = false;
    public bool correctClas;
    public bool wrongClas;
    public GameObject cube;

    void Start()
    {
        
    }

    void Update() 
    {
        //If it is in one of the boxes, check if its correctly classified
        if (inPinkSmooth)
        { if (cube.tag == "PinkS") correctClas = true;
          else wrongClas=true; }
        if (inPinkText) {
            if (cube.tag == "PinkT") correctClas = true;
            else wrongClas=true;
        }
        if (inGreenSmooth) {
            if (cube.tag == "GreenS") correctClas = true;
            else wrongClas=true;
        }
        if (inGreenText) {
            if (cube.tag == "GreenT") correctClas = true;
            else wrongClas=true;
        }


}




    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBox") && inGreenBox == false) { inGreenBox = true; }
        if (other.gameObject.CompareTag("PinkBox") && inPinkBox == false) { inPinkBox = true; }
        // if (){inGrabbed=tre, la resta false}
        if (other.gameObject.CompareTag("PinkBoxSmooth") && inPinkSmooth== false) { inPinkSmooth = true; inGrabbed = false; inGreenBox = false; inPinkBox = false; }
        if (other.gameObject.CompareTag("PinkBoxTextured") && inPinkText== false) { inPinkText = true; inGrabbed = false; inGreenBox = false; inPinkBox = false; }
        if (other.gameObject.CompareTag("GreenBoxSmooth") && inGreenSmooth== false) { inGreenSmooth= true; inGrabbed = false; inGreenBox = false; inPinkBox = false; }
        if (other.gameObject.CompareTag("GreenBoxTextured") && inGreenText == false) { inGreenText = true; inGrabbed = false; inGreenBox = false; inPinkBox = false; }



    }
}
