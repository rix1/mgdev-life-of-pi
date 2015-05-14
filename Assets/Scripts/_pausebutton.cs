using UnityEngine;
using System.Collections;

public class _pausebutton : MonoBehaviour {
	public string levelName;
	private bool isPaused = false;
	public int WhatButton = 0;
	public Sprite back;

	public GUIStyle customButton;

	
	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			isPaused = !isPaused;
		}
	}

	void Update () {
		if(isPaused)
			Time.timeScale = 0f; 
		else
			Time.timeScale = 1.0f;
	}
		
	void OnGUI (){

		if(isPaused){
			if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40),"Back", customButton)){
				Application.LoadLevel(levelName);
			}
			if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 00, 100, 40),"Continue", customButton)){
				for (int i = 3; i>0; i--){
					GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 00, 100, 40),"Continue", customButton);
				}
				isPaused = !isPaused;

			}
		}
	}
}
	