using UnityEngine;
using System.Collections;
using Rhythmify;

public class _PlaySong : MonoBehaviour
{
	public GameObject green;
	public GameObject red;
	public GameObject yellow;

	public int greenNotes = 20;
	public int redNotes = 20;
	public int yellowNotes = 20;

	AudioSource audio;
	public double BPM = 141;
	public double beatSamples = 0;
	public double nextBeatSamples = 0;

	private Vector3 spawnLoc1 = new Vector3(-1.8f ,4f,0f); 
	private Vector3 spawnLoc2 = new Vector3(0.0f ,4f,0f); 
	private Vector3 spawnLoc3 = new Vector3(1.8f ,4f,0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);

	void Start()
	{
		beatSamples = (44100 / (BPM / 60));
		audio = GetComponent<AudioSource> ();
		StartCoroutine(CreateGreenNotes());
		StartCoroutine(CreateRedNotes());
		StartCoroutine(CreateYellowNotes());
	}


		
	// Need to check this 
	
	IEnumerator CreateGreenNotes()
	{
		while(greenNotes > 0)
		{
			if (audio.timeSamples >= nextBeatSamples && audio.isPlaying)
			{
				//audio.Play();
				yield return new WaitForSeconds(.4f);
				Instantiate(green, spawnLoc1, rotation);
				greenNotes--;
				nextBeatSamples += beatSamples;
			}
		}
	}

	IEnumerator CreateRedNotes()
	{
		while(redNotes > 0)
		{
			if (audio.timeSamples >= nextBeatSamples && audio.isPlaying)
			{
				//audio.Play();
				yield return new WaitForSeconds(.8f);
				Instantiate(red, spawnLoc2, rotation);
				redNotes--;
				nextBeatSamples += beatSamples;
			}
		}
	}

	IEnumerator CreateYellowNotes()
	{
		while(yellowNotes > 0)
		{
			if (audio.timeSamples >= nextBeatSamples && audio.isPlaying)
			{
				//audio.Play();
				yield return new WaitForSeconds(1.2f);
				Instantiate(yellow, spawnLoc3, rotation);
				yellowNotes--;
				nextBeatSamples += beatSamples;
			}
		}
		Application.Quit ();
	}
}
