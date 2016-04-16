using UnityEngine;
using System.Collections;

public class InfraRayController : MonoBehaviour {
    public float currentWiggle;
    public float wiggleSpeed, wiggleAmp, speedAmp;
    public PlayerController p;
    public float lastX;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {
        currentWiggle += ((wiggleSpeed * wiggleSpeed) + wiggleSpeed) / 2;
        if (transform.parent != null)
        {
            wiggleSpeed = Mathf.Lerp(wiggleSpeed, p.wiggleActual, .05f);
            transform.localPosition = new Vector3(Mathf.Sin(currentWiggle) * wiggleAmp, 0);
            lastX = transform.position.x;
        } else
        {
            transform.position = new Vector3(Mathf.Sin(currentWiggle) * wiggleAmp + lastX, 0, transform.position.z + .5f);
        }
    }
}
