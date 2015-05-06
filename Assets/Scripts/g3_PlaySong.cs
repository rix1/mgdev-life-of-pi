using UnityEngine;
using System.Collections;

public class g3_PlaySong : MonoBehaviour {

	public GameObject green;
	public GameObject red;
	public GameObject yellow;

	private Vector3 spawnLoc1 = new Vector3(-1.8f ,4f, 0f); 
	private Vector3 spawnLoc2 = new Vector3(0.0f ,4f, 0f); 
	private Vector3 spawnLoc3 = new Vector3(1.8f ,4f, 0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	
	// Use this for initialization
	void Start () {
		StartCoroutine (SongStart());	
	}
	
	IEnumerator SongStart(){
		yield return new WaitForSeconds(2f);
		GameObject.Instantiate(green, spawnLoc1, rotation);
		yield return new WaitForSeconds(2f);
		GameObject.Instantiate(red, spawnLoc2, rotation);
		yield return new WaitForSeconds(2f);
		GameObject.Instantiate(yellow, spawnLoc3, rotation);
		yield return new WaitForSeconds(2);
		StartCoroutine (Song1());	

	}

	IEnumerator Song1(){
		yield return new WaitForSeconds(2f);
		GameObject.Instantiate(green, spawnLoc1, rotation);
	}
}
