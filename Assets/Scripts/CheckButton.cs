using UnityEngine;
using System.Collections;

public class CheckButton : MonoBehaviour {

	public int WhatButton = 0;
	public GameObject ErrorSound;
	public GameObject RightSound;
	public bool over = false;

	void Update () {
		if (WhatButton == 1) {
			transform.position = new Vector3(-1.38f, -4f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}

		if (WhatButton == 2) {
			transform.position = new Vector3(0.12f, -4f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}

		if (WhatButton == 3) {
			transform.position = new Vector3 (1.51f, -4f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			Debug.Log("GREEN BUTTON");
			if(over == true){
				GameObject.Instantiate(RightSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score += 1;
				over = false;
			}
			if(over == false){
				GameObject.Instantiate(ErrorSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score -= 0;
			}
		}
		if (WhatButton == 2) {
			Debug.Log("RED BUTTON");
			if(over == true){
				GameObject.Instantiate(RightSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score += 1;
				over = false;
			}
			if(over == false){
				GameObject.Instantiate(ErrorSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score -= 0;
			}
		}
		if (WhatButton == 3) {
			Debug.Log("YELLOW BUTTON");
			if(over == true){
				GameObject.Instantiate(RightSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score += 1;
				over = false;
			}
			if(over == false){
				GameObject.Instantiate(ErrorSound, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				Maincode.song1score -= 0;
			}
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
			
			if (Input.GetButtonDown ("1")) {
				if (WhatButton == 1) {
					if (over == true) {
						Destroy (other.gameObject);
					}
				}
			}
			
			if (Input.GetButtonDown ("2")) {
				if (WhatButton == 2) {
					if (over == true) {
						Destroy (other.gameObject);
					}
				}
			}
			
			if (Input.GetButtonDown ("3")) {	
				if (WhatButton == 3) {	
					if (over == true) {
						Destroy (other.gameObject);
					}
				}	
			}
		}
	}
}
