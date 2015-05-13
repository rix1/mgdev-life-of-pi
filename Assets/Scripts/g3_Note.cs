using UnityEngine;
using System.Collections;

public class g3_Note : MonoBehaviour {
	public float zPos;

	void Start () {
		zPos = transform.position.z;
	}

	void Update () {
		transform.position += (new Vector3(0f, -4.5f, -20f) * Time.deltaTime);
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
