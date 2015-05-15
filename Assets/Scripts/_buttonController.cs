using UnityEngine;
using System.Collections;

public class _buttonController : MonoBehaviour {

	public void activateButtons(bool activate){
		BoxCollider2D[] btnColliders = transform.GetComponentsInChildren<BoxCollider2D>();
		
		foreach (BoxCollider2D item in btnColliders)
		{
			item.enabled = activate;
		}
	}

}
