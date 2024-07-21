using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float horz;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    private SpriteRenderer sprite;
    private Animator anim;
   // [SerializeField]private bool Jump_Rig;
   // [SerializeField] private bool walk_Rig;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isGrounded = false; // تأكد من إن القيمة المبدئية False
        isJumping = false;  // تأكد من إن القيمة المبدئية False
    }

    private void Update()
    {
        horz = Input.GetAxis("Horizontal");
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        if (horz < 0)
        {
            sprite.flipX = true;
            anim.SetBool("Run", true);
        }
        else if (horz > 0)
        {
            sprite.flipX = false;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
     
           Vector3 movement = new Vector3(horz * speed * Time.deltaTime, 0, 0);
           transform.position += movement;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //علي الأرضية tag Ground لا تنسي وضع
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}



