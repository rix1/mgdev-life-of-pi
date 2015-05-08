using UnityEngine;
using System.Collections;

public class g3_CheckButton : MonoBehaviour {

	public int WhatButton = 0;
	public GameObject button;
	public GameObject Particles;
	public bool over = false;
	public static int missed=0;
	private static int mistakes = 0;
	private int winningNumber = -6;
	private int maxMistakes = 10;


	void Update () {
		gameOver ();
		if (WhatButton == 1) {
			transform.position = new Vector3(-1.8f, -3.28f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		if (WhatButton == 2) {
			transform.position = new Vector3(0.0f, -3.28f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		if (WhatButton == 3) {
			transform.position = new Vector3 (1.8f, -3.28f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void correctTouch(){
		GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
		g3_Maincode.song1score += 2;
	}

	void wrongTouch(){
		if (g3_Maincode.song1score > 0) {
			g3_Maincode.song1score -= 1;
		}
		mistakes++;
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
		if (mistakes > 0) {
			mistakes--;
			Debug.Log("DECREMENTED MISTAKES" + mistakes);
		}
	}

	void gameOver(){
		if (!(GameObject.FindWithTag("MainCamera").GetComponent<AudioSource> ().isPlaying) && g3_Score.currentPos.z > winningNumber) {
			g3_Maincode.song1score=0;
			g3_Maincode.song1highscore = g3_Maincode.song1score;
			mistakes = 0;
			Application.LoadLevel("g3_GameOverWon");
		}
		if (mistakes == maxMistakes) {
			g3_Maincode.song1score=0;
			mistakes = 0;
			Application.LoadLevel("g3_GameOver");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Note") {
			over = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Note") {
			over = false;

			//Register missed notes
			missed++;
			if(g3_Maincode.song1score>0){
				g3_Maincode.song1score-=1;		
			}

			mistakes++;
			Debug.Log("Mistakes: " + mistakes);
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Note") {

			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 1) {
					if (over == true) {
						Destroy (other.gameObject);
					}
				}
			}
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 2) {
					if (over == true) {
						Destroy (other.gameObject);
					}
				}
			}
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (WhatButton == 3) {	
					if (over == true) {
						Destroy (other.gameObject);
					}
				}	
			}
		}
	}
}
