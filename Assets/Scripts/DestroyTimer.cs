﻿using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{
    public int life;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        life--;
        if (life < 0) { Destroy(gameObject); }
    }
}
