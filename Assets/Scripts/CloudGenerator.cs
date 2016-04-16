using UnityEngine;
using System.Collections;

public class CloudGenerator: MonoBehaviour {
    public float oddsAgainst, avgCluster, clusterDev, avgSize, standardDev, xSpread, zSpread, bigXSpread, speedOddsAgainst;
    public AudioSource ass, musik;
    GameControl gc;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("Controlla").GetComponent<GameControl>();
	}
	
	// Update is called once per frame
	void Update () {
        oddsAgainst = gc.oddsAg;
        if (!ass.isPlaying || gc.hasPlayed == 1)
        {
            if (ass.isPlaying) ass.Stop();
            if (!musik.isPlaying || gc.hasPlayed == 1)
            {
                if (!musik.isPlaying)
                {
                    musik.Play();
                }
                gc.hasPlayed = 1;
            }
            if (Random.Range(0, oddsAgainst) < 1)
            {
                int ClusterSize = (int)Mathf.Floor(avgCluster + Random.Range(-clusterDev / 2f, clusterDev / 2f));
                float clustX = Random.Range(-bigXSpread / 2f, bigXSpread / 2);
                for (int i = 0; i < ClusterSize; i++)
                {
                    GameObject go = Instantiate(Resources.Load("seeohtwo") as GameObject); ;
                    go.transform.position = transform.position + new Vector3(Random.Range(-xSpread / 2f, xSpread / 2f) + clustX, 0f, 55f + Random.Range(-zSpread / 2f, zSpread / 2f));
                    go.transform.localScale = Random.Range(1 - standardDev, 1 + standardDev) * avgSize * go.transform.localScale;
                }
            }
            if (Random.Range(0, oddsAgainst * speedOddsAgainst) < 1)
            {
                GameObject go = Instantiate(Resources.Load("speedboost") as GameObject); ;
                go.transform.position = transform.position + new Vector3(Random.Range(-xSpread / 2f, xSpread / 2f), 0f, 55f + Random.Range(-zSpread / 2f, zSpread / 2f));
            }
        }

    }
}
