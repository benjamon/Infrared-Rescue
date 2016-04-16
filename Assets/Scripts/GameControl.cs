using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControl : MonoBehaviour {
    public int hasPlayed;
    public float oddsAg;
    
    // Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Start Screen");
            hasPlayed = 0;
        }
	}
}
