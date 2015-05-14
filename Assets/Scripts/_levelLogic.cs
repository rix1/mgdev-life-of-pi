﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _levelLogic : MonoBehaviour {
	
	public string levelName;
	private string g1 = "g1_Start";
	private string g2 = "g2_Start";
	private string g3 = "g3_Start";
	
	public GameObject singer1;
	public GameObject singer2;
	public GameObject singer3;
	
	public float singerScore1;
	public float singerScore2;
	public float singerScore3;
	
	private List<GameObject> singers = new List<GameObject>();
	
	public float score = 0;
	
	private LevelScore lvl1 = new LevelScore();
	
	// Use this for initialization
	void Start () {
		
		singers.Add(singer1);
		singers.Add(singer2);
		singers.Add(singer3);
		
		_gameState.setScore(levelName, 1, singerScore1);
		_gameState.setScore(levelName, 2, singerScore2);
		_gameState.setScore(levelName, 3, singerScore3);
		
		setLight();
	}
	
	// Update is called once per frame
	void Update () {
	
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
	
    void setLight() {
		
// 		singer1.GetComponent<lv_singerLogic>().setLight();
		
//         foreach(GameObject singer in singers) {
// 			singer.GetComponent<lv_singerLogic>().setLight();
//         }
    }
	
	// TODO:
	
	public float getScore(int singer){
		return _gameState.getScore(levelName, singer);
	}
}