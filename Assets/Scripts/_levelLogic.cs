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
	
	private List<GameObject> singers = new List<GameObject>();
	
	public int getLevelID(){
		return levelID;
	}
	
	private LevelScore lvl1 = new LevelScore();
	
	// Use this for initialization
	void Start () {
		
		clickable = true;
		clickable2 = true;
		
		singers.Add(singer1);
		singers.Add(singer2);
		singers.Add(singer3);
		
		
		_gameState.setCurrentLevel(levelID);
		
		_gameState.setScore(levelID, 1, singerScore1);
		_gameState.setScore(levelID, 2, singerScore2);
		_gameState.setScore(levelID, 3, singerScore3);
		
		if(_gameState.isComplete()){
			GameObject.Find("Nextlevel").SetActive(true);
		}else{
			GameObject.Find("Nextlevel").SetActive(false);
		}
		
		if(_gameState.currentLevel >1){
			GameObject.Find("PrevLevel").SetActive(true);
		}else{
			GameObject.Find("PrevLevel").SetActive(false);
		}
		
		setLight();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 1.0f;
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
