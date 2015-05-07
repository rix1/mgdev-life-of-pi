using UnityEngine;
using System.Collections;

public class g2_GameLogic : MonoBehaviour {

	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;


	private Vector3 spawnLoc1 = new Vector3(-1.5f , 2.5f,0f); 
	private Vector3 spawnLoc2 = new Vector3(-0.5f ,2.5f,0f); 
	private Vector3 spawnLoc3 = new Vector3(0.5f ,2.5f,0f); 
	private Vector3 spawnLoc4 = new Vector3(1.5f ,2.5f,0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start () {
		pattern2 ();
	}


	void pattern1(){
		GameObject.Instantiate(red, spawnLoc1, rotation);
		GameObject.Instantiate(green, spawnLoc2, rotation);
		GameObject.Instantiate(yellow, spawnLoc3, rotation);
		GameObject.Instantiate(purple, spawnLoc4, rotation);
	}

	void pattern2(){
		GameObject.Instantiate(purple, spawnLoc1, rotation);
		GameObject.Instantiate(green, spawnLoc2, rotation);
		GameObject.Instantiate(red, spawnLoc3, rotation);
		GameObject.Instantiate(yellow, spawnLoc4, rotation);
	}

	void pattern3(){
		GameObject.Instantiate(green, spawnLoc1, rotation);
		GameObject.Instantiate(red, spawnLoc2, rotation);
		GameObject.Instantiate(purple, spawnLoc3, rotation);
		GameObject.Instantiate(purple, spawnLoc4, rotation);
	}

	void pattern4(){
		GameObject.Instantiate(yellow, spawnLoc1, rotation);
		GameObject.Instantiate(red, spawnLoc2, rotation);
		GameObject.Instantiate(yellow, spawnLoc3, rotation);
		GameObject.Instantiate(purple, spawnLoc4, rotation);
	}



	void Update () {
	
	}
}
