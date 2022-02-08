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
        System.IO.File.WriteAllText(Application.dataPath + "/StudyResults/" + participant + "/" +fileName, statsJson);

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
    public float startTime = 0;
    public List<int> score = new List<int>();
    public int totalButton = 0;
    public List<float> ChangeViewToPanels = new List<float>();
    public List<float> ChangeViewToRobot = new List<float>();
    public List<float> FirstButton = new List<float>();//First button pressed after changing view to the secondary task
    public List<float> interpolationFeedback = new List<float>();
    public List<float> TimeViewingPanel = new List<float>();
    public List<float> TimeViewingRobot = new List<float>();
    public List<float> FirstGrabbed = new List<float>();//Firstobject grabbed after changing view to the primary task
    public List<int> CubesInGreenBoxWhenStartedLooking = new List<int>();
    public List<int> CubesInPinkBoxWhenStartedLooking = new List<int>();
    public List<int> mistakesClass = new List<int>();
    public List<int> correctClass = new List<int>();

    






}