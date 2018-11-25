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
        MyText.text = "";
    }
 
 
    // Update is called once per frame
    void Update () {
     if (score == 7){
        SceneManager.LoadScene (2);
     }
     //if (gameObject.SetActive(false)){
        //SceneManager.LoadScene(2);
     //}
        MyText.text = "Animal Parts: " + score;     	
    }
 
   void OnCollisionEnter(Collision col){ 
		if (col.gameObject.CompareTag("Parts")){ 
            score = score + 1;
        }
			
     
    }
     
}