using UnityEngine;
using System.Collections;

public class g1_Score : MonoBehaviour {
	public GUIText score;

	void OnGUI(){
		score.text = "" + g1_Maincode.song1score ;
	}
}
