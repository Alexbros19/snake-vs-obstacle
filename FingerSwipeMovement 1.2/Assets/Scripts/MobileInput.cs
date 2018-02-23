using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {

	private const float DEADZONE = 50f;
	private bool tap, swipeLeft, swipeRight;
	private Vector2 swipeDelta, startTouch;
	public static MobileInput Instance{ set; get; }
	public bool Tap{get{ return tap; }}
	public bool SwipeLeft{get{ return swipeLeft; }}
	public bool SwipeRight{get{ return swipeRight; }}
	public Vector2 SwipeDelta{get{ return swipeDelta; }}

	private void Awake(){
		Instance = this;
	}

	private void Update(){
		// reseting all the booleans
		tap = swipeLeft = swipeRight = false;

		// standalone inputs
		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			startTouch = Input.mousePosition;
		}else if(Input.GetMouseButtonUp(0)){
			startTouch = swipeDelta = Vector2.zero;
		}

		// mobile inputs
		if(Input.touches.Length != 0){
			if(Input.touches[0].phase == TouchPhase.Began){
				tap = true;
				startTouch = Input.mousePosition;
			}else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
				startTouch = swipeDelta = Vector2.zero;
			}
		}

		// Calculate distance
		swipeDelta = Vector2.zero;

		if(startTouch != Vector2.zero){
			if (Input.touches.Length != 0) {
				swipeDelta = Input.touches [0].position - startTouch;
			} else if (Input.GetMouseButton (0)) {
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		if(swipeDelta.magnitude > DEADZONE){
			float x = swipeDelta.x;
			float y = swipeDelta.y;

			if(Mathf.Abs(x) > Mathf.Abs(y)){
				if (x < 0) {
					swipeLeft = true;
				} else {
					swipeRight = true;
				}
			}
			startTouch = swipeDelta = Vector2.zero;	
		}
	}
}
