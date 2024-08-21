using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    [SerializeField] bool isPaused;
    public bool IsPaused{ get { return isPaused; } }

    private void Awake()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetIsPaused(bool value)
    {
        isPaused = value;
    }

}
