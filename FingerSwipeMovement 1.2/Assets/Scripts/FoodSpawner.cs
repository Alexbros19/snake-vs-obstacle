using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
	public GameObject foodPrefab;
	public float delaySpawnTime = 1f;
	private int number;
	private float timer = 0f;

	void Start () {
		timer = delaySpawnTime;
	}
	
	void Update () {
		timer -= Time.deltaTime;

		if(timer <= 0){
			number = Random.Range (0, 5);
			switch(number){
			case 0: 
				Instantiate (foodPrefab, Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2f, Screen.height + 1f, 10f)), transform.rotation); 
				break;
			case 1: 
				Instantiate (foodPrefab, Camera.main.ScreenToWorldPoint (new Vector3 (1f * Screen.width / 10f, Screen.height + 1f, 10f)), transform.rotation); 
				break;
			case 2: 
				Instantiate (foodPrefab, Camera.main.ScreenToWorldPoint (new Vector3 (3f * Screen.width / 10f, Screen.height + 1f, 10f)), transform.rotation); 
				break;
			case 3: 
				Instantiate (foodPrefab, Camera.main.ScreenToWorldPoint (new Vector3 (7f * Screen.width / 10f, Screen.height + 1f, 10f)), transform.rotation); 
				break;
			case 4: 
				Instantiate (foodPrefab, Camera.main.ScreenToWorldPoint (new Vector3 (9f * Screen.width / 10f, Screen.height + 1f, 10f)), transform.rotation); 
				break;
			}

			delaySpawnTime = Random.Range (1f, 3f);
			timer = delaySpawnTime;
		}
	}
}
