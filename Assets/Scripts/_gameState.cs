using UnityEngine;

public class _gameState {
	
	/**
	
	We need to store the following:
	
	- Player position
	- Player score
	
	**/
	
// 	private static Vector3 startPos = new Vector3(-9.0f, -3.2f,0); 
	private static Vector3 startPos = new Vector3(-28.0f, -10.4f,0); 
	
	private static Vector3 playerPos = startPos;
	public static float playerScore;
	
	public static int currentLevel = 1; // First level by default
	
	private static LevelScore lvl1 = new LevelScore();
	private static LevelScore lvl2 = new LevelScore();
	private static LevelScore lvl3 = new LevelScore();
	
	private static bool started = false;

	public static bool isComplete(){
		Debug.Log("Level: " + currentLevel + " is complete: " + getLevel(currentLevel).isComplete());
		return getLevel(currentLevel).isComplete();
	}
	
	public static Vector3 getPlayerPos(){
		
		Debug.Log("Getting current position: " + currentLevel);
		Vector3 nil = new Vector3(0,0,0);
		
		switch (currentLevel)
		{
			case 1: 
				if(lvl1.lastPosition == nil){
					Debug.Log("RETURNING LEVEL 1 Default");
					return new Vector3(-28.0f, -10.4f,0);
				}else return lvl1.lastPosition;
			case 2: 
				if(lvl2.lastPosition == nil){
					return new Vector3(-9.0f, -3.2f,0);
				}else return lvl2.lastPosition;
			case 3:
				if(lvl3.lastPosition == nil){
					return new Vector3(-9.0f, -3.2f,0);
				}else return lvl3.lastPosition;
			default: return playerPos;
		}
	}
	
	public static string getCurrentLevelString(){
		return "Level" + currentLevel;
	}
	
	public static void setCurrentLevel(int id){
		currentLevel = id;
	}
	
	public static void setPlayerPos(Vector3 newPos){
		getLevel(currentLevel).lastPosition = newPos;
		playerPos = newPos;
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
	
	public static void completed(int singer){
		getLevel(currentLevel).completed(singer);
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