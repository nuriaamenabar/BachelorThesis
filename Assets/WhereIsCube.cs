using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script attached to every cube/grabbable, it checks where the grabbbableis
 * 
 
 * 
 */



public class WhereIsCube : MonoBehaviour
{
    public bool inGreenBox=false;//All possibilities of where cube can be. In the beggining, nowhere
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
        //The location of the cube is updated everytime it collides with something. Then it stops being in th elast place and it is in the next one

        if (other.gameObject.CompareTag("GreenBox") && inGreenBox == false) { inGreenBox = true; }//Two main boxes (classified by robot)
        if (other.gameObject.CompareTag("PinkBox") && inPinkBox == false) { inPinkBox = true; }

        if (other.gameObject.CompareTag("PinkBoxSmooth") && inPinkSmooth == false) { inPinkSmooth = true; }
        if (other.gameObject.CompareTag("PinkBoxTextured") && inPinkText == false) { inPinkText = true;  }
        if (other.gameObject.CompareTag("GreenBoxSmooth") && inGreenSmooth == false) { inGreenSmooth = true; }
        if (other.gameObject.CompareTag("GreenBoxTextured") && inGreenText == false) { inGreenText = true; }
        if (other.gameObject.CompareTag("floor")) { inPinkBox = false; inGreenBox = false; }//In case it falls, otherwise it doesnt get detected as its not in the boxes



    }




    private void OnTriggerExit(Collider other)
    {
        //The location of the cube is updated everytime it collides with something. Then it stops being in th elast place and it is in the next one

        if (other.gameObject.CompareTag("GreenBox") ) { inGreenBox = false; }//Two main boxes (classified by robot)
        if (other.gameObject.CompareTag("PinkBox") ) { inPinkBox = false; }
        //Since other boxes are holes once thay are in they will never stop being there, so no need to 



    }


}
