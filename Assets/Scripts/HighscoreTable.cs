using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class HighScoreEntry
{
    public int score;
    public string name;

    //public int Score
    //{
    //    get
    //    {
    //        return score;
    //    }
    //}
    //public string Name
    //{
    //    get
    //    {
    //        return name;
    //    }
    //}
    //public HighScoreEntry(string name, int score)
    //{
    //    this.score = score;
    //    this.name = name;
    //}


}

public class HighScoreTable : MonoBehaviour
{
    [SerializeField]
    private Transform entryContainer;
    [SerializeField]
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;


    //stores highscores
    public static Dictionary<string, int> ScoreTable
        = new Dictionary<string, int>
        {

        };

    private void OnEnable()
    {
       // AddHighScoreEntry(PlayerPrefs.GetInt("HIGHSCORE"), PlayerPrefs.GetString("USERNAME")); 
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteKey("highscoreTable");

        // entryContainer = transform.Find("HighScoreEntryContainer");
        // entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighScoreEntry(10000, "sarvo");
        //AddHighScoreEntry(100, "sarvo");

        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ name = "sarvo", score = 1000},
            new HighScoreEntry{ name = "ishan", score = 3000},
            new HighScoreEntry{ name = "rahul", score = 2000}
        };


        //MY CODE
        //string jsonString = 

        //

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        if (jsonString == "")
        {
            Highscores highscore = new Highscores { highscoreEntryList = highScoreEntryList };
            string json = JsonUtility.ToJson(highscore);
            Debug.Log($"json is {json}");
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        //PlayerPrefs.GetString("highscoreTable");

        //Sort entry list
        if (jsonString != "" || highscores != null)
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        //swap
                        (highscores.highscoreEntryList[i], highscores.highscoreEntryList[j]) = (highscores.highscoreEntryList[j], highscores.highscoreEntryList[i]);
                    }
                }
            }

        }


        highScoreEntryTransformList = new List<Transform>();
        //if (highscores.highscoreEntryList.Count < 6)
        int k = 0;


        foreach (HighScoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            if (k < 5)
                CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
            else
            {
                PlayerPrefs.DeleteKey("highscoreTable");

                break;
            }
            ++k;
        }



    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry,
        Transform container, List<Transform> transformList)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;
        int score = highScoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }
    public static void AddHighScoreEntry(int score, string name)
    {
        //Create highscore entry
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name };

        //load saved highscore
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        bool entryPresent = false;
        //add new entry
        foreach (var item in highscores.highscoreEntryList)
        {
            //if name is present update it
            if (item.name == name)
            {
                if (score > item.score)
                    item.score = score;
                entryPresent = true;
                break;
            }
        }

        if (!entryPresent) highscores.highscoreEntryList.Add(highscoreEntry);
        //highscores.highscoreEntryList.Add(highscoreEntry);

        //save updated
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    // [System.Serializable]
    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }
}


// using System.Collections;
// using System;
// using System.Collections.Generic;
// using TMPro;
// using Unity.VisualScripting;
// using UnityEngine;
//
// public class HighscoreTable : MonoBehaviour
// {
//     [SerializeField] private Transform entryContainer;
//     [SerializeField] private Transform entryTemplate;
//     private List<HighScoreEntry> highScoreEntryList;
//     private List<Transform> highScoreEntryTransformList;
//     [SerializeField] private float fieldScale;
//     
//     public static HighscoreTable Instance { get; private set; }
//     private void Awake()
//     {
//         highScoreEntryList = new List<HighScoreEntry>
//         {
//             
//         };
//         entryTemplate.gameObject.SetActive(false);
//         AddHighScoreEntry(13, "jnk");
//         string jsonString = PlayerPrefs.GetString("highscoreTable");
//         HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
//         highScoreEntryTransformList = new List<Transform>();
//        
//         //sort list by score (descending)
//          
//         // for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
//         // {
//         //     for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
//         //     {
//         //         if (highScores.highScoreEntryList[j].score < highScores.highScoreEntryList[i].score)
//         //         {
//         //             //swap
//         //             (highScores.highScoreEntryList[i], highScores.highScoreEntryList[j]) = (highScores.highScoreEntryList[j], highScores.highScoreEntryList[i]);
//         //         }
//         //     }
//         // }
//
//         foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
//         {
//             
//             CreateHighscoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
//         }
//
//     }
//
//     public void AddHighScoreEntry(int score, string name)
//     {
//         //create highscore entry
//         HighScoreEntry highScoreEntry = new HighScoreEntry {score = score, name = name};
//         //load saved highscore
//         string jsonString = PlayerPrefs.GetString("highscoreTable");
//         Debug.Log(jsonString);
//         HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
//
//         
//         //Add new entry to highscores
//         highScores.highScoreEntryList.Add(highScoreEntry);
//         //Save updated highscores
//         string json = JsonUtility.ToJson(highScores);
//         Debug.Log("Succesfully added name " + name);
//         PlayerPrefs.SetString("highscoreTable", json);
//         PlayerPrefs.Save();
//     }
//     
//     private void CreateHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
//     {
//         float templateHeight = 20f;
//         Transform entryTransform = Instantiate(entryTemplate);
//         entryTransform.SetParent(container);
//         entryTransform.localScale = new Vector3(1, 1, 1) * fieldScale;
//         RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
//         entryRectTransform.anchoredPosition3D = new Vector3(0, -templateHeight * transformList.Count, 0);
//         // entryRectTransform.transform.position = new Vector3(entryRectTransform.transform.position.x, entryRectTransform.transform.position.y, 0);
//         entryTransform.gameObject.SetActive(true);
//
//         int score = highScoreEntry.score;
//
//         entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
//
//         string name = highScoreEntry.name;
//         entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
//
//         transformList.Add(entryTransform);
//     }
// }
//
// public class HighScores
// {
//     public List<HighScoreEntry> highScoreEntryList;
//     public HighScores()
//     {
//         highScoreEntryList = new List<HighScoreEntry>();
//     }
// }
//
// [System.Serializable]
// public class HighScoreEntry
// {
//     public int score;
//     public string name;
// }