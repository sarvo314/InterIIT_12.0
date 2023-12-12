using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator transitionAnim;
    private const string LEVEL_1 = "Level1";
    private const string LEVEL_2 = "Level2";
    private const string LEVEL_3 = "Level3";
    private const string LEVEL_4 = "Level4";
    private const string LEVEL_5 = "Level5";
    
    private const string MAIN_MENU = "MainMenu";
    private const string LEVEL_SELECT = "LevelSelect";
    private const string LEADERBOARD = "Leaderboard";
    private const string INSTRUCTIONS = "Instructions";
    private const string OPTIONS = "Options";
    private const string HIGHSCORE = "Highscore";
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevelSelect()
    {
        // SceneManager.LoadScene("LevelSelect");
        StartCoroutine(LoadScene(LEVEL_SELECT));
    }
    

    public void GoToMainMenu()
    {
        Debug.Log("we go to mainmenu");
        // SceneManager.LoadScene();
        StartCoroutine(LoadScene(MAIN_MENU));
    }

    public void LevelSelect(int level)
    {
        // SceneManager.LoadScene(level.ToString());
        StartCoroutine(LoadScene(level.ToString()));
    }
    public void DisplayLeaderboard()
    {
        Debug.Log("we go to leaderboard");
        // SceneManager.LoadScene("Leaderboard");
        StartCoroutine(LoadScene(LEADERBOARD));
    }
    
    public void DisplayInstructions()
    {
        Debug.Log("we go to instructions");
        // SceneManager.LoadScene("Instructions");
        StartCoroutine(LoadScene(INSTRUCTIONS));
    }

    public void LeaderBoard()
    {
        
        // SceneManager.LoadScene("Highscore");
        StartCoroutine(LoadScene(LEADERBOARD));
    }
    

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void GoToOptions()
    {
        StartCoroutine(LoadScene(OPTIONS));
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
