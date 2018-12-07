using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour {


    Rigidbody myBody;
    public float forceAmt;
    public Text Speed;
	AudioSource correctAudio;
 	AudioSource errorAudio;
 
    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody>();
        Speed.text = "";
     AudioSource[] audios = GetComponents<AudioSource>();
     correctAudio = audios[0];
     errorAudio = audios[1];
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
        if (Input.GetKey(KeyCode.Space))
            myBody.AddForce(Vector3.down * forceAmt);

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
            transform.position = new Vector3(0f, 2.1f, -6.03f);
            forceAmt = forceAmt - 4;
        }
         if (col.gameObject.CompareTag("End"))
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads current scene

        }
	}

	


void OnCollisionEnter(Collision col){ 
		if (col.gameObject.CompareTag("Pos" )){ 			
			
			if (transform.lossyScale.sqrMagnitude > col.transform.lossyScale.sqrMagnitude ){
				forceAmt +=3;
				correctAudio.Play();
				col.gameObject.SetActive(false);
			} else {
				
				gameObject.SetActive(false);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
				//Invoke("reload", 1f);
			}
		}
		if (col.gameObject.CompareTag("Neg")){ 			
			
			if (transform.lossyScale.sqrMagnitude > col.transform.lossyScale.sqrMagnitude ){
				forceAmt -=3;
				errorAudio.Play();
				col.gameObject.SetActive(false);
			} else {
				
				gameObject.SetActive(false);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
				//Invoke("reload", 1f);
			}
	}
	if (col.gameObject.CompareTag("BossSpawn")){ 			
			
			if (transform.lossyScale.sqrMagnitude < col.transform.lossyScale.sqrMagnitude && forceAmt > 20){
				col.gameObject.SetActive(false);
			} else {
				gameObject.SetActive(false);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
			}
		}


}
}
