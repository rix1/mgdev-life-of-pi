using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public GUIText score;

	void OnGUI(){
		score.text = "Score: " + Maincode.song1score ;
	}
}
