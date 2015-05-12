using UnityEngine;
using System.Collections;
using Rhythmify;


public class NoteGenerator : _AbstractRhythmObject {

	public GameObject green;
	public GameObject red;
	public GameObject yellow;

	private Vector3 spawnLoc1 = new Vector3(-1.8f ,4f,0f); 
	private Vector3 spawnLoc2 = new Vector3(0.0f ,4f,0f); 
	private Vector3 spawnLoc3 = new Vector3(1.8f ,4f,0f); 
	private int random = 0;

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	override protected void rhythmUpdate(int i){
		Debug.Log("BEAT: " + i + " : " + Random.Range(0,4));
		
		random = Random.Range(0,4);
		
		drawNote(random);
	}
	
	void drawNote(int i){
		switch (i)
			{
				case 1:
					Instantiate(green, spawnLoc1, rotation);
					break;
				case 2:
					Instantiate(yellow, spawnLoc2, rotation);
					break;
				case 3:
					Instantiate(red, spawnLoc3, rotation);
					break;
				default:
					break;
			}
		}
}
