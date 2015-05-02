using UnityEngine;
using System.Collections;

public class g_Particle : MonoBehaviour {
	private int timer;
	public float zPos;

	// Use this for initialization
	void Start () {
		zPos = transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer >= 5) {
			Destroy(gameObject);
		}
	}
}
