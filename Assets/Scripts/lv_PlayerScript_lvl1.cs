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

public class lv_PlayerScript_lvl1: MonoBehaviour {

    // Max speed....
    public Vector2 speed = new Vector2(50, 50);
    public static Vector2 movement;

    private Vector3 goTo_new;
    private Vector3 goTo_old;
    private Vector3 tempLoc;
    private Vector3 currentPosition;
    private bool pos;
    private bool moving;
    public bool debug;
    private bool prevDirection;
    private bool clicked = false;
    public BoxCollider2D roadCollider;
    public Sprite leftSprite;
    public Sprite rightSprite;
    
    public int getDir() {
        if (moving) {
            return pos ? 1 : -1;
        } else {
            return 0;
        }
    }

    // Use this for initialization
    void Start() {
        
        transform.localPosition = _gameState.getPlayerPos(GameObject.Find("Scripts").GetComponent<_levelLogic>().getLevelID()); 
        
        goTo_new = new Vector3(0, 0, 0);
        goTo_old = new Vector3(0, 0, 0);
        moving = false;
        debug = false;
        prevDirection = true;
    }

    void move(Vector3 currentPos, Vector3 moveTo) {
        //      transform.position = moveTo;

        float inputX = 1;
        float inputY = 0;

        if (currentPos.x > moveTo.x) {
            inputX = -1;
            pos = false; // Moving left
        } else {
            pos = true; // Moving right
            inputX = 1;
        }

        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        moving = true;
        goTo_old = moveTo;
    }
   

    // Update is called once per frame
    void Update() {
       
        currentPosition = transform.position;
        clicked = GameObject.Find("Touch").GetComponent < _perspectiveTouch > ().isNew();

        if (!debug) {
            if (clicked) {
                movePlayer();
            }
        } else {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if (inputX < 0) {
                setSprite(true);
            } else {
                setSprite(false);
            }

            movement = new Vector2(speed.x * inputX, speed.y * inputY);
        }
        
        if (moving) {
            GetComponent < Rigidbody2D > ().gravityScale = 9.81f;
            if (pos) { // If moving right 
                setSprite(true);
                // Debug.Log (currentPosition.x + ", old: " + goTo_old.x + ", new: " + goTo_new);
                if (currentPosition.x > goTo_old.x) {
                    movement = new Vector2(0, 0);
//                     Debug.Log ("STOOOP");
                    moving = false;
                    _gameState.setPlayerPos(transform.localPosition);
                }
            } else { // Moving left
                setSprite(false);
                // Debug.Log (currentPosition.x + ", old: " + goTo_old.x + ", new: " + goTo_new);
                if (currentPosition.x < goTo_old.x) {
                    movement = new Vector2(0, 0);
//                     Debug.Log("STOOOP");
                    _gameState.setPlayerPos(transform.localPosition);
                    moving = false;
                }
            }
        } else {
            GetComponent < Rigidbody2D > ().gravityScale = 0;
        }
    }

    // Left movevemt is true, right is false
    void setSprite(bool newDir) {

        // This means the direction has changed. Time to update the sprite! 
        // TODO: Set new sprite
        if (newDir) {
            GetComponent < SpriteRenderer > ().sprite = leftSprite;
        } else {
            GetComponent < SpriteRenderer > ().sprite = rightSprite;
        }
        prevDirection = newDir;
    }


    void movePlayer() {
        
        goTo_new = GameObject.Find("Touch").GetComponent < _perspectiveTouch > ().getTouchPoint();
        
        if (goTo_new.y > -20f && goTo_new.y < -4f) {

            // Application.LoadLevel("GameMode3");

            if (goTo_new != goTo_old) {
                // Move in new direction
                move(currentPosition, goTo_new);
            }
//             goTo_new = new Vector3(0, 0, 0);
        }
    }


    void FixedUpdate() {
        // 5 - Move the game object
        GetComponent < Rigidbody2D > ().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        Debug.Log("COLLISON");
    }
}