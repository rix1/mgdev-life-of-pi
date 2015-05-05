using UnityEngine;
using System.Collections;

public class lv1_PlayerParticles : MonoBehaviour {

	private int dir = 0;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		dir = GameObject.FindGameObjectWithTag ("Player").GetComponent<lv_PlayerScript> ().getDir ();

	}
}
