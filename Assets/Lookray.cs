using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Basically for logging purposes. Chaécks where the participant is looking (Button task or Robot Task). It checks it by checking if camera is interacting
 * with one of the two invisible planes (corresponding to each task) that you can find in environment
 * 
 * It is a component of the center eye camera
 * 
 * 
 */



public class Lookray : MonoBehaviour
{
    Camera cam; 
    public bool inrobot; //True if participant is looking at robot
    public bool inbutton; //True if participant is lookig´ng at buttons task
    private bool last = true;
    public bool JustChangedVisionToPannels = true;//Auxiliar variable for logs. True when change view to Pannels, false when
    public bool JustChangedVisionToRobot = false;//Auxiliar variable 
    public bool JustChangedVisionToRobot_count1 = false;//Auxiliar variable 
    public bool JustChangedVisionToRobot_count2 = false;//Auxiliar variable 
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



        else
            print("I'm looking at nothing!");
    }
}


