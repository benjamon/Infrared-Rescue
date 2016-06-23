using UnityEngine;
using System.Collections;

public class DissapearAndDie : MonoBehaviour {
    private Renderer r;
    private Color c;
    private float f = 0;

	// Use this for initialization
	void Start () {
        r = gameObject.GetComponent<Renderer>();
        c = r.material.GetColor("_TintColor");
	}
	
	// Update is called once per frame
	void Update () {
        f += .2f;
        transform.localScale = transform.localScale * .8f;
        r.material.SetColor("_TintColor", Color.Lerp(c, new Color(0, 0, 0, 0), f));
        if (f > 1)
        {
            Destroy(gameObject);
        }
	}
}
