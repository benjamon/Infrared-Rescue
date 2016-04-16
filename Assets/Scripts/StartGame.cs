using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour {
    public float oddsAgainst;
    public GameObject go;

	// Use this for initialization
	void Start ()
    {
        go.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void whenHasClicked()
    {
        go.SetActive(true);
        GameObject.Find("Controlla").GetComponent<GameControl>().oddsAg = oddsAgainst;
        SceneManager.LoadSceneAsync("Infraready");
    }
}
