using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class g2_ButtonLogic : MonoBehaviour {

	public List<GameObject> patterns = new List<GameObject>();

	public int WhatButton = 0;
	public GameObject sound;

	public GameObject particleEffect;
	
	private static int i = 0;
	private List<string> currentPattern;

	private bool timerNeg;
	private bool timerPos;

	void Start () {
		setCurrentPattern ();
	}

	void setCurrentPattern(){
		GameObject other = GameObject.FindGameObjectWithTag ("MainCamera");
		g2_GameLogic gamelogic = other.GetComponent<g2_GameLogic> ();
		currentPattern = gamelogic.stringPattern;
	}

	void Update () {
		if (WhatButton == 1) {
			transform.position = new Vector3(-1f, -1f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 2) {
			transform.position = new Vector3(1f, -1f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 3) {
			transform.position = new Vector3 (-1f, -3f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (WhatButton == 4) {
			transform.position = new Vector3 (1f, -3f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void OnTouchDown(Vector2 point){

		if (i > 3) {
			i = 0;
		}

		if (WhatButton == 1) {
			if (currentPattern [i] == "greenPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				i++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				i = 0;
			}
		}

		if (WhatButton == 2) {
			if (currentPattern [i] == "yellowPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				i++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				i = 0;
			}
		}

		if (WhatButton == 3) {
			if (currentPattern [i] == "redPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				i++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				i = 0;
			}
		}

		if (WhatButton == 4) {	
			if (currentPattern [i] == "purplePattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				i++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				i = 0;
			}
		}


		if (i < 4) {

//			Debug.Log ("i is: " + i + " button to be pushed: " + currentPattern [i]);
		} else {

			// Someone just succeeded. We should reward them with a score, 
			g2_Maincode.score+=1;

			// more time 
			GameObject.Find("Timer").GetComponent<g2_Timer>().setPos();

			//and a new pattern.
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<g2_GameLogic>().updatePatterns();
			setCurrentPattern();
		}

	}

}