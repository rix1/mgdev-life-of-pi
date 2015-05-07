using UnityEngine;
using System.Collections;

public class _lightPulse : MonoBehaviour {


	private float lightRange;
	private bool grow;

	public float max = 10f;
	public float min = 5f;
	public float rate = 0.02f;

	// Use this for initialization
	void Start () {
		lightRange = min;
		GetComponent<Light> ().range = lightRange;
		grow = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (grow) {
			lightRange += rate;

			if(lightRange > max){
				grow = false;
			}
		} else {
			lightRange -= rate;

			if(lightRange < min){
				grow = true;
			}
		}
		GetComponent<Light> ().range = lightRange;
	}
}
