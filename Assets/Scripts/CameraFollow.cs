using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform t;
    Vector3 trynabe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (t != null)
        {
            trynabe = t.position;
            transform.position = Vector3.Lerp(transform.position, t.position, .16f);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, trynabe, .16f);
        }
	}
}
