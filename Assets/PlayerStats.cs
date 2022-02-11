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
    public static string participant = "P5";


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
    public List<string>  scene= new List<string>();
    public string surveilance = "";
    public float startTime = 0;
    public List<int> score = new List<int>();
    public int totalButton = 0;
    public List<float> ChangeViewToPanels = new List<float>();//Tim
    public List<float> ChangeViewToRobot = new List<float>();

    public List<float> FirstButton = new List<float>();//Time ofFirst button pressed after changing view to the secondary task
    public List<float> FirstGrabbed = new List<float>();//Time of First obj grabbed after changing view to the robot task

    public List<float> Feedback = new List<float>();//Time feedback is activated
    public List<float> TimeViewingPanel = new List<float>();//Time spent each time looking at secondary tas
    public List<float> TimeViewingRobot = new List<float>();//Time spent each time looking at robot

    public List<int> CubesInGreenBoxWhenStartedLooking = new List<int>();
    public List<int> CubesInPinkBoxWhenStartedLooking = new List<int>();
    public List<int> mistakesClass = new List<int>();//Cubes wrongly classified
    public List<int> correctClass = new List<int>();//Cubes correctly classified

    public List<float> GreenBoxFilled = new List<float>();//Time Green box is filled
    public List<float> PinkBoxFilled = new List<float>();//""""Pink""
    public List<float> GreenBoxEmptied = new List<float>();//Time Green box is emptied
    public List<float> PinkBoxEmptied = new List<float>();//Time Pink box is emptied









}