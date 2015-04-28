using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10 );

	// Use this for initialization
	void Start () {
//		Debug.Log ("HEISANN");
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (PlayerScript.movement.x);

		Vector3 movement = new Vector3(

			// We want to move in the player direction...
			speed.x * -1,
			speed.y * -1,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
	}
}
