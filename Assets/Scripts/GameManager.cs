using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string userName = "NEW";
    // [HideInInspector]
    public bool isGameStarted = false;
    private const string USERNAME = "USERNAME";
    private const string HIGHSCORE = "HIGHSCORE";
    public float highScore = 0;
    public int level;

    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI setUserName;
    private void OnEnable()
    {
        // Player.PlayerDied += RestartLevel; 
    }
    public float[] bestTimes; // Array to store best times for each level
    private float startTime;
    private int currentLevel;
    [SerializeField] private GameObject completeLevelText;
    [SerializeField]
    private bool checkForLevelCompletion;

    private void Start()
    {
        
        isGameStarted = false;
        bestTimes = new float[6]; // 5 levels, so 5 slots for best times
        LoadBestTimes(); // Load best times from PlayerPrefs
        
        StartLevel(level); // Start with level 0 (or your starting level)
        if (checkForLevelCompletion && AllLevelsCompleted())
        {
            
            // AllLevelsCompleted();
            // if(highScore == 0)
            highScore = TotalTimeTaken();
            PlayerPrefs.SetFloat(HIGHSCORE, highScore);
            Debug.Log("highscore is " + highScore);
        }
    }
    private float TotalTimeTaken()
    {
        float score = 0;
        for (int i = 1; i <= 5; i++)
        {
            score += bestTimes[i];
        }

        return score;
    }
    private bool AllLevelsCompleted()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (bestTimes[i] == 0)
            {
                Debug.Log("one level is not complete");
                completeLevelText.SetActive(true);
                return false;
            }
        }
        Debug.Log("all levels are complete");
        completeLevelText.SetActive(false);
        return true;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey(USERNAME))
        {
            Debug.Log("Has key username");
            if (PlayerPrefs.GetString(USERNAME, "") == "")
            {
                // Debug.Log();
                PlayerPrefs.SetString(USERNAME, userName);
                PlayerPrefs.SetFloat(HIGHSCORE, 0);
            }
            else
            {
                highScore = PlayerPrefs.GetFloat(HIGHSCORE);
            }
            
            Debug.Log("score is set to " + highScore + " in game manager");
        }
        else
        {
            PlayerPrefs.SetString(USERNAME, userName);
            PlayerPrefs.SetFloat(HIGHSCORE, 0);
            highScore = 0;
        }
        PlayerPrefs.Save();
    }

    
    public void SetUserName()
    {
        userName = nameField.text;
        PlayerPrefs.DeleteKey(USERNAME);
        PlayerPrefs.SetFloat(HIGHSCORE, 0);
        highScore = 0;
        PlayerPrefs.SetString(USERNAME, userName);
        PlayerPrefs.Save();
        //Reset score values
        // ResetAll();
        Debug.Log("Name is " + userName);
    }
    private void RestartLevel(object sender, EventArgs eventArgs)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        // Player.PlayerDied -= RestartLevel;
        isGameStarted = false;
    }

    void StartLevel(int level)
    {
        startTime = Time.time; // Record the starting time for the level
        currentLevel = level;
        // Start your level here (load scene, setup level, etc.)
    }

    public void FinishLevel()
    {
        float levelTime = Time.time - startTime; // Calculate time taken for the level

        // Check if the current time is better than the previously stored best time
        if (levelTime < bestTimes[currentLevel] || bestTimes[currentLevel] == 0)
        {
            bestTimes[currentLevel] = levelTime; // Update the best time for this level
            PlayerPrefs.SetFloat("BestTime_Level_" + currentLevel, levelTime); // Save the best time to PlayerPrefs
            Debug.Log("finished level " + currentLevel + " in " + levelTime + " seconds");
            PlayerPrefs.Save(); // Save PlayerPrefs to disk
        }
    }

     public void ResetAll()
    {
        for (int i = 1; i <= 5; i++)
        {
            PlayerPrefs.SetFloat("BestTime_Level_" + i, 0);
            bestTimes[i] = 0; // Load best times from PlayerPrefs
        }
    }

    void LoadBestTimes()
    {
        for (int i = 1; i <= 5; i++)
        {
            float savedTime = PlayerPrefs.GetFloat("BestTime_Level_" + i, 0);
            bestTimes[i] = savedTime; // Load best times from PlayerPrefs
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
