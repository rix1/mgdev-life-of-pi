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

	private Vector3 goTo_new;
	private Vector3 goTo_old;
	private Vector3 currentPosition;
	private bool pos;
	private bool moving;
	public bool debug;

	public int getDir(){
		if (moving) {
			return pos ? 1 : -1;
		} else {
			return 0;
		}
	}

	// Use this for initialization
	void Start () {
		goTo_new = new Vector3 (0, 0, 0);
		goTo_old = new Vector3 (0, 0, 0);
		Debug.Log("HEISANN PLAYA");
		moving = false;
		debug = true;
	}

	void move(Vector3 currentPos, Vector3 moveTo){
//		transform.position = moveTo;

		float inputX = 1;
		float inputY = 0;

		if (currentPos.x > moveTo.x) {
			inputX = -1;
			pos = false;
		} else {
			pos = true;
			inputX = 1;
		}

		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
		moving = true;
		goTo_old = moveTo;

	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = transform.position;
		
		goTo_new = GameObject.Find("Touch").GetComponent<_perspectiveTouch>().touchpoint;

		if (!debug) {
			if (goTo_new != goTo_old) {
				Debug.Log ("Lets move");
				// Move in new direction

				move (currentPosition, goTo_new);
			} 

			if (moving) {
				if (pos) {
					Debug.Log (currentPosition.x + ", old: " + goTo_old.x + ", new: " + goTo_new);
					if (currentPosition.x > goTo_old.x) {
						movement = new Vector2 (0, 0);
						Debug.Log ("STOOOP");
						moving = false;
					}
				} else {
					Debug.Log (currentPosition.x + ", old: " + goTo_old.x + ", new: " + goTo_new);
					if (currentPosition.x < goTo_old.x) {
						movement = new Vector2 (0, 0);
						Debug.Log ("STOOOP");
						moving = false;
					}
				}
			}
		} else {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			movement = new Vector2 (speed.x * inputX, speed.y * inputY);
		}
	}

	void FixedUpdate() {
		// 5 - Move the game object
		GetComponent<Rigidbody2D>().velocity =  movement;
	}
}