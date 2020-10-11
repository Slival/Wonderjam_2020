using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistonDoor : MonoBehaviour
{
    public pressButton controller1;
    public pressButton controller2;
    public GameObject startPos;
    public GameObject endPos;
    public float speed, returnSpeed;

    private float pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller2 == null)
        {
            if (controller1.pressed && pos < 1)
            {
                pos += 0.001f * speed;
            }
            else if (pos > 0)
            {
                pos -= 0.001f * returnSpeed;
            }
        }
        else
        {
            if ((controller1.pressed || controller2.pressed) && pos < 1)
            {
                pos += 0.001f * speed;
            }
            else if (pos > 0)
            {
                pos -= 0.001f * returnSpeed;
            }
        }

        gameObject.transform.position = new Vector3(Mathf.Lerp(startPos.transform.position.x, endPos.transform.position.x, pos), Mathf.Lerp(startPos.transform.position.y, endPos.transform.position.y, pos), gameObject.transform.position.z);
    }
}
