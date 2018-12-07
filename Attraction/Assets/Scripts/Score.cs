using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Score : MonoBehaviour {
 
 
 
    public Text MyText;
    private int speedNum;
    private int score;
    public bool Active;
     
    // Use this for initialization
    void Start () {
        Active = true;
        MyText.text = "";
    }
 
 
    // Update is called once per frame
    void Update () {
     if (score == 5){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
     }
     //if (gameObject.SetActive(false)){
        //SceneManager.LoadScene(2);
     //}
        MyText.text = "Charge: " + score;     	
    }
 
   void OnCollisionEnter(Collision col){ 
		if (col.gameObject.CompareTag("BossSpawn" )){ 
            score = score + 1;
        }
			
     
    }
     
}