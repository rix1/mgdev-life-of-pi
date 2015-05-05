using UnityEngine;
using System.Collections;

public class g2_Timer : MonoBehaviour {
	private float originalValueLeft;
	private float originalValueRight;
	private float maxScale;
	public bool gameOver;
	public bool neg = false;
	public bool pos = false;


	public void setPos(){
		pos = true;
	}

	public void setNeg(){
		neg = true;
	}

	void Start () {
		maxScale = transform.localScale.x;

		originalValueLeft = GetComponent<Renderer>().bounds.min.x;
		originalValueRight = GetComponent<Renderer>().bounds.max.x;

		Debug.Log("Right: " + originalValueRight);
		gameOver = false;
		

	}
	
	void Update () {
		
		if (transform.localScale.x >= 0) {
			updateSize(-0.05f);

		} else if(!gameOver){
			Debug.Log("Game DONE");
			gameOver = true;
			Debug.Log("Loading level..");
			Application.LoadLevel("GameMode3");
		}

		if (neg) {
			updateSize(-0.2f);
			neg = false;
		}
		if (pos) {
			updateSize(40f);
			pos = false;
		}
	}

	void updateSize(float x){

		if (x > 0) {
			float x2 = 0;
			float x3 = x * Time.deltaTime;
		
			float total = x3 + transform.localScale.x;

			Debug.Log("total " + total);
			if(total > maxScale){
				x2 = maxScale - transform.localScale.x;
				Debug.Log("Adding a little: " + x2);
			}else{
				x2 = x;
				Debug.Log("Adding a lot: " + x2);
			}

			transform.localScale += new Vector3 (x2, 0f, 0f) * Time.deltaTime;

		} else {
			float x2 = Mathf.Abs(x);
			transform.localScale -= new Vector3 (x2, 0f, 0f) * Time.deltaTime;
		}

		float newValueLeft = GetComponent<Renderer> ().bounds.min.x;
		float difference = newValueLeft - originalValueLeft;
		transform.Translate (new Vector3 (-difference, 0f, 0f));
	}
}
