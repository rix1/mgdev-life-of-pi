using UnityEngine;
using System.Collections;

public class g2_Score : MonoBehaviour {

	public GUIText score;
	
	public int levelID = 1;
	public int gameMode = 2;
	
	void OnGUI(){
		score.text = "" + g2_Maincode.score + " of 10";
	}
}