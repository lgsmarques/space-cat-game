using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void AfterPause()
    {
        Time.timeScale = 1;
    }

    #region ScreePause
    [Header("Screen Pause")]
    public GameObject screenPause;

    void Update()
    {
        ESCPause();
    }

    void ESCPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            screenPause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    #endregion
}
