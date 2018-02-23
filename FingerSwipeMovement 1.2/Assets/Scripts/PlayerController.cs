using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public List<GameObject> tailObjects;
	public GameObject tailPrefab;
	public GameObject gameOverImage;
	public GameObject tailsCurrentCount;
	public GameObject gameOverTapToContinueImage;
	public GameObject tapToContinue;
	public GameObject gameScoreLabel;
	public GameObject reviveButton;

	public float y_offset = 0.5f;
	public float playerSpeed;
	public static int tailsCount = 0;
	public static int score = 0;
	public static float timerForChallenge5;
	public static float timerForChallenge11;
	public static float timerForChallenge16;
	public static bool isPlayerDeath;
	public Sprite[] snakeSkinImages = new Sprite[5];

	private GameObject lastListElement;
	private Transform playerTransform;
	private int desiredLane = 2; // 0 - left, 1 - middle-left, 2 - middle, 3 - middle-right, 4 - right
	private int scorePointValue = 1;
	private int speedNumber = 1;
	private float blockSpeed = 3f;
	private float lineBlockSpeed = 3f;
	private float foodSpeed = 3f;
	private float fadeBlockSpeed = 3f;
	private float delaySpawnTime = 1f;
	private bool isChallenge11Completed;
	private bool isChallenge16Completed;
	public static bool isRevive;
	private static float reviveButtonTimer;
	private const float TIMEBETWEENFUNCTIONCALL = 0.05f;

	private void Start(){
		//Debug.Log (timerForChallenge5);
		float speedCallAddTail = TIMEBETWEENFUNCTIONCALL;

		ChangePlayerSpriteImage ();

		reviveButtonTimer = 0;
		timerForChallenge5 = 0;
		InvokeRepeating ("TimerFor5Challenge", 0f, 1f);

		timerForChallenge11 = 0;
		timerForChallenge16 = 0;
		isChallenge11Completed = false;
		isChallenge16Completed = false;
		isPlayerDeath = false;
		isRevive = false;

		if(!ReviveButton.isReviveButtonPressed){
			score = 0;
		}
			
		playerSpeed = 5f;
		tailObjects = new List<GameObject>();
		playerTransform = this.transform;
		tailObjects.Add(gameObject);

		if(!ReviveButton.isReviveButtonPressed){
			for (int i = 1; i <= ChallengeButton.countButton; i++) {
				if(PlayerPrefs.HasKey("prizebutton" + i.ToString())){
					if(PlayerPrefs.GetInt("prizebutton" + i.ToString()) == 1){
						Invoke ("AddTail", speedCallAddTail);
						speedCallAddTail += TIMEBETWEENFUNCTIONCALL;
					}
				}
			}
		}
	}

	private void ReviveButtonTimer(){
		reviveButtonTimer++;
	}

	private void TimerFor11Challenge(){
		timerForChallenge11++;
	}

	private void TimerFor16Challenge(){
		timerForChallenge16++;
	}

	private void TimerFor5Challenge(){
		timerForChallenge5++;
	}

	private void LateUpdate(){
		if (score >= 10 && !isChallenge11Completed) {
			InvokeRepeating ("TimerFor11Challenge", 0f, 1f);
			isChallenge11Completed = true;
		}

		if (score >= 20 && !isChallenge16Completed) {
			InvokeRepeating ("TimerFor16Challenge", 0f, 1f);
			isChallenge16Completed = true;
		}
			
		SpeedController ();
		tailsCount = tailObjects.Count;

		// mobile controll movement
		if(MobileInput.Instance.SwipeLeft){
			MoveLane (false);
		}
		if(MobileInput.Instance.SwipeRight){
			MoveLane (true);
		}

		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 10f));
		switch(desiredLane){
		case 0:
			targetPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 10f, Screen.height / 2f, 10f)); break;
		case 1:
			targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(3f * Screen.width / 10f, Screen.height / 2f, 10f)); break;
		case 3:
			targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(7f * Screen.width / 10f, Screen.height / 2f, 10f)); break;
		case 4:
			targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(9f * Screen.width / 10f, Screen.height / 2f, 10f)); break;
		}

		Vector3 moveVector = Vector3.zero;
		moveVector.x = (targetPosition - transform.position).x * playerSpeed;
		playerTransform.Translate (moveVector * playerSpeed * Time.deltaTime);
	}

	private void SpeedController(){
		if (tailObjects.Count > 5 && speedNumber == 1) {
			lineBlockSpeed = 3.5f;
			blockSpeed = 3.5f;
			foodSpeed = 3.5f;
			fadeBlockSpeed = 3.5f;
			delaySpawnTime = .9f;
			speedNumber = 2;
		}
		if (tailObjects.Count > 15 && speedNumber == 2) {
			lineBlockSpeed = 4f;
			blockSpeed = 4f;
			foodSpeed = 4f;
			fadeBlockSpeed = 4f;
			delaySpawnTime = .8f;
			speedNumber = 3;
		}
		if (tailObjects.Count > 25 && speedNumber == 3) {
			lineBlockSpeed = 4.5f;
			blockSpeed = 4.5f;
			foodSpeed = 4.5f;
			fadeBlockSpeed = 4.5f;
			delaySpawnTime = .7f;
			speedNumber = 4;
		}
		if (tailObjects.Count > 35 && speedNumber == 4) {
			lineBlockSpeed = 5f;
			blockSpeed = 5f;
			foodSpeed = 5f;
			fadeBlockSpeed = 5f;
			delaySpawnTime = .6f;
			speedNumber = 5;
		}
		if (tailObjects.Count > 45 && speedNumber == 5) {
			lineBlockSpeed = 5.5f;
			blockSpeed = 5.5f;
			foodSpeed = 5.5f;
			fadeBlockSpeed = 5.5f;
			delaySpawnTime = .5f;
			speedNumber = 6;
		}
		if (tailObjects.Count > 55 && speedNumber == 6) {
			lineBlockSpeed = 6f;
			blockSpeed = 6f;
			foodSpeed = 6f;
			fadeBlockSpeed = 6f;
			delaySpawnTime = .5f;
			speedNumber = 7;
		}
		if (tailObjects.Count > 65 && speedNumber == 7) {
			lineBlockSpeed = 6.5f;
			blockSpeed = 6.5f;
			foodSpeed = 6.5f;
			fadeBlockSpeed = 6.5f;
			delaySpawnTime = .5f;
			speedNumber = 8;
		}
		if (tailObjects.Count > 75 && speedNumber == 8) {
			lineBlockSpeed = 7f;
			blockSpeed = 7f;
			foodSpeed = 7f;
			fadeBlockSpeed = 7f;
			delaySpawnTime = .5f;
			speedNumber = 9;
		}

		LineBlock.lineBlockSpeed = this.lineBlockSpeed;
		PlayerPrefs.SetFloat ("lineblockspeed", this.lineBlockSpeed);
		Block.blockSpeed = this.blockSpeed;
		PlayerPrefs.SetFloat ("blockspeed", this.blockSpeed);
		Food.foodSpeed = this.foodSpeed;
		PlayerPrefs.SetFloat ("foodspeed", this.foodSpeed);
		LineObjectsSpawner.delaySpawnTime = this.delaySpawnTime;
		PlayerPrefs.SetFloat ("delayspawntime", this.delaySpawnTime);
		FadeBlock.fadeBlockSpeed = this.fadeBlockSpeed;
	}

	private void MoveLane(bool goingRight){
		if (!goingRight) {
			desiredLane--;
			if (desiredLane == -1)
				desiredLane = 0;
		} else {
			desiredLane++;
			if (desiredLane == 5)
				desiredLane = 4;
		}
	}

	public void AddTail(){
		Vector3 newTailPosition = tailObjects [tailObjects.Count - 1].transform.position;
		newTailPosition.y -= y_offset;
		lastListElement = GameObject.Instantiate (tailPrefab, newTailPosition, Quaternion.identity) as GameObject;
		tailObjects.Add(lastListElement);
	}

	public void SubtractTail(){

		Destroy (tailObjects [tailObjects.Count - 1].gameObject);
		tailObjects.RemoveAt (tailObjects.Count - 1);

		if(!CheckChallenge.isChallengeCompleted){
			// if death and internet available
			if (tailObjects.Count == 0 && Application.internetReachability != NetworkReachability.NotReachable && !ReviveButton.isReviveButtonPressed) {
				
				WhenPlayerDeath ();
				reviveButton.SetActive (true);

			} else if(tailObjects.Count == 0){ // if death and no internet connection
				WhenPlayerDeath();
			}
		}
			
		score += scorePointValue;
	}

	public void WhenPlayerDeath(){
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
		isPlayerDeath = true;
	}

	void ChangePlayerSpriteImage(){
		SpriteRenderer snakeImage = this.gameObject.GetComponent<SpriteRenderer> ();

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int number = PlayerPrefs.GetInt ("PressedButtonNumber");

			snakeImage.sprite = snakeSkinImages [number - 1];
		}
	}
}
