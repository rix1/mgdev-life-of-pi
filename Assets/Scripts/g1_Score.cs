using UnityEngine;
using System.Collections;

public class g1_Score : MonoBehaviour {
	public GUIText score;

	public string level = "lvl1";
	
	public float posScore = 10;
	public float negScore = 2;
	
	
	public static float POS_SCORE = 0;
	public static float NEG_SCORE = 0;
	public int maxMistakes = 1;
	private int mistakes; 
	
	public int GameMode = 1;

	public static float gameScore;
	
	public static int song1score = 0; 
	public static int song1highscore = 0;
	
	void Start(){
		mistakes = 0;
		gameScore = 0;
		POS_SCORE = posScore;
		NEG_SCORE = negScore;
	}

	void OnGUI(){
		score.text = "" + song1score ;
	}

	public void updateScore(bool pos){
		if(pos){
			gameScore += posScore;
		}else{
			gameScore -= negScore;
			mistakes ++;
		}
	}
	
	private bool setScore(){
		return _gameState.setScore(level, GameMode, gameScore);
	}
	
	void gameOver(){
		if (!GameObject.Find("Music").GetComponent<AudioSource>().isPlaying) {
// 			Debug.Log("Song finished: " + g1_Maincode.song1score);
// 			g1_Maincode.song1highscore = g1_Maincode.song1score;
			if (mistakes >= maxMistakes) {
				Application.LoadLevel("g1_GameOver");
			}else{
				Application.LoadLevel("g1_GameOverWon");
			}
			setScore();
		}
	}
}
