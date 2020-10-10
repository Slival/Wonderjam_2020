using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private int index;
    private bool canEnterDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canEnterDoor)
        {
            SceneManager.LoadScene(index);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            index = other.GetComponent<Door>().sceneIndex;
            canEnterDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            canEnterDoor = false;
        }
    }
}
