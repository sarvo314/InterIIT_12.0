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
        Level1,
        Level2,
        Level3
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
