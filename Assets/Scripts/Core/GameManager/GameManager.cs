using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    #region LoadLevel
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }
    #endregion

    #region Pause
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void AfterPause()
    {
        Time.timeScale = 1;
    }
    #endregion

    void Update()
    {
        ESCPause();
    }

    #region ScreePause
    [Header("Screen Pause")]
    public GameObject screenPause;

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
