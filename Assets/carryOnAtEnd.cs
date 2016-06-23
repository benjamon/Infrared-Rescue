using UnityEngine;
using System.Collections;

public class carryOnAtEnd : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (transform.parent == null)
        {
            transform.position += Vector3.forward;
        }
	}
}
