using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class g2_GameLogic : MonoBehaviour {
	
	private List<GameObject> pattern = new List<GameObject>();

	public GameObject green;
	public GameObject yellow;
	public GameObject red;
	public GameObject purple;
	
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
	
	public void increment(){
		GameObject mask = GameObject.Find("mask");
		Vector3 plus = new Vector3(1,0,0);
		mask.transform.position += plus;
	}
	
	public void reset(){
		GameObject mask = GameObject.Find("mask");
		Vector3 plus = new Vector3(-2.6f,3.5f,0);
		mask.transform.localPosition = plus;
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
		Debug.Log(currentPattern);
		return currentPattern.getStringPattern();
	}

	void Update () {

	}
}