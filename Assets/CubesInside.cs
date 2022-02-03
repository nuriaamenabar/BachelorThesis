using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesInside : MonoBehaviour
{
    public WhereIsCube[] whereis;
    public int CubesInBox;
    public GameObject box;

    void Start()
    {
        
    }

    void Update()
    {
        CubesInBox = 0;
        for (int i = 0; i < whereis.Length; i++) 
        {
           
            if (whereis[i].inGreenBox == true && box.tag=="GreenBox") CubesInBox++;
            if (whereis[i].inPinkBox == true  && box.tag =="PinkBox") CubesInBox++;
            if (whereis[i].inGreenText == true && box.tag == "GreenBoxTextured") CubesInBox++;
            if (whereis[i].inPinkText == true && box.tag == "PinkBoxTextured") CubesInBox++;
            if (whereis[i].inGreenSmooth == true && box.tag == "GreenBoxSmooth") CubesInBox++;
            if (whereis[i].inPinkSmooth == true && box.tag == "PinkBoxSmooth") CubesInBox++;

        }

    }
    
}

