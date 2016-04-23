using UnityEngine;
using System.Collections;

public class LayerScript : MonoBehaviour {
    public GameObject spawner;
    public string layerTitle;
    public float clusterX, clusterZ, tranSp, poluteChance, cloudChance;

    void Update()
    {
        if (gameObject != null && spawner != null) {
            if (spawner.transform.position.z > transform.position.z)
            {
            spawner.GetComponent<CloudGenerator>().newLayer(layerTitle, clusterX, clusterZ, tranSp, poluteChance, cloudChance);
            Destroy(gameObject);
            }
        }
    }
}
