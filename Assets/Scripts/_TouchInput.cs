using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit2D hit;


	void Update () {

		if (Input.touchCount > 0) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches) {

				RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(touch.position), Vector2.zero); 

				if(hit.collider!=null){

					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
						Debug.Log("Touch at: " + hit.point.x + ":" + hit.point.y);
					}
					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
					}

				}

			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains(g)) {
					g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
				}
			}
		}

	}
}
