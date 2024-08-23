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
}
