using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosLooper : MonoBehaviour {
	public GameObject lineObjectsSpawnerPrefab;
	private int y_offset = 1;

	void OnTriggerEnter2D(Collider2D other){
		Vector3 newLineObjectSpawnerPosition = GetComponent<LineObjectsSpawner> ().transform.position;
		newLineObjectSpawnerPosition.y += y_offset; 
		Instantiate (lineObjectsSpawnerPrefab, newLineObjectSpawnerPosition, Quaternion.identity);
	}
}
