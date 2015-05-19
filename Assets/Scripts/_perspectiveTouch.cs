using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _perspectiveTouch : MonoBehaviour {

	private Vector3 touchpoint;

	public const string LAYER_NAME = "Foreground";
	private int sortingOrder = 14;
	private SpriteRenderer sprite;
	private bool clicked = false;
	GameObject[] dialogObjects;

	void Start(){
		touchpoint = new Vector3 (0, 0, 0);
		sprite = GetComponent<SpriteRenderer> ();

		if (sprite) {
			sprite.sortingOrder = sortingOrder;
			sprite.sortingLayerName = LAYER_NAME;
		}
		clicked = true;
	}

	void Update(){
		updateTouchPoint();	
	}
	
	public bool isNew(){
		return clicked;
	}
	
	void FixedUpdate(){
	}
	
	void updateTouchPoint(){
		if (Input.touchCount > 0){
			Camera camera = Camera.main;
		
			Touch t = Input.GetTouch(0);
			Vector3 p = camera.ScreenToViewportPoint(new Vector3(t.position.x, t.position.y, 50)); 
			Vector3 w = camera.ViewportToWorldPoint(p);
			
			Debug.Log("Touch registered: " + touchpoint); 
			
			if(touchpoint != w){
				touchpoint = w;
				clicked = true;
			}else{
				clicked = false;
				Debug.Log("The touchpoint is equal");
			}
			
		}
	}
	
	public Vector3 getTouchPoint(){
		return touchpoint;
	}
}