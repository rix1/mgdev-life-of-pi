using UnityEngine;
using System.Collections;

public class g2_Score : MonoBehaviour {

	public GUIText score;
	
	void OnGUI(){
		score.text = "" + g2_Maincode.score + " of 10";
	}
}
