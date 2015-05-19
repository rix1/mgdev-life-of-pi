using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _levelLogic : MonoBehaviour {
	
	public int levelID;
	private string g1 = "g1_Start";
	private string g2 = "g2_Start";
	private string g3 = "g3_Start";
	
	public GameObject singer1;
	public GameObject singer2;
	public GameObject singer3;
	
	public float singerScore1;
	public float singerScore2;
	public float singerScore3;
	
	public bool clickable;
	public bool clickable2;
	
	public bool completed = false;
	
	private List<GameObject> singers = new List<GameObject>();
	
	public int getLevelID(){
		return levelID;
	}
	
	private LevelScore lvl1 = new LevelScore();
	
	public bool delete = false;
	
	// Use this for initialization
	void Start () {
		
		clickable = true;
		clickable2 = true;
		
		singers.Add(singer1);
		singers.Add(singer2);
		singers.Add(singer3);
		
		_gameState.loadState();
		_gameState.setCurrentLevel(levelID);
		
		if(!_gameState.isComplete()){
			GameObject.Find("Nextlevel").SetActive(false);
		}else if(_gameState.currentLevel == 3){
			GameObject.Find("masterLight").GetComponent<Light>().intensity = 0.5f;
		}
		
		if(!(_gameState.currentLevel >1)){
			GameObject.Find("PrevLevel").SetActive(false);
		}
		setLight();
	}
	
    void OnApplicationQuit() {
		_gameState.saveState();
    }
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 1.0f;
		
		if(delete){
			_gameState.reset();
			Debug.Log("Game RESET");
			delete = false;
		}
		
		if(_gameState.currentLevel == 3 && _gameState.isComplete()){
			GameObject.Find("masterLight").GetComponent<Light>().intensity = 0.3f;
			Debug.Log("LEEEROOY: " + _gameState.currentLevel + " : " + _gameState.isComplete());
		}else{
			Debug.Log("JEEEEEEEENKINS: " + _gameState.currentLevel + " : " + _gameState.isComplete());
		}
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
	
	public bool setScore(int gameMode, float score){
		return _gameState.setScore(levelID, gameMode, score);
	}
	
	public void goToPrev(){
		if(clickable2){
			if(_gameState.currentLevel >1){
				Application.LoadLevel("Level" + (_gameState.currentLevel- 1));
			}else{
				Debug.Log("Already in the first level!");
			}
		}
		clickable2 = false;
	}
	
	public void goToNext(){
		if(clickable){
			Debug.Log("Starting next level: "+ "Level" + _gameState.currentLevel);
			Application.LoadLevel("Level" + (_gameState.currentLevel+1));
		}
		clickable = false;
	}
	
    void setLight() {
		
// 		singer1.GetComponent<lv_singerLogic>().setLight();
		
//         foreach(GameObject singer in singers) {
// 			singer.GetComponent<lv_singerLogic>().setLight();
//         }
    }
	
	// TODO:
	
	public float getScore(int singer){
		return _gameState.getScore(levelID, singer);
	}
}
