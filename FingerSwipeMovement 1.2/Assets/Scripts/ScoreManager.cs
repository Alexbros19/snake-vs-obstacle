using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text scoreLabel;
	
	void Update () {
		scoreLabel.text = PlayerController.score.ToString ();
	}
}
