using UnityEngine;
using System.Collections;

public class NoteButton : MonoBehaviour {
	public int WhatButton = 1;
	private Transform objectButton;
	public GameObject ErrorSound;
	public GameObject RightSound;
	
	void Start () {
		if ( WhatButton == 1){
			objectButton = GameObject.Find("green").transform;
		}
		if ( WhatButton == 2){
			objectButton = GameObject.Find("red").transform;
		}
		if ( WhatButton == 3){
			objectButton = GameObject.Find("yellow").transform;
		}
	}
}