using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LerpToStart : MonoBehaviour {
    Vector3 startVec, locScale;
    Text texx;
    Color c;

	// Use this for initialization
	void Start () {
        startVec = transform.localPosition;
        locScale = transform.localScale;
        if (gameObject.GetComponent<Text>() != null) {
            texx = gameObject.GetComponent<Text>();
            c = texx.color;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (texx != null)
        {
            texx.color = Color.Lerp(texx.color, c, .075f);
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, startVec, .15f);
        transform.localScale = Vector3.Lerp(transform.localScale, locScale, .225f);
    }
}
