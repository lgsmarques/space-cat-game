using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolim : MonoBehaviour
{
    public float jumpForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f , jumpForce), ForceMode2D.Impulse);
        }

    }
}
