using UnityEngine;
using System.Collections;

public class _smoothTextFollow : MonoBehaviour {
	
	public Transform target ;
	float  smoothTime = 0.3f;
	private Vector2 velocity;
	private RectTransform thisTransform;
	float yOffset = 0.3f;
	
	public bool useSmoothing = false;
	void Start()
	{
		thisTransform = this.GetComponent<RectTransform>();
		velocity = new Vector2(0.5f, 0.5f);
	}
	
	void Update()
	{

        Debug.Log(thisTransform.position.x + " : " + thisTransform.position.y);
		Debug.Log(thisTransform.position.x + " : " + thisTransform.position.y);
		
		Vector2 newPos2D = Vector2.zero;
		if (useSmoothing){
			newPos2D.x =  Mathf.SmoothDamp( thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
			newPos2D.y= Mathf.SmoothDamp( thisTransform.position.y, target.position.y + yOffset, ref velocity.y, smoothTime) ;
		}else{			
			newPos2D.x = target.position.x;
			newPos2D.y = target.position.y + yOffset;
			
		}
		Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y , transform.position.z);
		transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
		
	}
}
