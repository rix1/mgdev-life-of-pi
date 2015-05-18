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
	
	public static int currentLevel = 1; // First level by default
	
	private static LevelScore lvl1 = new LevelScore();
	private static LevelScore lvl2 = new LevelScore();
	private static LevelScore lvl3 = new LevelScore();
	
	private static bool started = false;

	public static bool isComplete(){
		return getLevel(currentLevel).isComplete();
	}
	
	public static Vector3 getPlayerPos(int level){
		
		switch (level)
		{
			case 1: return new Vector3(-28.0f, -10.4f,0);
			case 2: return new Vector3(-9.0f, -3.2f,0);
			default: return startPos;
		}
		
		if(started){
			return playerPos;
		}else{
			started = true;	
			return startPos;
		}
	}
	
	public static string getCurrentLevelString(){
		return "Level" + currentLevel;
	}
	
	public static void setCurrentLevel(int id){
		currentLevel = id;
	}
	
	public static void setPlayerPos(Vector3 newPos){
		playerPos = newPos;
		started = true;
	}
	
	public static float getNormalizedScore(){
		return playerScore;
	}
	
	
	public static float getScore(int level, int singer){
		return getLevel(level).getScore(singer);
	}
	
	public static bool setScore(int level, int singer, float newScore){
		bool ret = getLevel(currentLevel).setScore(singer, newScore);
		Debug.Log("Setting score at level " + currentLevel + " : " + newScore);
		updateTotals();
		return ret;
	}
	
	public static void updateTotals(){
		// TODO.
	}
	
	private static LevelScore getLevel(int id){
		switch (id)
		{
			case 1: return lvl1;
			case 2: return lvl2;
			case 3: return lvl3;
			default:
			Debug.Log("You have to set the correct level! Stopping application...");
			Application.Quit(); 
			return null;
		}
	}
}