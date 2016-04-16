using UnityEngine;
using System.Collections;

public class TranslateByAmount : MonoBehaviour {
    public Vector3 translation;

	// Use this for initialization
	void Start () {
        //transform.eulerAngles = new Vector3(Random.Range(-90f, 90f), Random.Range(-90f, 90f));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += translation + new Vector3 (Random.Range(-.1f, .1f), 0f, Random.Range(-.1f, .1f));
	}
}
