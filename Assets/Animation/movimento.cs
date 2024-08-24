using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    private float horizontalImput;
    private Rigidbody2D rb;

    [SerializeField] private int velocidade = 5;

    [SerializeField] private Transform PedoPersonagem;
    [SerializeField] private LayerMask ChaoLayer;

    private bool estaNoChao;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int movendoHash = Animator.StringToHash("movendo");
    private int pulandoHash = Animator.StringToHash("pulando");


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        horizontalImput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {

            rb.AddForce(Vector2.up * 600);
        }

        estaNoChao = Physics2D.OverlapCircle(PedoPersonagem.position, 0.2f, ChaoLayer);

        animator.SetBool(movendoHash, horizontalImput != 0);
        animator.SetBool(pulandoHash, !estaNoChao);

        if (horizontalImput > 0)
        {
            spriteRenderer.flipX = false;
        }



        else if (horizontalImput < 0)
        {

            spriteRenderer.flipX = true;
        }
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalImput * velocidade, rb.velocity.y);
    }
}
