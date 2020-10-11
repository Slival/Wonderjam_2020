using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float airSpeed;
    public float cap;
    public bool goingLeft;
    public PlayerVariables pVar;
    public SpriteRenderer playerSprite;
    public bool idling;
    public bool jumping;

    private bool jumpAvailable = true;
    private float oldXVelocity;
    Rigidbody rb;

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;
        Debug.DrawRay(new Vector2(pos.x, pos.y) * 0.33f, Vector2.down);
        Debug.DrawRay(new Vector2(pos.x + 0.14f, pos.y) * 0.25f, Vector2.down);
        Debug.DrawRay(new Vector2(pos.x - 0.14f, pos.y) * 0.25f, Vector2.down);
    }



    private void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        oldXVelocity = 0;
        if (playerSprite == null)
        {
            playerSprite = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        }
        if (pVar == null)
        {
            gameObject.GetComponent<PlayerVariables>();
        }
    }

    void Update()
    {
        if (!pVar.isTyping)
        {
            CheckPlayerOrientation(Input.GetAxis("Horizontal"));

            UpdatePlayerOrientation(goingLeft);
        }


        CheckIdle();

        CheckJumping();

        jumpAvailable = IsTouchingGround();

        MovePlayer();

        CapVelocity();

        oldXVelocity = rb.velocity.x;
    }

    private void CheckIdle()
    {
        if (rb.velocity.magnitude < 1 && IsTouchingGround())
        {
            playerSprite.gameObject.GetComponent<Animator>().SetBool("idling", true);
        }
        else
        {
            playerSprite.gameObject.GetComponent<Animator>().SetBool("idling", false);
        }
    }

    private void CheckJumping()
    {
        if (!IsTouchingGround())
        {
            playerSprite.gameObject.GetComponent<Animator>().SetBool("falling", true);
        }
        else
        {
            playerSprite.gameObject.GetComponent<Animator>().SetBool("falling", false);
        }
    }

    private void CheckPlayerOrientation(float ori)
    {
        if (ori > 0.05f)
        {
            goingLeft = false;
        }
        if (ori < -0.05f)
        {
            goingLeft = true;
        }
        if (ori < 0.05f && ori > -0.05f)
        {
            
        }
    }
    private void UpdatePlayerOrientation(bool left)
    {
        if (left)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.contacts[0].thisCollider.name == "UpperCollider")
        {
            oldXVelocity = -oldXVelocity / 10;

        }
        if (collision.contacts[0].point.y < transform.position.y)
        {
            if (collision.gameObject.tag == "Floor")
            {
                jumpAvailable = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpAvailable = false;
        }
    }
    private bool IsTouchingWall()
    {
        Vector2 pos = transform.position;
        return Physics.Raycast(new Vector2(pos.x, pos.y), Vector2.left, 0.4f) ||
            Physics.Raycast(new Vector2(pos.x, pos.y), Vector2.right, 0.4f) ||
            Physics.Raycast(new Vector2(pos.x, pos.y + 0.2f), Vector2.left, 0.4f) ||
            Physics.Raycast(new Vector2(pos.x, pos.y + 0.2f), Vector2.right, 0.4f) ||
            Physics.Raycast(new Vector2(pos.x, pos.y - 0.2f), Vector2.left, 0.4f) ||
            Physics.Raycast(new Vector2(pos.x, pos.y - 0.2f), Vector2.right, 0.4f);
    }
    private bool IsTouchingGround()
    {
        Vector2 pos = transform.position;
        return Physics.Raycast(transform.position, Vector2.down, 0.33f) ||
            Physics.Raycast(new Vector2(pos.x + 0.14f, pos.y), Vector2.down, 0.25f) ||
            Physics.Raycast(new Vector2(pos.x - 0.14f, pos.y), Vector2.down, 0.25f);
    }

    private void MovePlayer()
    {
        //if (jumpAvailable && !pVar.isTyping)
        //{
            rb.velocity = new Vector2(rb.velocity.x / 1.5f + Input.GetAxis("Horizontal") * speed / 20, rb.velocity.y);
            if (Input.GetAxis("Jump") == 1 && IsTouchingGround() && !pVar.isTyping)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
                jumpAvailable = false;
            }
    //}
        //else if (!pVar.isTyping)
        //{
           // rb.velocity = new Vector2(rb.velocity.x + Input.GetAxis("Horizontal") * airSpeed / 20, rb.velocity.y);
        //}
    }

    private void CapVelocity()
    {
        if (rb.velocity.x >= cap)
        {
            rb.velocity = new Vector2(cap, rb.velocity.y);
        } else if (rb.velocity.x <= -cap)
        {
            rb.velocity = new Vector2(-cap, rb.velocity.y);
        }
    }
}
