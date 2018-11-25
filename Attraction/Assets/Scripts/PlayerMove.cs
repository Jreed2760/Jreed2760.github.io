using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {


    Rigidbody myBody;
    public float forceAmt;
    public Text Speed;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody>();
        Speed.text = "";

    }
    
    // Update is called once per frame
    void Update () {
    	Speed.text = "" + forceAmt;
        if (Input.GetKey(KeyCode.W))
            myBody.AddForce(Vector3.forward * forceAmt);
        if (Input.GetKey(KeyCode.S))
            myBody.AddForce(Vector3.back * forceAmt);
        if (Input.GetKey(KeyCode.A))
            myBody.AddForce(Vector3.left * forceAmt);
        if (Input.GetKey(KeyCode.D))
            myBody.AddForce(Vector3.right * forceAmt);

    }

private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Teleport"))
        {
            transform.position = new Vector3(0f, 1f, -6f);
            forceAmt = forceAmt - 4;
        }

        if (col.gameObject.CompareTag("Teleport1"))
        {
            transform.position = new Vector3(6f, 38f, 57.5f);
            forceAmt = forceAmt - 4;
        }
	}

	


void OnCollisionEnter(Collision col){ 
		if (col.gameObject.CompareTag("Pos" )){ 			
			
			if (transform.lossyScale.sqrMagnitude > col.transform.lossyScale.sqrMagnitude ){
				forceAmt +=3;
				col.gameObject.SetActive(false);
			} else {
				
				gameObject.SetActive(false);
				//Invoke("reload", 1f);
			}
		}
		if (col.gameObject.CompareTag("Neg")){ 			
			
			if (transform.lossyScale.sqrMagnitude > col.transform.lossyScale.sqrMagnitude ){
				forceAmt -=3;
				col.gameObject.SetActive(false);
			} else {
				
				gameObject.SetActive(false);
				//Invoke("reload", 1f);
			}
	}
	if (col.gameObject.CompareTag("BossSpawn")){ 			
			
			if (transform.lossyScale.sqrMagnitude < col.transform.lossyScale.sqrMagnitude && forceAmt > 20){
				col.gameObject.SetActive(false);
			} else {
				gameObject.SetActive(false);
}
}
}
}