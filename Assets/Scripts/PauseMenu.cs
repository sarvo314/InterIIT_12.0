using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string scene;
    private const string MAIN_MENU = "MainMenu";
    public static bool isPaused = false;
    public static bool isShownHint = false;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject HintUI;
    [SerializeField] private GameObject HintButton;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private Animator transitionAnim;
    
    private void Awake() {
        scene = SceneManager.GetActiveScene().name;
    }
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
    public void Hint(){
        HintUI.SetActive(!isShownHint);
        isShownHint = !isShownHint;
        
    }
    public void Resume(){
        HintUI.SetActive(isShownHint);
        PauseUI.SetActive(false);
        HintButton.SetActive(true);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause(){
        HintUI.SetActive(false);
        PauseUI.SetActive(true);
        HintButton.SetActive(false);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart(){
        StartCoroutine(LoadScene(scene));
    }

    public void MainMenu(){
        StartCoroutine(LoadScene(MAIN_MENU));
    }
    
    public void Quit(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    IEnumerator LoadScene( string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
