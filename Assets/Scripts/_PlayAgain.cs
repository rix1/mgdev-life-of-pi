﻿using UnityEngine;
using System.Collections;

public class _PlayAgain : MonoBehaviour {
	public string sceneName;
	void Start(){
	}

	void OnTouchDown(Vector2 point){
		Debug.Log ("touched");
		Application.LoadLevel (sceneName);
	}
}
