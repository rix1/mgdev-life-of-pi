using UnityEngine;
using System.Collections;

public class lv_singerLogic : MonoBehaviour {

	public int whatSinger;
	private BoxCollider2D collider;
	public bool over;
	public GameObject player;
	
	private GameObject[] dialogObjects;

	// Use this for initialization
	void Start () {
		over = false;
//         Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
		dialogObjects = GameObject.FindGameObjectsWithTag("Dialog");
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Enter");
		displayDialogs(true);
	}
	
	void OnTriggerExit2D(Collider2D other){
		Debug.Log("Exit");
		displayDialogs(false);
	}
	
	void displayDialogs(bool display){
		Debug.Log("Displaying dialogs: "+ display);
		
		foreach (GameObject element in dialogObjects){
			Debug.Log("Setting " + element.name + " to " + display);
			element.SetActive(display);
		}
	}
}
