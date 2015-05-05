using UnityEngine;
using System.Collections;

public class g3_CheckButton : MonoBehaviour {

	public int WhatButton = 0;
	public GameObject Particles;
	public bool over = false;


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

	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			Debug.Log("GREEN BUTTON");
			if(over == true){
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				g3_Maincode.song1score += 1;
			}
			if(over == false){
				g3_Maincode.song1score -= 0;
			}
			over = false;

		}
		if (WhatButton == 2) {
			Debug.Log("YELLOW BUTTON");
			if(over == true){
				g3_Maincode.song1score += 1;
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );

			}
			if(over == false){
				g3_Maincode.song1score -= 0;
			}
			over = false;

		}
		if (WhatButton == 3) {
			Debug.Log("RED BUTTON");
			if(over == true){
				GameObject.Instantiate(Particles, transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0,0,0) );
				g3_Maincode.song1score += 1;
			}
			if(over == false){
				g3_Maincode.song1score -= 0;

			}
			over = false;

		}
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("enter");
		if (other.gameObject.tag == "Note") {
			over = true;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		Debug.Log ("exit");
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
