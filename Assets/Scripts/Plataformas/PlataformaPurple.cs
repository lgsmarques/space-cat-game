using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPurple : MonoBehaviour
{
    public GameObject plataforma;
    public float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        plataforma.SetActive(false);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    
    
        
    
}