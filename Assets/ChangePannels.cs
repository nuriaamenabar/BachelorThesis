using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePannels : MonoBehaviour
{
    public GameObject[] PannelsArray;
    private int i;
    void Start()
    {
        i = 0;
        foreach(GameObject Pannel in PannelsArray)
        {
            Pannel.SetActive(false);
        }
        PannelsArray[0].SetActive(true);       
    }

    public void Change()
    {
        PannelsArray[i].SetActive(false);
        PannelsArray[i+1].SetActive(true);
        i = i + 1;
        Debug.Log(i);
    }
}