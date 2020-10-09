using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;
    private bool jumpAvailable = true;
    private float oldXVelocity = 0;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if  (Physics.Raycast(transform.position, Vector2.down,0.33f))
        {
            jumpAvailable = true;
        }

        if (jumpAvailable)
        {
            if (Input.GetAxis("Jump") == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
            }
        } else {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
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


}
