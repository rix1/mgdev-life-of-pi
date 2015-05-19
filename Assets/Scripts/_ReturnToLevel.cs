using UnityEngine;
using System.Collections;

public class _ReturnToLevel : MonoBehaviour {
	void Start(){
	}

	void OnTouchDown(Vector2 point){
		Application.LoadLevel (_gameState.getCurrentLevelString());
	}
}
