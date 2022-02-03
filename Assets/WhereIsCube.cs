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

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBox") && inGreenBox == false) { inGreenBox = true; }
        if (other.gameObject.CompareTag("PinkBox") && inPinkBox == false) { inPinkBox = true; }
        // if (){inGrabbed=tre, la resta false}
        if (other.gameObject.CompareTag("PinkBoxSmooth") && inPinkSmooth== false) { inPinkSmooth = true; inGrabbed = false; }
        if (other.gameObject.CompareTag("PinkBoxTextured") && inPinkText== false) { inPinkText = true; inGrabbed = false; }
        if (other.gameObject.CompareTag("GreenBoxSmooth") && inGreenSmooth== false) { inGreenSmooth= true; inGrabbed = false; }
        if (other.gameObject.CompareTag("GreenBoxTextured") && inGreenText == false) { inGreenText = true; inGrabbed = false; }

    }
}
