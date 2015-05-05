using UnityEngine;
using System.Collections;

public class g3_NoteButton : MonoBehaviour {
	public int WhatButton = 1;
	private Transform objectButton;

	void Start () {
		if ( WhatButton == 1){
			objectButton = GameObject.Find("Button1").transform;
		}
		if ( WhatButton == 2){
			objectButton = GameObject.Find("Button2").transform;
		}
		if ( WhatButton == 3){
			objectButton = GameObject.Find("Button3").transform;
		}
	}
}