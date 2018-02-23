using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckChallenge : MonoBehaviour {
	public GameObject tapToContinueLabel;
	public GameObject tapToContinueImage;
	public GameObject challengeCompleted;
	public ParticleSystem fireworksPS;
	public static bool isChallengeCompleted;

	private int challengeNumber;
	private int challengeStartButtonNumber;
	private string challengeStartButtonKey = "challengestartbutton";

	void Start(){
		isChallengeCompleted = false;
		challengeStartButtonNumber = PlayerPrefs.GetInt (challengeStartButtonKey);
		//Debug.Log (PlayerPrefs.GetInt ("gamescounter", ClearBackgroundImage.gamesCounter));

		Block.challenge1Counter = 0;
		Block.challenge10Counter = 0;
		Block.challenge17Counter = 0;
		LineBlock.challenge6Counter = 0;
		LineBlock.challenge12Counter = 0;
		Food.challenge8Counter = 0;
		//PlayerPrefs.DeleteAll ();
	}

	void Update(){
		Challenge ();
	}

	private void WhenChallengeCompleted(){
		if(!isChallengeCompleted){
			Instantiate (fireworksPS.gameObject, transform.position, fireworksPS.transform.rotation);
		}

		tapToContinueImage.SetActive (true);
		tapToContinueLabel.SetActive (true);
		challengeCompleted.SetActive (true);

		Block.blockSpeed = 0f;
		Food.foodSpeed = 0f;
		LineBlock.lineBlockSpeed = 0f;

		LineObjectsSpawner.isGameOver = true;
		isChallengeCompleted = true;
	}

	private void Challenge(){
		// first challenge: break 5 blocks of 1 or 2
		if(challengeStartButtonNumber == 1 && Block.challenge1Counter >= 5){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber1", 1);
		}
		// second challenge: get a snake of 50 balls
		if (challengeStartButtonNumber == 2 && PlayerController.tailsCount >= 50) {
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber2", 2);
		}
		// third challenge: score 100 points
		if(challengeStartButtonNumber == 3 && PlayerController.score >= 100){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber3", 3);
		}
		// 4th challenge: score 20 points in snake skins menu
		if(challengeStartButtonNumber == 4 && PlayerPrefs.GetInt ("gamescounter", ClearBackgroundImage.gamesCounter) >= 20){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber4", 4);
		}
		// 5th challenge: survive 120 seconds at start of game
		if(challengeStartButtonNumber == 5 && PlayerController.timerForChallenge5 >= 120){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber5", 5);
		}
		// 6th challenge: get a 10 balls using green line
		if(challengeStartButtonNumber == 6 && LineBlock.challenge6Counter >= 10){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber6", 6);
		}
		// 7th challenge: survive 60 sec with no take food
		if(challengeStartButtonNumber == 7 && PlayerController.timerForChallenge5 >= 60 && !Food.isTakeFood){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber7", 7);
		}
		// 8th challenge: score 10 foods with value 5
		if(challengeStartButtonNumber == 8 && Food.challenge8Counter >= 10){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber8", 8);
		}
		// 9th challenge: score 300 points
		if(challengeStartButtonNumber == 9 && PlayerController.score >= 300){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber9", 9);
		}
		// 10th challenge: break 5 blocks of 20 or more 
		if(challengeStartButtonNumber == 10 && Block.challenge10Counter >= 5){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber10", 10);
		}
		// 11th challenge: die in less than 00:15 with 100 points *
		if(challengeStartButtonNumber == 11 && PlayerController.score >= 100 && PlayerController.timerForChallenge11 <= 15 && PlayerController.isPlayerDeath){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber11", 11);
		}
		// 12th challenge: score 10 points using red line *
		if(challengeStartButtonNumber == 12 && LineBlock.challenge12Counter >= 10){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber12", 12);
		}
		// 13th challenge: get a snake of 75 balls
		if(challengeStartButtonNumber == 13 && PlayerController.tailsCount >= 75){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber13", 13);
		}
		// 14th challenge: score 40 points in snake skins menu *
		if(challengeStartButtonNumber == 14 && PlayerPrefs.GetInt ("gamescounter", ClearBackgroundImage.gamesCounter) >= 40){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber14", 14);
		}
		// 15th challenge: survive 240 seconds at start of game *
		if(challengeStartButtonNumber == 15 && PlayerController.timerForChallenge5 >= 240){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber15", 15);
		}
		// 16th challenge: die in less than 00:15 with 200 points *
		if(challengeStartButtonNumber == 16 && PlayerController.score >= 200 && PlayerController.timerForChallenge16 <= 15 && PlayerController.isPlayerDeath){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber16", 16);
		}
		// 17th challenge: break 5 blocks of 40 or more 
		if(challengeStartButtonNumber == 17 && Block.challenge17Counter >= 5){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber17", 17);
		}
		// 18th challenge: score 500 points
		if(challengeStartButtonNumber == 18 && PlayerController.score >= 500){
			WhenChallengeCompleted ();
			PlayerPrefs.SetInt ("challengenumber18", 18);
		}
	}
}
