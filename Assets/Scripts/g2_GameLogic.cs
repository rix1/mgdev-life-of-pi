using UnityEngine;
using System.Collections;

public class g2_GameLogic : MonoBehaviour {
<<<<<<< HEAD
=======
	
	private List<GameObject> pattern = new List<GameObject>();
>>>>>>> siri_gm3

	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;
<<<<<<< HEAD


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


=======
	
	public g2_Pattern prevPattern;
	public g2_Pattern currentPattern;
	public g2_Pattern nextPattern;
	
	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start () {
		pattern.Add (green);
		pattern.Add (yellow);
		pattern.Add (red);
		pattern.Add (purple);
		
	 	prevPattern = new g2_Pattern("prev", pattern, 0.9f);
		currentPattern = new g2_Pattern("current", pattern, 1.9f);
		nextPattern = new g2_Pattern("next", pattern, 2.9f);
		
		drawTwo();
	}
	
	public void advance(){
		prevPattern.copy(currentPattern);
		currentPattern.copy(nextPattern);
		nextPattern.shuffle();
		drawAll();
	}
	
	void drawTwo(){
		drawPattern(currentPattern);
		drawPattern(nextPattern);
	}	
	void drawAll(){
		drawPattern(prevPattern);
		drawPattern(currentPattern);
		drawPattern(nextPattern);
	}

	void drawPattern(g2_Pattern pattern){
		for (int i = 0; i < 4; i++) {
			GameObject.Instantiate (pattern.getTile(i), pattern.getSpawn(i), rotation);
		}
	}

	public List<string> getCurrentPattern(){
		return currentPattern.getStringPattern();
	}
>>>>>>> siri_gm3

	void Update () {
	
	}
<<<<<<< HEAD
}
=======
}
>>>>>>> siri_gm3
