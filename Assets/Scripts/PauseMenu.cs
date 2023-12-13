using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private const string MAIN_MENU = "MainMenu";
    public static bool isPaused = false;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private Animator transitionAnim;

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
        // SceneManager.LoadScene(menu);
        StartCoroutine(LoadScene(MAIN_MENU));
    }
    
    public void Quit(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
