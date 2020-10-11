using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressButton : MonoBehaviour
{
    public int pressing;
    public bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing > 0)
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boulder" || other.tag == "Player" || other.tag == "Spin")
        {
            pressing++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boulder" || other.tag == "Player" || other.tag == "Spin")
        {
            pressing--;
        }
    }
}
