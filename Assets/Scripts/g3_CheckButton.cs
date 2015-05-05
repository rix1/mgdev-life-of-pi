using UnityEngine;
using System.Collections;

public class g3_CheckButton : MonoBehaviour {

	public int WhatButton = 0;
	public GameObject Particles;
	public bool over = false;

	private int numberCorrect = 0;

	void Update () {
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
	}

	//TODO 
	//Register notes that has not been touched

	//TODO
	//Penalize when touching wrong button and ignoring notes
	//number of wrong touches and ignored notes saved in a variable, decreases over time. 
	//if touches too many wrong notes or ignoring too many notes (wrongNotes = X) before song is finished, game over
	//set score to 0
	//Load game over scene

	//TODO
	//increase points when pressing correct buttons
	//multipliers when touched x number of correct button i a row
	//when song is finished and have more than X points, winning
	//save points in highscore, set score to 0
	//Load game over scene

	//TODO
	//Based on score, increase light size

	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			if(over == true){
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				g3_Maincode.song1score += 1;
				numberCorrect++;
				Debug.Log("number of correct notes in a row: " + numberCorrect);
				
			}
			if(over == false){
				g3_Maincode.song1score -= 0;
				numberCorrect=0;
			}
			over = false;
		}

		if (WhatButton == 2) {
			if(over == true){
				g3_Maincode.song1score += 1;
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				numberCorrect++;
				Debug.Log("number of correct notes in a row: " + numberCorrect);
				
			}
			if(over == false){
				g3_Maincode.song1score -= 0;
				numberCorrect=0;
				
			}
			over = false;
		}

		if (WhatButton == 3) {
			if(over == true){
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				g3_Maincode.song1score += 1;
				numberCorrect++;
				Debug.Log("number of correct notes in a row: " + numberCorrect);
				
			}
			if(over == false){
				g3_Maincode.song1score -= 0;
				numberCorrect=0;
				
			}
			over = false;
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
