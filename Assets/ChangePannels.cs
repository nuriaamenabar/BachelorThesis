using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangePannels : MonoBehaviour
{
    public GameObject[] PannelsArray;
    public Physicsbutton physbut;
    private int i;
    public int score = 0;
    public TextMeshProUGUI countText;
    public int TotalButtons;
    void Start()
    {
        SetCountText();
        i = 0;
        foreach(GameObject Pannel in PannelsArray)
        {
            Pannel.SetActive(false);
        }
        PannelsArray[0].SetActive(true);       
    }
    void SetCountText()
    {
        countText.text =  score.ToString();

    }

    public void Change(GameObject button)
    {
        TotalButtons++;
        if (PannelsArray[i].tag == button.tag) score++;
        SetCountText();
        PannelsArray[i].SetActive(false);
        PannelsArray[i+1].SetActive(true);
        i = i + 1;
        Debug.Log(i);
        
    }

   



}
