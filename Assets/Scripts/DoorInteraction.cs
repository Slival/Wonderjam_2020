using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private string sceneName;
    private bool canEnterDoor;
    public AudioSource aus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canEnterDoor)
        {
            SceneManager.LoadScene(sceneName);
            aus.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            sceneName = other.GetComponent<Door>().sceneName;
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
