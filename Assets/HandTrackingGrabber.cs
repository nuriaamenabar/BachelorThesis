using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

//From the oculus package for hand tracking, havent modified anything from here

public class HandTrackingGrabber : OVRGrabber
{
    private OVRHand hand;
    public float pinchTreshold = 0.7f;
    public bool GrabbedSomething = false;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
        
    }

    public override void Update()
    {
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchTreshold;
        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
        { GrabBegin(); GrabbedSomething = true; } 

        else if (m_grabbedObj && !isPinching)
            GrabEnd();

    }
}
