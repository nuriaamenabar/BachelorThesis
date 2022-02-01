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
    public Lookray ray;
    private float clock = 0;
    private float changedview;
    private float lastFeedback;
    public FeedbackController feedb;

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
    void Update() { clock += Time.deltaTime; }

    void SetCountText()
    {
        countText.text =  score.ToString();

    }

    public void Change(GameObject button)
    {
        TotalButtons++;
        if (PannelsArray[i].tag == button.tag) score++;
        PlayerStats.pilotStats.score.Add(score);
        PlayerStats.pilotStats.totalButton = TotalButtons;

        SetCountText();
        PannelsArray[i].SetActive(false);
        PannelsArray[i+1].SetActive(true);
        i = i + 1;
        Debug.Log(i);
        if (ray.JustChangedVisionToPannels) 
        { changedview = ray.TimeChangedVisionToPannels;
          PlayerStats.pilotStats.ViewingToPressing.Add(clock-changedview ); 
          ray.JustChangedVisionToPannels = false;
          lastFeedback = feedb.FeedbackActivatedIn;
          PlayerStats.pilotStats.FeedbackToPressing.Add(clock - lastFeedback);

        }
       


    }

   



}
