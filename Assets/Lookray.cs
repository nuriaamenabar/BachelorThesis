using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookray : MonoBehaviour
{
    Camera cam;
    public bool inrobot;
    public bool inbutton;
    private bool last = true;
    public bool JustChangedVisionToPannels = true;
    public bool JustChangedVisionToRobot = false;
    public bool JustChangedVisionToRobot_count1 = false;
    public bool JustChangedVisionToRobot_count2 = false;
    public bool JustChangedVisionToPannels_count = true;

    private float clock = 0f;
    private float lastFeedback;
    public FeedbackController feedb;
    public float TimeChangedVisionToPannels;
    public float TimeChangedVisionToRobot;


    void Start()
    {
        print("ffff");
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        clock += Time.deltaTime;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){ print("I'm looking at " + hit.transform.name);
            lastFeedback = feedb.FeedbackActivatedIn;
            if (hit.transform.name == "button task") { 
                inbutton = true;
                inrobot = false;
                if (last != inbutton)
                {
                    JustChangedVisionToPannels = true;
                    JustChangedVisionToPannels_count = true; //assistant variable only to help count cubes
                    TimeChangedVisionToPannels = clock;
                    PlayerStats.pilotStats.ChangeViewToPanels.Add((clock));
                    PlayerStats.pilotStats.TimeViewingRobot.Add(TimeChangedVisionToPannels-TimeChangedVisionToRobot);
                    last = inbutton;
                }
            }
            if (hit.transform.name == "robot task") {
                inbutton = false; 
                inrobot = true;
                if (last != inbutton) { 
                    JustChangedVisionToRobot = true;
                    JustChangedVisionToRobot_count1 = true;
                    JustChangedVisionToRobot_count2 = true;
                    TimeChangedVisionToRobot = clock;
                    PlayerStats.pilotStats.TimeViewingPanel.Add(TimeChangedVisionToRobot-TimeChangedVisionToPannels);
                    PlayerStats.pilotStats.ChangeViewToRobot.Add(clock);
                    last = inbutton;
                }

            }
            
        }
       // if (hit.transform.name == "button task") inbutton = true;



        else
            print("I'm looking at nothing!");
    }
}


