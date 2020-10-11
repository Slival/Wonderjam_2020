using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro2 : MonoBehaviour
{
    public GameObject player;
    public GameObject desiredpos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(walkiesright());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator walkiesright()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        while (player.transform.position.x < desiredpos.transform.position.x)
        {
            player.transform.position += new Vector3(0.01f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            yield return null;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        yield return null;
    }
}
