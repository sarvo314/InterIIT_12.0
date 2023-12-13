using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private enum Levels
    {
        MainMenu,
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        Level_5
    };
    [SerializeField] private Levels nextLevel;
    [SerializeField] private Animator transitionAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel.ToString());
        }
    }
    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
