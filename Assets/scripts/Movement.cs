using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sleep(1) = System.Threading.Thread.Sleep(1000)
public class playerscript : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    private Animator anim;
    public float jetpackforce = 50f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("j"))
        {
            if (isGrounded == false)
            {
                rb.AddForce(new Vector2(0, jetpackforce));
            }
        }






        DoJump();
        DoMove();
    }
    /*private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 0.5f);
        }
        else if (velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 0.5f);
        }
    }*/



    private void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("grounded", true);
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("grounded", false);
        isGrounded = false;
    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space") || Input.GetKeyDown("up")) && (isGrounded == true))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 7f;    // give the player a velocity of something in the y axis

            }
        }

        rb.velocity = velocity;

    }

    void DoMove()
    {
        anim.SetBool("walkright", false);
        anim.SetBool("walkleft", false);

        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            anim.SetBool("walkleft", true);
            velocity.x = -5f;
        }

        // check for moving right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            anim.SetBool("walkright", true);

            velocity.x = 5f;
        }
        rb.velocity = velocity;

    }

        

}













