using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer: MonoBehaviour
{
    public float clock = 0;
    private bool ison = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ison) { clock += Time.deltaTime; }


    }
    void StartTime()
    { 
    
    
    }


}
