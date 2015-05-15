using UnityEngine;
using System.Collections;

public class g1_CheckButton : MonoBehaviour {
	
	public int WhatButton = 0;
	public GameObject button;
	public GameObject Particles;
	public bool over = false;
	private static int mistakes = 0;
	public bool wrongNote = false;
	

	private GameObject parent; 
	
	void Start(){
		parent = GameObject.Find("Score").gameObject;
		setPos();
	}
	
	//Based on score, increase light size
	void correctTouch(){
		GameObject.Instantiate (Particles, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		updateScore(1);
	}
	
	void wrongTouch(){
		updateScore(-1);
	}
	
	void OnTouchDown(Vector2 point){
	
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
	
	void updateScore(int code){
		parent.GetComponent<g1_Score>().updateScore(code);
	}

	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			over = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Note") {
			updateScore(-1);
		}
		over = false;
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Note" || other.gameObject.tag == "WrongNote") {
			
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				if (over) {
					if(other.gameObject.tag == "WrongNote"){
						updateScore(0);
					}
					Destroy (other.gameObject);
				}
			}
		}
	}
}