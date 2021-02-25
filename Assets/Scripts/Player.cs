using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private CapsuleCollider2D circle;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Recebe o componente RigidBody2D que está anexado ao Player.
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Move para a esquerda e direita.
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walkRight", true);
            anim.SetBool("jump", false);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walkLeft", true);
            anim.SetBool("jump", false);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walkRight", false);
            anim.SetBool("walkLeft", false);
        }
    }

    void Jump()
    {
        // Se o botão para pular (espaço) for pressionado.
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                // Pula.
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    // Pula.
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("jump", true);
                }
            }
        }
    }

    // Método padrão da Unity para detectar colisão.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            GameControler.instance.ShowGameOver();
            sr.enabled = false;
            circle.enabled = false;
        }
    }

    // Detecta quando o objeto para de tocar alguma coisa.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
