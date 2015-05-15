using UnityEngine;
using System.Collections;

public class g2_Score : MonoBehaviour {


	public GUIText scoreText;
	
	public int levelID = 1;
	
	public float posScore = 10;
	
	private int gameMode = 2;
	public float gameScore = 0;
	public int minPatterns = 10;

	private float originalValueLeft;
	private float originalValueRight;
	private float maxScale;
	public  bool gameOver;
	public bool neg = false;
	public bool pos = false;
	private Vector3 originalScale;
	


	public float decreaseTimer = -0.05f;
	public float negTimer = -0.05f;
	public float posTimer = 0.2f;

	void Start () {
		
		originalValueLeft = GetComponent<SpriteRenderer>().bounds.min.x;
		originalValueRight = GetComponent<SpriteRenderer>().bounds.max.x;
		gameOver = false;

		maxScale = transform.localScale.x;
		originalScale = new Vector3(1.12f,0.03f,1);
	}
	
	void OnGUI(){
		scoreText.text = "" + gameScore + " of 10";
	}
	
	void Update () {
		
		if (transform.localScale.x >= 0) {
			updateTimerSize(decreaseTimer);

		} else if(!gameOver){
			gameOver = true;
			gameFinishedLogic();
		}

		if (neg) {
			updateSize(negTimer);
			neg = false;
		}
		if (pos) {
			updateSize(posTimer);
			pos = false;
		}
	}

	public void setPos(){
		pos = true;
	}
	
	public void setNeg(){
		neg = true;
	}

	void updateSize(float x){
		//increase size of health bar when correct pattern
		if (x > 0) {
			float total = x + transform.localScale.x;
			//if added positive = bigger than the original health bar, only fill up 
			if(total > maxScale){
				transform.localScale = originalScale;
			}
			//increse size of health bar
			else{
				transform.localScale += new Vector3 (x, 0f, 0f);
			}
		}

		//decrease size of health bar when wrong pattern
		else {
			float x2 = Mathf.Abs(x);
			transform.localScale -= new Vector3 (x2, 0f, 0f);
		}
		float newValueLeft = GetComponent<SpriteRenderer> ().bounds.min.x;
		float difference = newValueLeft - originalValueLeft;
		transform.Translate (new Vector3 (-difference, 0f, 0f));
	}

	//constantly decrease size of health bar
	void updateTimerSize(float x){
		float x2 = Mathf.Abs(x);
		transform.localScale -= new Vector3 (x2, 0f, 0f) * Time.deltaTime;
		//update position so that the timer always stays left
		float newValueLeft = GetComponent<SpriteRenderer> ().bounds.min.x;
		float difference = newValueLeft - originalValueLeft;
		transform.Translate (new Vector3 (-difference, 0f, 0f));
	}
	
	private bool setScore(){
		return _gameState.setScore(levelID, gameMode, gameScore*posScore);
	}

	void gameFinishedLogic(){
		if (gameScore < minPatterns) {
			gameScore = 0;
			Application.LoadLevel ("g2_GameOver");
		} 
		else {
			if(setScore()){
				Debug.Log("NEW HIGHSCORE!");
			}
			gameScore = 0;
			Application.LoadLevel ("g2_GameOverWon");
		}
	}
}