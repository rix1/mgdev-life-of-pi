using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class _Sound : MonoBehaviour {
	AudioSource audio;
	
	public int noteNumber = 1;

	void Start () {
// 		audio = _gameState.getNote(noteNumber); NotYetImplementedException!
		audio = GetComponent<AudioSource>();
		audio.Play ();
		StartCoroutine(playSound());	
	}

	IEnumerator playSound(){
		yield return new WaitForSeconds(audio.clip.length);
		Destroy(gameObject);
	}
}