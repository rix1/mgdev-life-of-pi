using UnityEngine;
using System.Collections;

public class _Fade : MonoBehaviour {
	private int timer;
	public int timeToDestroy = 0;
		
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer >= timeToDestroy) {
			Destroy(gameObject);
		}
	}
}
