using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class ReviveButton : MonoBehaviour {
	public GameObject reviveButton;
	public GameObject playerSnakePrefab;
	public GameObject tailsCurrentCount;
	public GameObject gameOverImage;
	public GameObject gameOverTapToContinueImage;
	public GameObject tapToContinue;
	public GameObject gameScoreLabel;
	public static bool isReviveButtonPressed;

	void Start(){
		Advertisement.Initialize ("1620012");
		isReviveButtonPressed = false;
	}

	public void StartRevive(){
		ShowOptions so = new ShowOptions ();
		so.resultCallback = Revive;
		if(Advertisement.IsReady()){
			Advertisement.Show ("rewardedVideo", so);
		}
	}

	/*public void OnPointerClick(PointerEventData eventData){
		ShowOptions so = new ShowOptions ();
		so.resultCallback = Revive;
		if(Advertisement.IsReady()){
			Advertisement.Show ("rewardedVideo", so);
		}
	}*/

	private void Revive(ShowResult showResult){
		if (showResult == ShowResult.Finished) {
			isReviveButtonPressed = true;
			PlayerController.isRevive = true;
			tailsCurrentCount.SetActive (true);
			reviveButton.SetActive (false);
			playerSnakePrefab.SetActive (true);
			gameOverImage.SetActive (false);
			gameOverTapToContinueImage.SetActive (false);
			gameScoreLabel.SetActive (true);
			tapToContinue.SetActive (false);

			Block.blockSpeed = PlayerPrefs.GetFloat ("lineblockspeed");
			LineBlock.lineBlockSpeed = PlayerPrefs.GetFloat ("blockspeed");
			Food.foodSpeed = PlayerPrefs.GetFloat ("foodspeed");
			LineObjectsSpawner.delaySpawnTime = PlayerPrefs.GetFloat ("delayspawntime");

			LineObjectsSpawner.isGameOver = false;
			PlayerController.isPlayerDeath = false;
		} else {
			gameOverImage.SetActive (true);
			tailsCurrentCount.SetActive (false);
			gameOverTapToContinueImage.SetActive (true);
			tapToContinue.SetActive (true);
			gameScoreLabel.SetActive (false);
			reviveButton.SetActive (false);

			Block.blockSpeed = 0f;
			Food.foodSpeed = 0f;
			LineBlock.lineBlockSpeed = 0f;

			LineObjectsSpawner.isGameOver = true;
			PlayerController.isPlayerDeath = true;
		}
	}
}
