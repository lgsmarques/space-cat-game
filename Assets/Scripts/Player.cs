using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public float speed = 10f;
    public float forceJump = 20f;
    public Vector2 friction = new Vector2(.1f, 0);

    void Start()
    {
        
    }
    
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
            //rigidbody2D.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
            //rigidbody2D.transform.localScale = new Vector3(1, 1, 1);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
        }
    }
}
