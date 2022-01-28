using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookray : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        print("ffff");
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            print("I'm looking at " + hit.transform.name);
        else
            print("I'm looking at nothing!");
    }
}


