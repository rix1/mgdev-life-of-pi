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
	
	private static LevelScore lvl1 = new LevelScore("lvl1");
	private static LevelScore lvl2 = new LevelScore("lvl2");
	private static LevelScore lvl3 = new LevelScore("lvl3");
	
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
	
	
	public static float getScore(string level, int singer){
		return getLevel(level).getScore(singer);
	}
	
	public static void setScore(string level, int singer, float newScore){
		getLevel(level).setScore(singer, newScore);
		updateTotals();
	}
	
	public static void updateTotals(){
		// TODO.
	}
	
	private static LevelScore getLevel(string name){
		if(lvl1.name == name){
			return lvl1;
		}
		else if(lvl2.name == name){
			return lvl2;
		}
		else if(lvl3.name == name){
			return lvl3;
		}
		return null;
	}
}