using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class _Sound : MonoBehaviour {
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
		audio.Play ();
		StartCoroutine(playSound());	
	}

	IEnumerator playSound(){
		yield return new WaitForSeconds(audio.clip.length);
		Destroy(gameObject);
	}
}