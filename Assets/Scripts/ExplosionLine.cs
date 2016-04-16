using UnityEngine;
using System.Collections;

public class ExplosionLine : MonoBehaviour {
    public LineRenderer lr;
    public float lineLife, lineMag;
    float lineTime = 0f;
    Vector3 evec;

	// Use this for initialization
	void Start () {
        evec = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(0f, 1f)).normalized * lineMag;
    }

    // Update is called once per frame
    void Update() {
        lineTime++;
        if (lineTime > lineLife) { Destroy(gameObject); }
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, evec);
        lr.SetWidth(Mathf.Lerp(.7f, 0, lineTime / lineLife) / 3, .05f);
	}
}
