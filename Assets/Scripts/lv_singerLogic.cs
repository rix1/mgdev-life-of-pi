using UnityEngine;
using System.Collections;

public class lv_singerLogic : MonoBehaviour {

	public int whatSinger;
	private BoxCollider2D collider;
	public bool over;
	public GameObject player;

	// Use this for initialization
	void Start () {
		over = false;
//         Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Enter");
		over = true;	
	}
}
