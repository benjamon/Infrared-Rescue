using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public KeyCode left, right;
    public float speed, lerpDist, lerpStart, lerpSpeed, wiggleActual = 1f, screenReaction, rotateAmount;
    public Transform finishLine, cFall, textL, textR, myInfra, cFollow, myInfraModel;
    public Text txtLL, txtR, textRes, textResult;

    private Vector3 startEuler, endPosition;
    private AudioSource audS, dingS;
    private float leftFloat = 0f, startPos = 0f;

    void Start () {
        startPos = transform.position.z;
        startEuler = myInfraModel.eulerAngles;
        audS = gameObject.GetComponents<AudioSource>()[0];
        dingS = gameObject.GetComponents<AudioSource>()[1];
    }
    
	void Update () {
	    if (Input.GetKeyDown(left))
        {
            leftFloat = lerpStart;
            endPosition = transform.position + transform.right * -lerpDist;
            audS.Play();
            rotateAmount = -40;
        }
        if (Input.GetKeyDown(right))
        {
            leftFloat = lerpStart;
            endPosition = transform.position + transform.right * lerpDist;
            audS.Play();
            rotateAmount = 40;
        }

        //Apply movement Lerp
        if (leftFloat > 0)
        {
            transform.position = Vector3.Lerp(new Vector3(endPosition.x, endPosition.y, transform.position.z), transform.position, leftFloat);
            myInfraModel.rotation = Quaternion.LookRotation(transform.up);
            myInfraModel.Rotate(Vector3.forward, Mathf.Lerp(180, 180 + rotateAmount, leftFloat));
            myInfraModel.localPosition = (Vector3.right - Vector3.forward * .1f) * rotateAmount * leftFloat / 40 + Vector3.forward * .35f * (1 - leftFloat);
            leftFloat -= lerpSpeed;
        }
        else {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            myInfraModel.rotation = Quaternion.LookRotation(transform.up);
            myInfraModel.Rotate(Vector3.forward, 180);
            myInfraModel.localPosition = Vector3.forward * .25f;
        }
        
        transform.position += Vector3.forward * speed;

        //Calculate KM and THz
        float ef = Mathf.Lerp(-.3954f, 1f, wiggleActual);
        ef = Mathf.Lerp(0, 13700000, Mathf.Sin(ef * Mathf.PI * 0.01f));
        txtR.text = ((int)(((transform.position.z - startPos) / (finishLine.position.z - startPos)) * 85f)) + "km";
        if (ef < 1000)
        {
            txtLL.text = (int)ef + "GHz";
        } else
        {
            txtLL.text = (int)(ef / 1000) + "THz";
        }

        //Game End Script
        if (transform.position.z > finishLine.position.z)
        {
            textRes.text = "R TO RESTART\n\nM FOR MENU";
            textResult.text = "YOU ESCAPED THE ATMOSPHERE WITH <color=#ff0000ff>" + ((int)(((ef / 1000) / 430) * 100)) + "%</color> OF YOUR ENERGY!";
            //myInfra.gameObject.GetComponent<InfraRayController>().lastX = transform.position.x;
            cFollow.parent = myInfraModel;
            //myInfra.parent = myInfraModel;
            myInfraModel.rotation = Quaternion.LookRotation(transform.up);
            myInfraModel.parent = null;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Take Damage
        if (col.gameObject.name.Contains("seeoh"))
        {
            Destroy(col.gameObject);
            int reps = Random.Range(3, 6);
            for (int i = 0; i < reps; i++)
            {
                GameObject bline = (GameObject)Instantiate(Resources.Load("LineExplosion")); ;
                bline.transform.position = transform.position;
            }
            wiggleActual -= .06f;
            if (wiggleActual < .3f)
            {
                textRes.text = "R TO RESTART\n\nM FOR MENU";
                textResult.text = "YOU WERE <color=#ff0000ff>" + ((int)(85 - ((transform.position.z - startPos) / (finishLine.position.z - startPos)) * 85f)) + "km</color> AWAY FROM ESCAPING THE ATMOSPHERE";
                Destroy(gameObject);
            } else
            {
                cFall.position += Vector3.back * screenReaction;
                textL.position += Vector3.left * screenReaction;
                textL.localScale = textL.localScale * 2f;
                txtLL.color = Color.red;
                textR.position += Vector3.right * screenReaction;
            }
        }

        //Get Speed
        if (col.gameObject.name.Contains("speed"))
        {
            textL.position += Vector3.right * screenReaction * 2;
            textR.position += Vector3.left * screenReaction * 2;
            dingS.Play();
            Destroy(col.gameObject);
            wiggleActual = Mathf.Min(wiggleActual + .1f, 1f);
            GameObject go = Instantiate(Resources.Load("winstance") as GameObject); ;
            go.transform.position = transform.position + Vector3.forward * 2.5f;
        }
    }
}
