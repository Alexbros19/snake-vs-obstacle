using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailsCounterControl : MonoBehaviour {
	public Text counterLabel;
	
	void Update () {
		Vector3 counterPosition = Camera.main.WorldToScreenPoint (this.transform.position);
		if(gameObject != null){
			counterLabel.transform.position = counterPosition;
			counterLabel.text = PlayerController.tailsCount.ToString ();
		}
	}
}
