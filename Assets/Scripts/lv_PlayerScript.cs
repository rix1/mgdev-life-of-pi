using UnityEngine;
using System.Collections;

/**
 * Default scripts come with the Start and Update methods. Here is a short list of the most used "Message" functions:

	Awake() is called once when the object is created. See it as replacement of a classic constructor method.
	Start() is executed after Awake(). The difference is that the Start() method is not called if the script is not enabled (remember the checkbox on a component in the "Inspector").
	Update() is executed for each frame in the main game loop.
	FixedUpdate() is called at every fixed framerate frame. You should use this method over Update() when dealing with physics ("RigidBody" and forces).
	Destroy() is invoked when the object is destroyed. It's your last chance to clean or execute some code.
	You also have some functions for the collisions :

	OnCollisionEnter2D(CollisionInfo2D info) is invoked when another collider is touching this object collider.
	OnCollisionExit2D(CollisionInfo2D info) is invoked when another collider is not touching this object collider anymore.
	OnTriggerEnter2D(Collider2D otherCollider) is invoked when another collider marked as a "Trigger" is touching this object collider.
	OnTriggerExit2D(Collider2D otherCollider) is invoked when another collider marked as a "Trigger" is not touching this object collider anymore.
 **/

public class lv_PlayerScript : MonoBehaviour {
	

	// Max speed....
	public Vector2 speed = new Vector2(50,50);
	public static Vector2 movement;



	// Use this for initialization
	void Start () {
		Debug.Log("HEISANN PLAYA");
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
	}

	void FixedUpdate() {
		// 5 - Move the game object
		GetComponent<Rigidbody2D>().velocity =  movement;


//		Debug.Log (movement.x + " : " + movement.y);
		
	}
}