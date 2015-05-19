using UnityEngine;
using System.Collections;

public class g3_Score : MonoBehaviour {

	public int levelID = 1;
	
	public float posScore = 10;
	public float negScore = 2;
	
	public int maxMistakes = 1;
	private int mistakes; 
	
	private int GameMode = 3;

	public static float gameScore;
	
	public static float playTime;
	public bool playing = false;
	
	void Start(){
		playing = true;
		playTime = 0;
		mistakes = 0;
		gameScore = 0;
	}
	
	void Update(){
		isPlaying();
	}

	public void updateScore(int code){
		if(code > 0){
			gameScore += posScore;
			Debug.Log("Points given " + gameScore);
		}else if(code < 0){
			if(gameScore > 0){
				gameScore -= negScore;
			}
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
			if(playTime >= GameObject.Find("Music").GetComponent<AudioSource>().clip.length + 6)
				gameOver();
		}
	}
	
	void gameOver(){
		if (mistakes >= maxMistakes) {
			Application.LoadLevel("g3_GameOver");
		}else{
			_gameState.completed(levelID);
			if(setScore()){
				Debug.Log("NEW HIGHSCORE!");
			}
			Application.LoadLevel("g3_GameOverWon");
		}
	}
}
