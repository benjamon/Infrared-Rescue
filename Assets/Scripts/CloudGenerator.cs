using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudGenerator: MonoBehaviour {
    public float oddsAgainst, avgCluster, clusterDev, avgSize, standardDev, xSpread, zSpread, bigXSpread, speedOddsAgainst;
    public AudioSource ass, musik;
    public Text layerText, layerFactText;
    private float layerIt = 0, tranSpeed = -.175f, chanceMult = 1.65f, clChanceMult = 2f;
    private bool gcExists, gcHasPlayed;
    GameControl gc;

    // Use this for initialization
    void Start () {
        try
        {
            gc = GameObject.Find("Controlla").GetComponent<GameControl>();
            layerFactText.text = gc.factsOfFun.GetRange((int)Mathf.Floor(Random.Range(0, gc.factsOfFun.Count)), 1)[0];
        }
        catch
        {
            Debug.Log("Didn't Find");
        }
        GameObject[] layers = GameObject.FindGameObjectsWithTag("atmosphere");
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].GetComponent<LayerScript>().spawner = gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Handle game controller not existing for debug purposes
        gcExists = (gc != null);
        if (gcExists)
        {
            gcHasPlayed = (gc.hasPlayed == 1);
            oddsAgainst = gc.oddsAg;
        }
        else {
            gcHasPlayed = true;
            oddsAgainst = 5;
        }

        //main cloud generation / spawn loop
        if (!ass.isPlaying || gcHasPlayed || !gcExists)
        {
            if (ass.isPlaying) ass.Stop();

            if (!musik.isPlaying || gcHasPlayed || !gcExists)
            {
                if (!musik.isPlaying)
                {
                    musik.Play();
                }
                if (gcExists) gc.hasPlayed = 1;
            }
            
            //C02 Generation
            if (Random.Range(0, oddsAgainst * chanceMult) < 1 && layerIt <= 0)
            {
                layerFactText.text = "";
                layerText.text = "";
                int ClusterSize = (int)Mathf.Floor(avgCluster + Random.Range(-clusterDev / 2f, clusterDev / 2f));
                float clustX = Random.Range(-bigXSpread / 2f, bigXSpread / 2);
                for (int i = 0; i < ClusterSize; i++)
                {
                    GameObject go = Instantiate(Resources.Load("seeohtwo") as GameObject); ;
                    go.transform.position = transform.position + new Vector3(Random.Range(-xSpread / 2f, xSpread / 2f) + clustX, 0f, 55f + Random.Range(-zSpread / 2f, zSpread / 2f));
                    go.transform.localScale = Random.Range(1 - standardDev, 1 + standardDev) * avgSize * go.transform.localScale;
                    go.GetComponent<TranslateByAmount>().translation = new Vector3(0,0,tranSpeed);
                }
            }

            //Cloud Generation
            if (clChanceMult != -1)
            {
                if (Random.Range(0, 8 * clChanceMult) < 1 && layerIt <= 0)
                {
                    layerFactText.text = "";
                    layerText.text = "";
                    int ClusterSize = (int)Mathf.Floor(avgCluster / 2+ Random.Range(-clusterDev / 2f, clusterDev / 2f));
                    float clustX = Random.Range(-bigXSpread / 2f, bigXSpread / 2);
                    for (int i = 0; i < ClusterSize; i++)
                    {
                        GameObject go = Instantiate(Resources.Load("cloud") as GameObject); ;
                        go.transform.position = transform.position + new Vector3(Random.Range(-xSpread, xSpread) + clustX, 0f, 55f + Random.Range(-zSpread, zSpread));
                        go.transform.localScale = Random.Range(1.1f - standardDev * 2, 1.1f + standardDev) * avgSize * go.transform.localScale;
                        go.GetComponent<TranslateByAmount>().translation = new Vector3(0, 0, tranSpeed);
                    }
                }
            }

            //Speed Generation
            if (Random.Range(0, oddsAgainst * speedOddsAgainst) < 1 && layerIt <= 0)
            {
                GameObject go = Instantiate(Resources.Load("speedboost") as GameObject); ;
                go.transform.position = transform.position + new Vector3(Random.Range(-xSpread / 2f, xSpread / 2f), 0f, 55f + Random.Range(-zSpread / 2f, zSpread / 2f));
                go.GetComponent<TranslateByAmount>().translation = new Vector3(0, 0, tranSpeed);
            }
            layerIt--;
        }

    }

    public void newLayer (string name, float clusterX, float clusterZ, float tranSp, float polluteChance, float cloudChance)
    {
        layerIt = 210;
        xSpread = clusterX;
        zSpread = clusterZ;
        layerText.text = name;
        if (gcExists)
            layerFactText.text = gc.factsOfFun.GetRange((int)Mathf.Floor(Random.Range(0, gc.factsOfFun.Count)), 1)[0];
        tranSpeed = tranSp;
        chanceMult = polluteChance;
        clChanceMult = cloudChance;
    }
}
