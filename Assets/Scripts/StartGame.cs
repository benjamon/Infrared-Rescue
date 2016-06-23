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
        GameControl g = GameObject.Find("Controlla").GetComponent<GameControl>();
        if (g == null) Debug.Log("didn't find g");
        g.oddsAg = oddsAgainst;
        SceneManager.LoadSceneAsync("Infraready");
    }
}
