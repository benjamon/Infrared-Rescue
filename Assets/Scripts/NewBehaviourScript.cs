﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.LoadScene("Infraready");
        }
	}
}
