using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour {
	public float tailSpeed;
	public Vector3 tailTarget;
	public GameObject tailTargetObject;
	public Sprite[] snakeSkinImages = new Sprite[5];

	private PlayerController player;

	void Start () {
		ChangeTileSpriteImage ();

		player = GameObject.FindGameObjectWithTag ("SnakeHead").GetComponent<PlayerController> ();
		tailTargetObject = player.tailObjects[player.tailObjects.Count - 2];
		tailSpeed = player.playerSpeed;
	}

	void Update () {
		if(tailTargetObject != null){
			tailTarget = tailTargetObject.transform.position;
			tailTarget.y -= player.y_offset;
			transform.LookAt (tailTarget);
			transform.position = Vector3.Lerp (transform.position, tailTarget, Time.deltaTime * tailSpeed);
			transform.rotation = Quaternion.identity;
		}
	}

	void ChangeTileSpriteImage(){
		SpriteRenderer tileImage = this.gameObject.GetComponent<SpriteRenderer> ();

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int number = PlayerPrefs.GetInt ("PressedButtonNumber");

			tileImage.sprite = snakeSkinImages [number - 1];
		}
	}
}
