using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] public static PilotStats pilotStats = new PilotStats();
    public static string fileName;
    public static float startTime;
    public static float endTime;
    public static string participant = "P1";


    public void Start()
    {
        /*fileName = SceneManager.GetActiveScene().name + "_" + System.DateTime.Now + ".json";
        fileName = fileName.Replace(" ", "_");*/
        pilotStats.participant = participant;
        fileName = SceneManager.GetActiveScene().name + " " + System.DateTime.Now + ".json";
        fileName = fileName.Replace("/", "_");
        fileName = fileName.Replace(":", ".");
    }

    public void Update()
    {
        
    }

    public static void saveToJson()
    {
       
        string statsJson = JsonUtility.ToJson(pilotStats);
        Debug.Log(Application.dataPath);
        System.IO.File.WriteAllText(Application.dataPath + "/StudyResults/" + fileName, statsJson);

    }

    private void OnApplicationQuit()
    {
        Debug.Log("Exit");
        saveToJson();
    }


    
}

[System.Serializable]
public class PilotStats
{
    public string participant = "";
    public string scene = "";
    public List<int> score = new List<int>();
    public int totalButton = 0;
    public int mistakesGrabbables = 0;
    public int correctGrabbables = 0;
    public List<float> ViewingToAction = new List<float>(); //From start viewing until doing first action
    public List<float> FeedbackToAction = new List<float>(); //From start of feedback until doing first action
    public List<float> FeedbackToViewing = new List<float>();
    public List<float> interpolationFeedback = new List<float>();
    public List<float> ButtonToGrabbed = new List<float>();
    public List<float> GrabbedtoButton = new List<float>();
    public List<float> TimingViewingButton = new List<float>();
    public List<float> TimeViewingRobot = new List<float>();



}