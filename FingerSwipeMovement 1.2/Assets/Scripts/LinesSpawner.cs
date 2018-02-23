using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesSpawner : MonoBehaviour {

	public Transform linePrefab;

	void Start(){
		
		Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 5f, Screen.height / 2f, 10f)), Quaternion.identity);
		Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(2f * Screen.width / 5f, Screen.height / 2f, 10f)), Quaternion.identity);
		Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(3f * Screen.width / 5f, Screen.height / 2f, 10f)), Quaternion.identity);
		Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(4f * Screen.width / 5f, Screen.height / 2f, 10f)), Quaternion.identity);
	
		//Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 10f, Screen.height / 2f, 10f)), Quaternion.identity);
		//Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(3f *Screen.width / 10f, Screen.height / 2f, 10f)), Quaternion.identity);
		//Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(new Vector3(5f *Screen.width / 10f, Screen.height / 2f, 10f)), Quaternion.identity);
	}
}
