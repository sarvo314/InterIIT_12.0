using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static string userName = "NEW";
    // [HideInInspector]
    public bool isGameStarted = false;
    private const string USERNAME = "USERNAME";
    private const string HIGHSCORE = "HIGHSCORE";
    public static int highScore = 0;

    [SerializeField] private TextMeshProUGUI nameField;

    private void OnEnable()
    {
        // Player.PlayerDied += RestartLevel; 
    }

    // Start is called before the first frame update
    private void Awake()
    {
        // Debug.Log("Value of is game started " + isGameStarted);
        // if (Instance == null)
        // {
        //     Instance = this;
        // }
        // else if (Instance != this)
        // {
        //     Destroy(gameObject);
        // }

        // DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey(USERNAME))
        {
            highScore = PlayerPrefs.GetInt(HIGHSCORE);
        }
        else
        {
            highScore = 0;
        }
    }

    public void SetUserName()
    {
        userName = nameField.text;
        PlayerPrefs.SetString(USERNAME, userName);
        PlayerPrefs.Save();
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

    void Start()
    {
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}