using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPurple : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject plataforma;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Plataforma verde");
        plataforma.SetActive(false);
    }
}