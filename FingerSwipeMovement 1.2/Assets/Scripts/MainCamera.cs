using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
	private Transform playerTransform;

	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("SnakeHead").transform;
	}
	
	void Update () {
		if(playerTransform != null){
			transform.position = new Vector3 (transform.position.x, playerTransform.position.y, transform.position.z);
		}
	}
}
