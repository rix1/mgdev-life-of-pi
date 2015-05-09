using UnityEngine;
using System.Collections;

public class _gameLogic : MonoBehaviour {
	
	public string thisScene;
	private string g1 = "g1_Start";
	private string g2 = "g2_Start";
	private string g3 = "g3_Start";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void loadG1(){
		Application.LoadLevel(g1);
	}
	public void loadG2(){
		Application.LoadLevel(g2);
	}
	public void loadG3(){
		Application.LoadLevel(g3);
	}
}
