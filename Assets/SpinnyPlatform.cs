using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyPlatform : MonoBehaviour
{
    public Material lockMaterial;
    public int lockAngle = 0;
    public float lockTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HingeJoint>())
        {
            // 175 <= 180 - 5f
            //spin 180 - 175
            if (GetComponent<HingeJoint>().angle >= lockAngle - 2f && GetComponent<HingeJoint>().angle <= lockAngle + 2f)
            {
                GetComponent<HingeJoint>().transform.Rotate(lockAngle - GetComponent<HingeJoint>().angle, 0 , 0);
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = lockMaterial;
                gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = lockMaterial;
                Destroy(GetComponent<HingeJoint>());
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }
}
