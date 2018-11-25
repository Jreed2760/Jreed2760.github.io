using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow2 : MonoBehaviour {

	Rigidbody myBody;
	public Transform target;
	public float forceAmt;

	void Start () {
		myBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 direction;

		if (transform.lossyScale.sqrMagnitude > target.lossyScale.sqrMagnitude ){
			direction = Vector3.Normalize(target.position - transform.position);
		} else {
			direction = Vector3.Normalize(transform.position - target.position);
			
		}
		
		myBody.AddForce(direction * forceAmt);
		
	}
}
