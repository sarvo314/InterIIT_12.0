/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using CodeMonkey.Utils;

public class HighscoreTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    [SerializeField] private GameManager gameManager;
    
    private void Awake() {
        // PlayerPrefs.DeleteAll();
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        // Debug.Log("We have highscore from highscore table " + PlayerPrefs.GetFloat("HIGHSCORE") + " and user name " + PlayerPrefs.GetString("USERNAME", null));
        // AddHighscoreEntry(PlayerPrefs.GetFloat("HIGHSCORE"), PlayerPrefs.GetString("USERNAME", null));
        // Debug.Log("we have to add entry" + gameManager.highScore + " " + gameManager.userName);
        AddHighscoreEntry(PlayerPrefs.GetFloat("HIGHSCORE"), PlayerPrefs.GetString("USERNAME", null));
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(80.23f, "SHI");
            
            AddHighscoreEntry(90.12f, "SHL");
            AddHighscoreEntry(80.12f, "RIT");
            AddHighscoreEntry(92.31f, "SAV");
            // AddHighscoreEntry(542024, "MAX");
            // AddHighscoreEntry(68245, "AAA");
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

            
        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score < highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        int k = 0;
        // HighScoreEntry
        int totalEntries = 10;
        foreach (HighscoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            if (k < totalEntries)
                CreateHighscoreEntryTransform(highScoreEntry, entryContainer, highscoreEntryTransformList);
            else
            {
                PlayerPrefs.DeleteKey("highscoreTable");

                break;
            }
            ++k;
        }

        // foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) 
        // {
        //     // DeviceType
        //     CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        // }
        // PlayerPrefs.DeleteKey("highScoreTable");
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;

        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        float score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = FormatTime(score);

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        Debug.Log("Spawned entry " + name + " " + FormatTime(score)); 
        // Highlight First
        if (rank == 1) {
            // entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            // entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            // entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        // Set tropy
        switch (rank) {
        default:
            entryTransform.Find("trophy").gameObject.SetActive(false);
            break;
        case 1:
            // entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
            break;
        case 2:
            // entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
            break;
        case 3:
            // entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
            break;

        }

        transformList.Add(entryTransform);
    }
    string FormatTime(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60);
        int seconds = Mathf.FloorToInt(totalSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void AddHighscoreEntry(float score, string name)
    {
        if (string.IsNullOrEmpty(name)) return;  
        if (name == "" || name == null) return;
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        Debug.Log("We added entry" + name + " " + score);
        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    private class HighscoreEntry {
        public float score;
        public string name;
    }

}
