using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObjectsSpawner : MonoBehaviour {
	public GameObject[] gameObjects = new GameObject[10];
	public GameObject[] blocks = new GameObject[50];
	public GameObject[] foods = new GameObject[5];
	public GameObject[] lineBlocks = new GameObject[2];

	public static float delaySpawnTime = 1f;
	public static bool isGameOver;
	private float timer = 0f;

	void Start () {
		timer = delaySpawnTime;
		isGameOver = false;
	}
	
	void Update () {
		if(!isGameOver){
			timer -= Time.deltaTime;

			gameObjects [5] = blocks [Random.Range (0, 10)];
			gameObjects [4] = blocks [Random.Range (0, 50)];
			gameObjects [3] = blocks [Random.Range (0, 50)];
			gameObjects [2] = blocks [Random.Range (0, 50)]; 
			gameObjects [1] = lineBlocks [Random.Range (0, 2)];
			gameObjects [0] = foods [Random.Range (0, 5)];

			if(timer <= 0){

				Instantiate (gameObjects[Random.Range(0, 10)], Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2f, Screen.height + 1f, 10f)), Quaternion.identity); 

				Instantiate (gameObjects[Random.Range(0, 10)], Camera.main.ScreenToWorldPoint (new Vector3 (1f * Screen.width / 10f, Screen.height + 1f, 10f)), Quaternion.identity); 

				Instantiate (gameObjects[Random.Range(0, 10)], Camera.main.ScreenToWorldPoint (new Vector3 (3f * Screen.width / 10f, Screen.height + 1f, 10f)), Quaternion.identity); 

				Instantiate (gameObjects[Random.Range(0, 10)], Camera.main.ScreenToWorldPoint (new Vector3 (7f * Screen.width / 10f, Screen.height + 1f, 10f)), Quaternion.identity); 

				Instantiate (gameObjects[Random.Range(0, 10)], Camera.main.ScreenToWorldPoint (new Vector3 (9f * Screen.width / 10f, Screen.height + 1f, 10f)), Quaternion.identity);

				timer = delaySpawnTime;
			}
		}
	}
}
