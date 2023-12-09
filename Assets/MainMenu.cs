using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToMainMenu()
    {
        Debug.Log("we go to mainmenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level.ToString());
    }
    public void DisplayLeaderboard()
    {
        Debug.Log("we go to leaderboard");
        SceneManager.LoadScene("Leaderboard");
    }
    public void DisplayInstructions()
    {
        Debug.Log("we go to instructions");
        SceneManager.LoadScene("Instructions");
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
        SceneManager.LoadScene("Options");
    }
}
