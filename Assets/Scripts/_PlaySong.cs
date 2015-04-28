using UnityEngine;
using System.Collections;

public class _PlaySong : MonoBehaviour {

	public GameObject green;
	public GameObject red;
	public GameObject yellow;

	private Vector3 spawnLoc1 = new Vector3(-1.8f ,4f,0f); 
	private Vector3 spawnLoc2 = new Vector3(0f,4f,0f); 
	private Vector3 spawnLoc3 = new Vector3(1.8f,4f,0f); 


	
	// Use this for initialization
	void Start () {
		StartCoroutine (SongStart());	
	}
	
	IEnumerator SongStart(){
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		StartCoroutine (Song1());	

	}

	IEnumerator Song1(){
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
		GameObject.Instantiate(green, spawnLoc1, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(red, spawnLoc2, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(.5f);
		GameObject.Instantiate(yellow, spawnLoc3, Quaternion.Euler(0,0,0));
		yield return new WaitForSeconds(1);
	}
}
