using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBlock : MonoBehaviour {

	public ParticleSystem[] lineParticles;
	public int number = 0;
	public static int challenge6Counter = 0;
	public static int challenge12Counter = 0;
	public static float lineBlockSpeed = 0;
	private const int PARTICLELIFETIME = 1;

	void Start(){
		lineBlockSpeed = 3f;
	}

	void Update () {
		transform.Translate (new Vector3(0, -1, 0) * lineBlockSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SnakeHead")){
			if(number == 1){
				challenge6Counter++;
				other.GetComponent<PlayerController> ().AddTail();
				Destroy (Instantiate(lineParticles[0].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}else if(number == 2){
				challenge12Counter++;
				other.GetComponent<PlayerController> ().SubtractTail();
				Destroy (Instantiate(lineParticles[1].gameObject, transform.position, Quaternion.identity) as GameObject, PARTICLELIFETIME);
			}
		}

		if(other.CompareTag("LimitCollider")){
			Destroy (gameObject);
		}
	}
}
