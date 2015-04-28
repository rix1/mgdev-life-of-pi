using UnityEngine;
using System.Collections;

public class g_Note : MonoBehaviour {
	public float zPos;

	void Start () {
		zPos = transform.position.z;
	}
	
	void Update () {
		zPos = 0;
		transform.position += (new Vector3(0f, -5, 0f) * Time.deltaTime);
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
