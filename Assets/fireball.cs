﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    float createTime;
    // Start is called before the first frame update
    void Start()
    {
        createTime = Time.fixedUnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (createTime + 5 <= Time.fixedUnscaledTime)
        {
            Destroy(this.gameObject);
        }
    }
}
