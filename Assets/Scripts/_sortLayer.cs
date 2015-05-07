using UnityEngine;
using System.Collections;

public class _sortLayer : MonoBehaviour {


	public string layer = "";
	public int order = 0;

	// Use this for initialization
	void Start () {

//		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";

		GetComponent<ParticleSystemRenderer> ().sortingLayerName = layer;
		GetComponent<ParticleSystemRenderer> ().sortingOrder = order;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
