using UnityEngine;
using System.Collections;

public class g_Score : MonoBehaviour {
	public GUIText score;

	void OnGUI(){
		score.text = "Score: " + g_Maincode.song1score ;
	}
}
