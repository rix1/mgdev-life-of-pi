using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class g2_GameLogic : MonoBehaviour {

	private List<GameObject> pattern = new List<GameObject>();

	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;

	public List<GameObject> patterns = new List<GameObject>();
	public List<Vector3> spawnLoc = new List<Vector3>();
	
	private Vector3 spawnLoc1 = new Vector3(-1.5f , 2.5f,0f); 
	private Vector3 spawnLoc2 = new Vector3(-0.5f ,2.5f,0f); 
	private Vector3 spawnLoc3 = new Vector3(0.5f ,2.5f,0f); 
	private Vector3 spawnLoc4 = new Vector3(1.5f ,2.5f,0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start () {
		pattern.Add (green);
		pattern.Add (yellow);
		pattern.Add (red);
		pattern.Add (purple);
		
		spawnLoc.Add (spawnLoc1);
		spawnLoc.Add (spawnLoc2);
		spawnLoc.Add (spawnLoc3);
		spawnLoc.Add (spawnLoc4);

		populatePattern();
	
		instantiatePattern (patterns, spawnLoc);

	}

	void instantiatePattern(List<GameObject> patterns,List<Vector3> spawnLoc){
		for (int i = 0; i < 4; i++) {
			for (int j = 0; i < 4; i++) {
				GameObject.Instantiate (patterns [i], spawnLoc[i], rotation);
			}
		}
	}

	List<GameObject> populatePattern(){
		for (int i = 0; i < 4; i++) {
			patterns.Add(pattern[Random.Range(0,3)]);
		}
		Debug.Log ("patterns: " + patterns[0]);

		return patterns;
	}
	
	void Update () {
	
	}
}
