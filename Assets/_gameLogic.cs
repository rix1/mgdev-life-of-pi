using UnityEngine;
using System.Collections;

public class _gameLogic : MonoBehaviour {
	
	public string nextScene;
	public string thisScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void loadScene(){
		Debug.Log("Button Clicked");
		Application.LoadLevel(nextScene);
	}
}
