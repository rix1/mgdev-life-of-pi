using UnityEngine;

public class _gameState {
	
	/**
	
	We need to store the following:
	
	- Player position
	- Player score
	
	**/
	
	private static Vector3 startPos = new Vector3(-9.0f, -3.2f,0); 
	private static Vector3 playerPos;
	public static float playerScore;
	private static bool started = false;
	
	public static Vector3 getPlayerPos(){
		if(started){
			return playerPos;
		}else{
			started = true;	
			return startPos;
		}
	}
	
	public static void setPlayerPos(Vector3 newPos){
		playerPos = newPos;
		started = true;
	}
	
	public static float getNormalizedScore(){
		return playerScore;
	}
	
	
	public static float getScore(){
		return playerScore;
	}
	
	public static void setScore(float newScore){
		playerScore = newScore;
	}
}