using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(player);
        GameManager.Instance.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
