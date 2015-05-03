using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _perspectiveTouch : MonoBehaviour {

	public GameObject Particles1;
	public GameObject Particles2;
	public GameObject test;

	public Vector3 touchpoint;

	public const string LAYER_NAME = "Foreground";
	public int sortingOrder = 14;
	private SpriteRenderer sprite;

	void Start(){
//		
		touchpoint = new Vector3 (0, 0, 0);
		sprite = GetComponent<SpriteRenderer> ();

		if (sprite) {
			sprite.sortingOrder = sortingOrder;
			sprite.sortingLayerName = LAYER_NAME;
		}
	}

	void Update(){

		if (Input.touchCount > 0){
			Debug.Log("");
			Camera camera = Camera.main;

			Touch t = Input.GetTouch(0);

		
//			Vector3 p = camera.ViewportToWorldPoint(new Vector3(t.position.x, t.position.y, 0)); 
			Vector3 p = camera.ScreenToViewportPoint(new Vector3(t.position.x, t.position.y, 50)); 
			Vector3 w = camera.ViewportToWorldPoint(p); 

			touchpoint = w;

			Debug.Log("WorldPoint coord: " + w.x  + ":" + w.y*-1);

//			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//			Vector2 touchPos = new Vector2(wp.x, wp.y);

//			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint()){
				//your code
//				Debug.Log("Touch at: " + touchPos.x + ":" + touchPos.y);
//			}
		}
	}
}