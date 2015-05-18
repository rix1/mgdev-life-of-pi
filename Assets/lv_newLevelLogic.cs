using UnityEngine;

public class lv_newLevelLogic : MonoBehaviour {

	private bool display = false;

	public int id = 0;
	
	private GameObject[] dialogObjects;
	
	void Start () {
		dialogObjects = GameObject.FindGameObjectsWithTag("NextLevel");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Enter");
		displayNewLevel(true);
	}
	
	void OnTriggerExit2D(Collider2D other){
		Debug.Log("Exit");
		displayNewLevel(false);
	}
	
	void displayNewLevel(bool display){
		Debug.Log("Displaying next level logic: "+ display);
		
		foreach (GameObject element in dialogObjects){
			Debug.Log("Setting " + element.name + " to " + display);
			element.SetActive(display);
		}
	}
}
