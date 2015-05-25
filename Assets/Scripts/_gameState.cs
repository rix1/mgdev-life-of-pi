using UnityEngine;

public class _gameState {
	
	/**
	
	We need to store the following:
	
	- Player position
	- Player score
	
	**/
	
// 	private static Vector3 startPos = new Vector3(-9.0f, -3.2f,0); 
	private static Vector3 startPos = new Vector3(-28.0f, -10.4f,0);
	
	public static void reset(){
		PlayerPrefs.DeleteAll();
	}
	
	public static void saveState(){
		
		PlayerPrefs.SetInt("started", 1);
		
		PlayerPrefs.SetFloat("lvl1Score1", lvl1.getScore(1));
		PlayerPrefs.SetFloat("lvl1Score2", lvl1.getScore(2));
		PlayerPrefs.SetFloat("lvl1Score3", lvl1.getScore(3));
		
		PlayerPrefs.SetFloat("lvl2Score1", lvl2.getScore(1));
		PlayerPrefs.SetFloat("lvl2Score2", lvl2.getScore(2));
		PlayerPrefs.SetFloat("lvl2Score3", lvl2.getScore(3));
		
		PlayerPrefs.SetFloat("lvl3Score1", lvl3.getScore(1));
		PlayerPrefs.SetFloat("lvl3Score2", lvl3.getScore(2));
		PlayerPrefs.SetFloat("lvl3Score3", lvl3.getScore(3));
		
		
		PlayerPrefs.Save();
	}
	
	public static void loadState(){
		
		if(PlayerPrefs.GetInt("started", 0) != 0){
			Debug.Log("SHIT LOADEDD");
		
		float lvl1Score1 = PlayerPrefs.GetFloat("lvl1Score1", 0);		
		float lvl1Score2 = PlayerPrefs.GetFloat("lvl1Score2", 0);		
		float lvl1Score3 = PlayerPrefs.GetFloat("lvl1Score3", 0);		

		float lvl2Score1 = PlayerPrefs.GetFloat("lvl2Score1", 0);		
		float lvl2Score2 = PlayerPrefs.GetFloat("lvl2Score2", 0);		
		float lvl2Score3 = PlayerPrefs.GetFloat("lvl2Score3", 0);

		float lvl3Score1 = PlayerPrefs.GetFloat("lvl3Score1", 0);		
		float lvl3Score2 = PlayerPrefs.GetFloat("lvl3Score2", 0);		
		float lvl3Score3 = PlayerPrefs.GetFloat("lvl3Score3", 0);
		
		bool complete = false;
		
		setScore(1,1, lvl1Score1, complete);
		setScore(1,2, lvl1Score2, complete);
		setScore(1,3, lvl1Score3, complete);

		setScore(2,1, lvl2Score1, complete);
		setScore(2,2, lvl2Score2, complete);
		setScore(2,3, lvl2Score3, complete);

		setScore(3,1, lvl3Score1, complete);
		setScore(3,2, lvl3Score2, complete);
		setScore(3,3, lvl3Score3, complete);		
		}else{
			Debug.Log("SHIT NOT LOADEDD.....");
		}
	}	
	
	private static Vector3 playerPos = startPos;
	public static float playerScore;
	
	public static int currentLevel = 1; // First level by default
	
	public static LevelScore lvl1 = new LevelScore();
	public static LevelScore lvl2 = new LevelScore();
	public static LevelScore lvl3 = new LevelScore();
	
	private static bool started = false;

	public static bool isComplete(){
// 		Debug.Log("Level: " + currentLevel + " is complete: " + getLevel(currentLevel).isComplete());
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
					return new Vector3(-10.82f, -0.36f,0);
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
	
	public static bool setScore(int singer, float newScore){
		bool ret = getLevel(currentLevel).setScore(singer, newScore);
		Debug.Log("Setting score at level " + currentLevel + " : " + newScore);
		updateTotals();
		return ret;
	}
	
	
	public static bool setScore(int level, int singer, float newScore, bool complete){
		bool ret = getLevel(level).setScore(singer, newScore);
		if(complete){
			getLevel(level).completed(singer);
		}
		Debug.Log("Setting score at level " + level + " : " + newScore);
		updateTotals();
		return ret;
	}
	
	public static bool setScore(int level, int singer, float newScore){
		bool ret = getLevel(level).setScore(singer, newScore);
		Debug.Log("Setting score at level " + level + " : " + newScore);
		updateTotals();
		return ret;
	}
	
	public static void updateTotals(){
		// TODO.
	}
	
	public static AudioSource getNote(int noteNumber){
		return getLevel(currentLevel).getNote(noteNumber);
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