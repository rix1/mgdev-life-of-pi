using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class g2_ButtonLogic : MonoBehaviour {

	//private List<GameObject> patterns = new List<GameObject>();
	public int WhatButton = 0;
	public GameObject sound;

<<<<<<< HEAD
	void Start () {
	}
	
=======
	public GameObject particleEffect;
	
	private static int streakCounter = 0;
	private List<string> currentPattern;

	private bool timerNeg;
	private bool timerPos;

	void Start () {
		setCurrentPattern();
	}

	void setCurrentPattern(){
		GameObject other = GameObject.FindGameObjectWithTag ("MainCamera");
		g2_GameLogic gamelogic = other.GetComponent<g2_GameLogic> ();
		currentPattern = gamelogic.getCurrentPattern();
	}

>>>>>>> siri_gm3
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
<<<<<<< HEAD
		//for (int i = 0; i < 4; i++) {
			if (WhatButton == 1) {
				Debug.Log ("GREEN BUTTON");
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			}
			if (WhatButton == 2) {
				Debug.Log ("YELLOW BUTTON");
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));

			}
			if (WhatButton == 3) {
				Debug.Log ("RED BUTTON");
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			}
			if (WhatButton == 4) {
				Debug.Log ("PURPLE BUTTON");
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			}
=======
		
		if (streakCounter > 3) {
			streakCounter = 0;
		}
		

		if (WhatButton == 1) {
			if (currentPattern [streakCounter] == "greenPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				streakCounter++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				streakCounter = 0;
			}
		}

		if (WhatButton == 2) {
			if (currentPattern [streakCounter] == "yellowPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				streakCounter++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				streakCounter = 0;
			}
		}

		if (WhatButton == 3) {
			if (currentPattern [streakCounter] == "redPattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				streakCounter++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				streakCounter = 0;
			}
		}

		if (WhatButton == 4) {	
			if (currentPattern [streakCounter] == "purplePattern") {
				GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				streakCounter++;
			} else {
				GameObject.Instantiate (particleEffect, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Timer").GetComponent<g2_Timer>().setNeg();
				streakCounter = 0;
			}
		}
		
		if(streakCounter < 4){
			
		}else{
			
			// Someone just succeeded. We should reward them with a score, 
			g2_Maincode.score+=1;

			// more time 
			GameObject.Find("Timer").GetComponent<g2_Timer>().setPos();

			//and a new pattern.
			Camera.main.GetComponent<g2_GameLogic>().advance();
			currentPattern = Camera.main.GetComponent<g2_GameLogic>().getCurrentPattern();
		}
>>>>>>> siri_gm3
	}
}