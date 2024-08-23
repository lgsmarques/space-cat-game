using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody2D myRigidbody;

    [Header("Movement")]
    public float speed = 10f;
    public float forceJump = 20f;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation Player")]
    public float playerSwipeDuration = .1f;

    [Header("Jump Check")]
    public Collider2D collider2D;
    public float disToGround;
    public float spaceToGround = .1f;

    public Transform positionTransform;

    Vector3 parentScale;
    Vector3 selfScale;
    Vector3 scale;

    private void Awake()
    {
        if (collider2D != null)
        {
            disToGround = collider2D.bounds.extents.y;
        }
    }

    private void Start()
    {
        positionTransform = GetComponent<Transform>();
    }

    void Update()
    {
        IsGrounded();
        HandleMovement();
        HandleJump();
    }

    #region Movimento
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, disToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, disToGround + spaceToGround);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && IsGrounded())
        {
            myRigidbody.velocity = Vector2.up * forceJump;
        }
    }
    #endregion
}
