using UnityEngine;
using System.Collections;

public class g3_LightScore : MonoBehaviour {
	private float score;

	public static Vector3 currentPos;
	private Vector3 endPos;

	void Start(){
	}

	void moveSmoothly(){
		transform.position = Vector3.Lerp(currentPos, endPos, (Time.deltaTime));
		currentPos = endPos;
	}

	void pointsToLight(){
		score = g3_Score.gameScore;

		currentPos = gameObject.transform.position;

		if (score > 0 && score <= 2) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, 0));
			moveSmoothly();
		}
		if (score > 2 && score <= 4) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -1));
			moveSmoothly();
		}
		if (score > 4 && score <= 6) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -2));
			moveSmoothly();
		}
		if (score > 6 && score <= 8) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -3));
			moveSmoothly();
		}
		if (score > 8 && score <= 10) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -4));
			moveSmoothly();
		}
		if (score > 10 && score <= 12) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -5));
			moveSmoothly();
		}
		if (score > 12 && score <= 14) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -6));
			moveSmoothly();
		}
		if (score > 14 && score <= 16) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -7));
			moveSmoothly();
		}
		if (score > 16 && score <= 18) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -8));
			moveSmoothly();
		}
		if (score > 18 && score <= 20) {
			endPos = gameObject.transform.position = (new Vector3(0f, -5, -9));
			moveSmoothly();
		}
	}

	void Update(){
		if (gameObject.transform.position.z > -8) {
			pointsToLight();
		}
		gameObject.GetComponent<Light> ().intensity = 4;
		gameObject.GetComponent<Light> ().range = 300;
		
	}
}
