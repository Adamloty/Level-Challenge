using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    private float horz;
    [SerializeField] private float speed=50;
    [SerializeField] private float Jump=10;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isJumping;
    [SerializeField] private bool isGroundedFunc;
    private SpriteRenderer sprite;
   // private float vert;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        sprite= GetComponent<SpriteRenderer>();
       // Jump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        if(horz<0)
        {
            sprite.flipX= true;
        }
        else if(horz>0)
        {
            sprite.flipX = false;
        }
        //vert = Input.GetAxis("Vertical");
        if(isGroundedFunc)
        {
            if (isGrounded)
            {
                transform.position += new Vector3(horz * speed * Time.deltaTime, 0, 0);
                //rb.velocity = new Vector3(horz * speed * Time.deltaTime, Jump);
            }
        }
        else
        {
            transform.position += new Vector3(horz * speed * Time.deltaTime, 0, 0);
            // rb.velocity = new Vector3(horz * speed * Time.deltaTime, Jump);
        }
   
        if(Input.GetKeyDown(KeyCode.Space)&&!isJumping)
        {
            rb.velocity = new Vector3(0, Jump);
            // Jump = 50;
            //قفز اللاعب
            isJumping = true;
            //لم يلمس الأرض بعد
            isGrounded = false;
        }
      //  if(isJumping)
       // {
      //      Jump = 0;
      //  }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ground tagمع مراعاة وضع علي الأرضية 
        if (collision.collider.CompareTag("Ground"))
        {
            //يلمس الأرض
            isGrounded = true;
            //لم يقفز اللاعب بعد
            isJumping=false;
        }
        else
        {
            //لا يلمس الأرض
            isGrounded= false;
        }
    }
}
