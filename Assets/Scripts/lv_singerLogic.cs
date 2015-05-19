using UnityEngine;

public class lv_singerLogic : MonoBehaviour {

	
	private GameObject level;
	public int id = 0;
	
	private GameObject[] dialogObjects;

	// Use this for initialization
	void Start () {
		level = GameObject.Find("Scripts");
		
		dialogObjects = GameObject.FindGameObjectsWithTag("Dialog");
		setLight();
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
	
	float getScore(){
		return level.GetComponent<_levelLogic>().getScore(id);
	}
	
	public void setLight(){
		
		GameObject lys = transform.Find("light").gameObject;
		Vector3 tempPos = lys.transform.localPosition;
		
		float score = getScore();
		
		if(score >= 25){
			score = 25;
		}
		
        tempPos.z -= (score * 0.2f);
		lys.transform.localPosition = tempPos;
// 		Debug.Log("Setting light on " + lys.name + " at " + tempPos + " score: " + getScore());
		lys.GetComponent<Light>().range = score;
	}
	
	void displayDialogs(bool display){
		Debug.Log("Displaying dialogs: "+ display);
		
		foreach (GameObject element in dialogObjects){
// 			Debug.Log("Setting " + element.name + " to " + display);
			element.SetActive(display);
		}
	}
}
