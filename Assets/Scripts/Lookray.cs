using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookray : MonoBehaviour
{
    Camera cam;
    public bool inrobot;
    public bool inbutton;

    void Start()
    {
        print("ffff");
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){ print("I'm looking at " + hit.transform.name);
            if (hit.transform.name == "button task") { inbutton = true; inrobot = false; }
            if (hit.transform.name == "robot task") { inbutton = false; inrobot = true; }
        }
       // if (hit.transform.name == "button task") inbutton = true;



        else
            print("I'm looking at nothing!");
    }
}


