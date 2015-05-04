using UnityEngine;
using System.Collections;

public class lv_singerLogic : MonoBehaviour {

	public int whatSinger;
	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {

		collider = GetComponent<BoxCollider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
