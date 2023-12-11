using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static string userName = "NEW";
    public static bool isGameStarted = false;
    private const string USERNAME = "USERNAME";
    private const string HIGHSCORE = "HIGHSCORE";
    public static int highScore = 0;

    [SerializeField] private TextMeshProUGUI nameField;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}