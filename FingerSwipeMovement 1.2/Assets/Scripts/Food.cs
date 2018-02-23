using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public int number = 0;
	public static float foodSpeed = 0;
	public static int challenge8Counter = 0;
	public static bool isTakeFood = false;
	public Sprite[] snakeSkinImages = new Sprite[18];
	public ParticleSystem[] foodParticles = new ParticleSystem[18];

	private const int PARTICLELIFETIME = 1;
	private const float TIMEBETWEENFUNCTIONCALL = 0.05f;

	void Start(){
		ChangeFoodSpriteImage ();
		foodSpeed = 3f;
		isTakeFood = false;
	}

	void Update () {
		transform.Translate (new Vector3(0, -1, 0) * foodSpeed * Time.deltaTime);
	}

	void ChangeFoodSpriteImage(){
		SpriteRenderer foodImage = this.gameObject.GetComponent<SpriteRenderer> ();

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int number = PlayerPrefs.GetInt ("PressedButtonNumber");

			foodImage.sprite = snakeSkinImages [number - 1];
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		float speedCallFunction = TIMEBETWEENFUNCTIONCALL;

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int n = PlayerPrefs.GetInt ("PressedButtonNumber");

			switch(n){
			case 1:
				Destroy (Instantiate (foodParticles [0].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 2:
				Destroy (Instantiate (foodParticles [1].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 3:
				Destroy (Instantiate (foodParticles [2].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 4:
				Destroy (Instantiate (foodParticles [3].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 5:
				Destroy (Instantiate (foodParticles [4].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 6:
				Destroy (Instantiate (foodParticles [5].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 7:
				Destroy (Instantiate (foodParticles [6].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 8:
				Destroy (Instantiate (foodParticles [7].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 9:
				Destroy (Instantiate (foodParticles [8].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 10:
				Destroy (Instantiate (foodParticles [9].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 11:
				Destroy (Instantiate (foodParticles [10].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 12:
				Destroy (Instantiate (foodParticles [11].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 13:
				Destroy (Instantiate (foodParticles [12].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 14:
				Destroy (Instantiate (foodParticles [13].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 15:
				Destroy (Instantiate (foodParticles [14].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 16:
				Destroy (Instantiate (foodParticles [15].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 17:
				Destroy (Instantiate (foodParticles [16].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			case 18:
				Destroy (Instantiate (foodParticles [17].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
				break;
			}
		}

		if(other.CompareTag("SnakeHead")){
			// for 7th challenge
			isTakeFood = true;
			// for 8th challenge
			if(number == 5){
				challenge8Counter++;
			}

			while(number > 0){
				other.GetComponent<PlayerController> ().Invoke ("AddTail", speedCallFunction);
				Destroy (gameObject);
				number--;
				speedCallFunction += TIMEBETWEENFUNCTIONCALL;
			}
		}

		if(other.CompareTag("LimitCollider")){
			Destroy (gameObject);
		}
	}
}
