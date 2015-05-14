using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class g_delayedMusic : MonoBehaviour {
	AudioSource audio;

	void Start () {
		Debug.Log("Programmet starter");
		audio = GetComponent<AudioSource>();
		StartCoroutine(playSound());	
	}

	IEnumerator playSound(){
		yield return new WaitForSeconds(2.8f);
		audio.Play ();
		audio.mute = false;
		Debug.Log("Sangen starter nu?");
	}
}