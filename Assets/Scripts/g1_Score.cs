using UnityEngine;
using System.Collections;

public class g1_Score : MonoBehaviour {
	public GUIText score;

	public int levelID = 1;
	
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
	
	public static float playTime;
	public bool playing = false;
	
	void Start(){
		playing = true;
		playTime = 0;
		mistakes = 0;
		gameScore = 0;
		POS_SCORE = posScore;
		NEG_SCORE = negScore;
	}
	
	void Update(){
		isPlaying();
	}

	void OnGUI(){
		score.text = "" + gameScore;
	}

	public void updateScore(int code){
		if(code > 0){
			gameScore += posScore;
			Debug.Log("Points given " + gameScore);
		}else if(code < 0){
			gameScore -= negScore;
			Debug.Log("Points taken " + gameScore + " : " + mistakes);
			mistakes ++;
			
			if(mistakes >= maxMistakes){
				gameOver();
			}
			
		}else{ // Code is 0
			mistakes = maxMistakes+1;
			gameOver();
		}
	}
	
	private bool setScore(){
		return _gameState.setScore(levelID, GameMode, gameScore);
	}
	
	void isPlaying(){
		if (playing) {
			playTime += Time.deltaTime;
			if(playTime >= GameObject.Find("Music").GetComponent<AudioSource>().clip.length + 4)
				gameOver();
		}
	}
	
	void gameOver(){
		if (mistakes >= maxMistakes) {
			Application.LoadLevel("g1_GameOver");
		}else{
			Application.LoadLevel("g1_GameOverWon");
			if(setScore()){
				Debug.Log("NEW HIGHSCORE!");
			}
		}
	}
}
