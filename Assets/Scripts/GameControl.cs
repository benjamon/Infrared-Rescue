using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public int hasPlayed;
    public float oddsAg;
    public TextAsset textFile;
    public List<string> factsOfFun;
    private bool triggered = false;
    
    // Use this for initialization
	void Start () {
        string fileToString = textFile.text;
        DontDestroyOnLoad(gameObject);

        factsOfFun = new List<string>();
        factsOfFun.AddRange(fileToString.Split("\n"[0]));
    }
	
	// Update is called once per frame
	void Update () {
        //Initial Click Through Script
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!triggered)
            {
                SceneManager.LoadScene("Start Screen");
                triggered = true;
            }
        }

        //Get to main menu from anywhere script
	    if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Start Screen");
            hasPlayed = 0;
        }
	}
}
