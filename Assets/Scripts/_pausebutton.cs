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
			
			if(GameObject.Find("Music") != null && isPaused){
				GameObject.Find("Music").GetComponent<AudioSource>().Play();
			}
			
			isPaused = !isPaused;
			
		}
	}

	void Update () {

		disableGameButtons();
		
		if(isPaused)
			Time.timeScale = 0f; 
		else
			Time.timeScale = 1.0f;
	}
	
	void disableGameButtons(){
		GameObject.Find("buttons").gameObject.GetComponent<_buttonController>().activateButtons(!isPaused);
		
		if(GameObject.Find("Music") != null){
			//only checking g3_score
			GameObject.Find("Score").GetComponent<g3_Score>().playing = !isPaused;
			if(isPaused){
				GameObject.Find("Music").GetComponent<AudioSource>().Pause();
			}
		}
	}
		
	void OnGUI (){

		if(isPaused){			
			if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 40),"Back", customButton)){
				Application.LoadLevel(levelName);
			}
			if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 00, 100, 40),"Continue", customButton)){
				isPaused = !isPaused;
				GameObject.Find("Music").GetComponent<AudioSource>().Play();
			}
		}
	}
}
	