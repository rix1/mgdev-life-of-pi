using UnityEngine;
using System.Collections;

public class g1_CheckButton : MonoBehaviour {
	
	public int WhatButton = 0;
	public GameObject button;
	public GameObject Particles;
	public bool over = false;
	public static int missed=0;
	private static int mistakes = 0;
	public bool wrongNote = false;
	

	private GameObject parent; 
	
	void Start(){
		parent = transform.parent.gameObject;
		setPos();
	}
	
	//Based on score, increase light size
	void correctTouch(){
		if (wrongNote) {
			mistakes++;
			wrongNote=false;
		} else {
			GameObject.Instantiate (Particles, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			updateScore(true);
		}
	}
	
	void wrongTouch(){
		updateScore(false);
// 		mistakes++;
	}
	
	void OnTouchDown(Vector2 point){
// 		if (WhatButton == 1) {
// 			if(over == true){
// 				correctTouch();
// 			}
// 			if(over == false){
// 				wrongTouch();
// 			}
// 			over = false;
// 		}
// 		
// 		if (WhatButton == 2) {
// 			if(over == true){
// 				correctTouch();
// 			}
// 			if(over == false){
// 				wrongTouch();
// 			}
// 			over = false;
// 		}
		
		if(over){
			correctTouch();
		}
		if(!over){
			wrongTouch();
		}
		over = false;
	}
	
	void decrementMistakes(){
		//TODO
		//decrease mistakes every second
	}
	
	
	void setPos(){
		switch (WhatButton)
		{
			case 1:
				transform.position = new Vector3(-1.8f, -3.7f, 0);
			break;
			case 2:
				transform.position = new Vector3(0.0f, -3.7f, 0);
			break;
			case 3:
				transform.position = new Vector3 (1.8f, -3.7f, 0);
			break;
			default:
			break;
		}
		transform.rotation = Quaternion.Euler(0,0,0);
	}
	
	void updateScore(bool pos){
		parent.GetComponent<g1_Score>().updateScore(pos);
	}

	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			over = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Note") {
			//Register missed notes
			missed++;
// 			g1_Maincode.song1score-=1;
			updateScore(false);
			Debug.Log("Missed: -1");
		}
		if(other.gameObject.tag == "WrongNote") {
		}
		over = false;
	}
	
	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
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
