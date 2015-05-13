using UnityEngine;
using System.Collections;

public class _gameLogic : MonoBehaviour {
	
	public string thisScene;
	private string g1 = "g1_Start";
	private string g2 = "g2_Start";
	private string g3 = "g3_Start";
	
	public float score = 0;
	
	// Use this for initialization
	void Start () {
		_gameState.setScore(score);
		setLight();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void loadG1(){
		Application.LoadLevel(g1);
	}
	public void loadG2(){
		Application.LoadLevel(g2);
	}
	public void loadG3(){
		Application.LoadLevel(g3);
	}
	
    void setLight() {

        GameObject[] singers = GameObject.FindGameObjectsWithTag("Singer1");

        foreach(GameObject singer in singers) {
            Vector3 tempPos = singer.GetComponent<Light>().transform.localPosition;
            float test = tempPos.z;
            tempPos.z = test - (_gameState.getNormalizedScore() * 0.2f);
            singer.GetComponent<Light>().transform.localPosition = tempPos;
            Debug.Log("Setting light at " + tempPos + " score: " + _gameState.getScore());
            singer.GetComponent<Light>().range = _gameState.getNormalizedScore();
        }
    }
}
