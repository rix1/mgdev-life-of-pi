using UnityEngine;
using System.Collections;

public class g3_Score : MonoBehaviour {
	public GUIText score;

	void OnGUI(){
		score.text = "" + g3_Maincode.song1score ;
	}
}
