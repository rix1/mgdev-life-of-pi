using UnityEngine;
using System.Collections;

public class _buttonPulse : MonoBehaviour {

	private float lightRange;
	private bool grow;
	
	public float max = 3f;
	public float min = 2f;
	public float rate = 0.002f;
	
	// Use this for initialization
	void Start () {
		lightRange = min;

		Vector3 temp = transform.localScale;
		temp.x = lightRange; 
		temp.y = lightRange; 
		transform.localScale = temp;

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
		
		Vector3 temp = transform.localScale;
		temp.x = lightRange;
		temp.y = lightRange; 

		transform.localScale = temp;	}
}