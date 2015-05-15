using UnityEngine;
using System.Collections;

public class g2_Maincode : MonoBehaviour {
	public static int score = 0; 
	public static int highscore = 0; 
	
	
	
	public static int minPatterns = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public static bool setScore(){
		// Because retard, we need to get level information from ScoreClass:
		
		int level = GameObject.Find("Score").GetComponent<g2_Score>().levelID;
		int gamemode = GameObject.Find("Score").GetComponent<g2_Score>().gameMode;
		
		return _gameState.setScore(level, gamemode, score);
	}
}
