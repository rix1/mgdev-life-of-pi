using UnityEngine;
using System.Collections;

public class g1_CheckButton : MonoBehaviour {
	
	public int WhatButton = 0;
	public GameObject button;
	public GameObject Particles;
	public bool over = false;
	public static int missed=0;
	private static int mistakes = 0;
	private int winningNumber = 30;
	private int maxMistakes = 1;
	public bool wrongNote = false;

	
	void Update () {
		gameOver ();
		
		if (WhatButton == 1) {
			transform.position = new Vector3(-1.8f, -3.7f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 2) {
			transform.position = new Vector3(0.0f, -3.7f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 3) {
			transform.position = new Vector3 (1.8f, -3.7f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		
		//Based on score, increase light size
	}
	
	void correctTouch(){
		if (wrongNote) {
			mistakes++;
			Debug.Log("Mistakes: " + mistakes);
			wrongNote=false;
		} else {
			GameObject.Instantiate (Particles, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			g1_Maincode.song1score += 10;
			Debug.Log ("Correct: 10");
		}
	}
	
	void wrongTouch(){
		g1_Maincode.song1score -= 2;
		Debug.Log("Wrong: -2");
		Debug.Log("Mistakes: " + mistakes);
	}
	
	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			if(over == true){
				correctTouch();
			}
			if(over == false){
				wrongTouch();
			}
			over = false;
		}
		
		if (WhatButton == 2) {
			if(over == true){
				correctTouch();
			}
			if(over == false){
				wrongTouch();
			}
			over = false;
		}
		
		if (WhatButton == 3) {
			if(over == true){
				correctTouch();
			}
			if(over == false){
				wrongTouch();
			}
			over = false;
		}
	}
	
	void decrementMistakes(){
		//TODO
		//decrease mistakes every second
	}
	
	void gameOver(){
		if (!(GameObject.FindWithTag("MainCamera").GetComponent<AudioSource> ().isPlaying)) {
			g1_Maincode.song1score=0;
			g1_Maincode.song1highscore = g1_Maincode.song1score;
			mistakes = 0;
			Application.LoadLevel("g1_GameOverWon");
		}
		if (mistakes == maxMistakes) {
			g1_Maincode.song1score=0;
			mistakes = 0;
			Application.LoadLevel("g1_GameOver");
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			over = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Note") {
			over = false;
			
			//Register missed notes
			missed++;
			g1_Maincode.song1score-=1;
			Debug.Log("Missed: -1");
		}
		if(other.gameObject.tag == "WrongNote") {
			over = false;
		}
	}
	
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 1) {
					if (over == true) {
						Destroy (other.gameObject);
						if(other.gameObject.tag == "WrongNote"){
							wrongNote = true;
						}
					}
				}
			}
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 2) {
					if (over == true) {
						Destroy (other.gameObject);
						if(other.gameObject.tag == "WrongNote"){
							wrongNote = true;
						}
					}
				}
			}
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 3) {	
					if (over == true) {
						Destroy (other.gameObject);
						if(other.gameObject.tag == "WrongNote"){
							wrongNote = true;
						}
					}
				}	
			}
		}
	}
}
