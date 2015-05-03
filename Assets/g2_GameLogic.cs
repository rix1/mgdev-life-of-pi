﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class g2_GameLogic : MonoBehaviour {

	private List<GameObject> pattern = new List<GameObject>();

	public List<string> stringPattern = new List<string>();
	
	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;

	public List<GameObject> patterns = new List<GameObject>();

	public List<Vector3> spawnLocPrev = new List<Vector3>();
	public List<Vector3> spawnLocCurrent = new List<Vector3>();
	public List<Vector3> spawnLocNext = new List<Vector3>();
	
	private Vector3 spawnLocPrev1 = new Vector3(-1.5f , 1.5f,0f); 
	private Vector3 spawnLocPrev2 = new Vector3(-0.5f ,1.5f,0f); 
	private Vector3 spawnLocPrev3 = new Vector3(0.5f ,1.5f,0f); 
	private Vector3 spawnLocPrev4 = new Vector3(1.5f ,1.5f,0f); 

	private Vector3 spawnLocCurrent1 = new Vector3(-1.5f , 2.5f,0f); 
	private Vector3 spawnLocCurrent2 = new Vector3(-0.5f ,2.5f,0f); 
	private Vector3 spawnLocCurrent3 = new Vector3(0.5f ,2.5f,0f); 
	private Vector3 spawnLocCurrent4 = new Vector3(1.5f ,2.5f,0f); 

	private Vector3 spawnLocNext1 = new Vector3(-1.5f , 3.5f,0f); 
	private Vector3 spawnLocNext2 = new Vector3(-0.5f ,3.5f,0f); 
	private Vector3 spawnLocNext3 = new Vector3(0.5f ,3.5f,0f); 
	private Vector3 spawnLocNext4 = new Vector3(1.5f ,3.5f,0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start () {
		pattern.Add (green);
		pattern.Add (yellow);
		pattern.Add (red);
		pattern.Add (purple);

		spawnLocPrev.Add (spawnLocPrev1);
		spawnLocPrev.Add (spawnLocPrev2);
		spawnLocPrev.Add (spawnLocPrev3);
		spawnLocPrev.Add (spawnLocPrev4);

		spawnLocCurrent.Add (spawnLocCurrent1);
		spawnLocCurrent.Add (spawnLocCurrent2);
		spawnLocCurrent.Add (spawnLocCurrent3);
		spawnLocCurrent.Add (spawnLocCurrent4);

		spawnLocNext.Add (spawnLocNext1);
		spawnLocNext.Add (spawnLocNext2);
		spawnLocNext.Add (spawnLocNext3);
		spawnLocNext.Add (spawnLocNext4);

		generatePattern ();
	}

	public void generatePattern(){
		populatePattern();
		instantiatePattern (patterns, spawnLocCurrent);
		Debug.Log("New pattern generated: " + string.Join(" - ", stringPattern.ToArray()));
	}

	void instantiatePattern(List<GameObject> patterns,List<Vector3> spawnLoc){
		for (int i = 0; i < 4; i++) {
			for (int j = 0; i < 4; i++) {
				GameObject.Instantiate (patterns [i], spawnLoc[i], rotation);
			}
		}
	}

	//TODO Save previousPattern 

	//TODO Get nextPattern


	void populatePattern(){
		stringPattern.Clear();
		patterns.Clear ();

		GameObject random;
		for (int i = 0; i < 4; i++) {
			random = pattern[Random.Range(0,3)];
			patterns.Add(random);
			stringPattern.Add(random.transform.name);
		}
	}

	public List<string> getCurrentPattern(){
		return stringPattern;
	}

	void Update () {
	
	}
}
