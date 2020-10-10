using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public GameObject iceWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            GameObject wall = Instantiate(iceWall);
            wall.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
