using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class g2_ButtonLogic : MonoBehaviour {

	public g2_GameLogic gameLogic;

	public List<GameObject> patterns = new List<GameObject>();

	public int WhatButton = 0;
	public GameObject sound;

	void Start () {
	}
	
	void Update () {
		if (WhatButton == 1) {
			transform.position = new Vector3(-1f, -1f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 2) {
			transform.position = new Vector3(1f, -1f, 0);
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		if (WhatButton == 3) {
			transform.position = new Vector3 (-1f, -3f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (WhatButton == 4) {
			transform.position = new Vector3 (1f, -3f, 0);
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void OnTouchDown(Vector2 point){
		if (WhatButton == 1) {
			Debug.Log ("GREEN BUTTON");
			GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		}

		if (WhatButton == 2) {
			Debug.Log ("YELLOW BUTTON");
			GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		}

		if (WhatButton == 3) {
			Debug.Log ("RED BUTTON");
			GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
			}

		if (WhatButton == 4) {	
			Debug.Log ("PURPLE BUTTON");
			GameObject.Instantiate (sound, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		}
	}
}