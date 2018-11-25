using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	
	void update(){
	if (transform.position.y < -55f);			
			SceneManager.LoadScene(2);
}
}