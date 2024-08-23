using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPurple : MonoBehaviour
{
    public GameObject plataforma;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        plataforma.SetActive(false);
    }
}