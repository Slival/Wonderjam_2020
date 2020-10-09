using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;
    private bool jumpAvailable = false;


    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        if (Input.GetAxis("Jump") == 1 && jumpAvailable)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 500));
            jumpAvailable = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpAvailable = true;
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
