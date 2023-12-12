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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel.ToString());
        }
    }
}
