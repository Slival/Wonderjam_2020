using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("In the door trigger");
        if (other.tag == "Door" && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(other.GetComponent<Door>().sceneIndex);
        }
    }
}
