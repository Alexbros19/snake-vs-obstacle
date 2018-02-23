using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public static float blockSpeed = 0;
	public static int challenge1Counter = 0;
	public static int challenge10Counter = 0;
	public static int challenge17Counter = 0;
	public int number = 0;
	public ParticleSystem[] blockParticles;
	private const int PARTICLELIFETIME = 1;
	private const float TIMEBETWEENFUNCTIONCALL = 0.05f;

	void Start(){
		blockSpeed = 3f;
	}

	void Update () { 
		transform.Translate (new Vector3(0, -1, 0) * blockSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		float speedCallFunction = TIMEBETWEENFUNCTIONCALL;

		if(other.CompareTag("SnakeHead")){
			// for first challenge
			if(number == 1 || number == 2){
				challenge1Counter++;
			}
			// for 10th challenge
			if(number >= 20){
				challenge10Counter++;
			}
			// for 17th challenge
			if(number >= 40){
				challenge17Counter++;
			}

			if(number > 0 && number <= 5){
				Destroy (Instantiate(blockParticles[0].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number > 5 && number <= 15){
				Destroy (Instantiate(blockParticles[1].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number > 15 && number <= 25){
				Destroy (Instantiate(blockParticles[2].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number > 25 && number <= 35){
				Destroy (Instantiate(blockParticles[3].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number > 35 && number <= 45){
				Destroy (Instantiate(blockParticles[4].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number > 45){
				Destroy (Instantiate(blockParticles[5].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}

			while(number != 0){
				other.GetComponent<PlayerController> ().Invoke ("SubtractTail", speedCallFunction);
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
