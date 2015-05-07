using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class g2_GameLogic : MonoBehaviour {

	private List<GameObject> pattern = new List<GameObject>();

	public List<string> stringPattern = new List<string>();
	
	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;

	public List<GameObject> currentPattern = new List<GameObject>();
	public List<GameObject> nextPattern = new List<GameObject>();

	public List<Vector3> spawnLocCurrent = new List<Vector3>();
	public List<Vector3> spawnLocNext = new List<Vector3>();

	private Vector3 spawnLocNext1 = new Vector3(-1.5f , 2.5f,0f); 
	private Vector3 spawnLocNext2 = new Vector3(-0.5f ,2.5f,0f); 
	private Vector3 spawnLocNext3 = new Vector3(0.5f ,2.5f,0f); 
	private Vector3 spawnLocNext4 = new Vector3(1.5f ,2.5f,0f); 
	
	private Vector3 spawnLocCurrent1 = new Vector3(-1.5f , 1.5f,0f); 
	private Vector3 spawnLocCurrent2 = new Vector3(-0.5f ,1.5f,0f); 
	private Vector3 spawnLocCurrent3 = new Vector3(0.5f ,1.5f,0f); 
	private Vector3 spawnLocCurrent4 = new Vector3(1.5f ,1.5f,0f); 


	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start () {
		pattern.Add (green);
		pattern.Add (yellow);
		pattern.Add (red);
		pattern.Add (purple);

		spawnLocCurrent.Add (spawnLocCurrent1);
		spawnLocCurrent.Add (spawnLocCurrent2);
		spawnLocCurrent.Add (spawnLocCurrent3);
		spawnLocCurrent.Add (spawnLocCurrent4);

		spawnLocNext.Add (spawnLocNext1);
		spawnLocNext.Add (spawnLocNext2);
		spawnLocNext.Add (spawnLocNext3);
		spawnLocNext.Add (spawnLocNext4);

		updatePatterns ();
	}

	void generatePattern(){
//		 stringPattern.Clear();
//		currentPattern.Clear ();

		List<GameObject> newPattern = new List<GameObject>();

		GameObject random;
		for (int i = 0; i < 4; i++) {
			random = pattern[Random.Range(0,4)];
			newPattern.Add(random);
			stringPattern.Add(random.transform.name);
		}
	}

	void instantiatePattern(List<GameObject> patterns,List<Vector3> spawnLoc){
		for (int i = 0; i < 4; i++) {
			for (int j = 0; i < 4; i++) {
				GameObject.Instantiate (patterns [i], spawnLoc [i], rotation);
			}
		}
	}

	void moveDown (){
		currentPattern = nextPattern;
		instantiatePattern (currentPattern, spawnLocCurrent);
	}


	public void updatePatterns(){
		generatePattern();
		instantiatePattern (nextPattern, spawnLocNext);
		moveDown ();
		
		Debug.Log("New pattern generated: " + string.Join(" - ", stringPattern.ToArray()));
	}

	public List<string> getCurrentPattern(){
		return stringPattern;
	}

	void Update () {

	}

}
