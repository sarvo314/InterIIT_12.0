using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string menu = "MainMenu";
    public static bool isPaused = false;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject PauseButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Resume(){
        PauseUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause(){
        PauseUI.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu(){
        SceneManager.LoadScene(menu);
    }
    
    public void Quit(){
        Application.Quit();
    }
}
