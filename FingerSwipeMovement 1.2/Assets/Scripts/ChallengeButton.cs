using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeButton : MonoBehaviour {
	public Sprite[] challengeCompletedSprites = new Sprite[18];
	public Sprite[] prizeButtonSprites = new Sprite[2];
	public int buttonNumber = 0;
	public static int buttonNumberValue = 0;
	public static int countButton = 18;
	public GameObject[] onButtonChallengeClick = new GameObject[18];

	private string keyNumberButton = "challengenumber";
	private bool isPrizeButtonPressed = false;
	//private bool isChallengeCompleted = true;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		int valueButton = 0;

		buttonNumberValue = buttonNumber;

		for(int i = 1; i <= countButton; i++){	
			if(PlayerPrefs.HasKey(keyNumberButton + i.ToString())) 
			{
				valueButton = PlayerPrefs.GetInt(keyNumberButton + i.ToString()); 
				SetSpriteImage(i,valueButton);

				//if(isChallengeCompleted){
				//	SetPrizeImage (i, 1);
				//	isChallengeCompleted = false;
				//}
			}
		}
	}

	void SetSpriteImage(int numberButton, int valueButton) 
	{
		Image buttonImage;
		buttonImage = GameObject.FindGameObjectWithTag("ChallengeButton" + numberButton.ToString()).GetComponent<Image>();
		buttonImage.sprite = challengeCompletedSprites [valueButton - 1];
	}

	void SetPrizeImage(int numberButton, int valueButton){
		Image buttonImage;
		buttonImage = GameObject.FindGameObjectWithTag("PrizeButton" + numberButton.ToString()).GetComponent<Image>();
		buttonImage.sprite = prizeButtonSprites [valueButton - 1];
	}

	private void ResetPrizeButton(){
		if(PlayerPrefs.HasKey("prizebutton" + buttonNumber.ToString())){
			if(PlayerPrefs.GetInt("prizebutton" + buttonNumber.ToString()) == 0){
				SetPrizeImage (buttonNumber, 1);
				isPrizeButtonPressed = true;
			}else if(PlayerPrefs.GetInt("prizebutton" + buttonNumber.ToString()) == 1){
				SetPrizeImage (buttonNumber, 2);
				isPrizeButtonPressed = false;
			}
		}
	}

	public void OnButtonChallengeClick(){
		onButtonChallengeClick [buttonNumber - 1].SetActive (true);

		if (PlayerPrefs.HasKey ("prizebutton" + buttonNumber.ToString ()))
			ResetPrizeButton ();
	}

	public void CancelButton(){
		SceneManager.LoadScene ("TakeChallenge");
	}

	public void StartButton(){
		PlayerPrefs.SetInt ("challengestartbutton", ChallengeStartButton.startButtonNumber);

		ClearBackgroundImage.gamesCounter++;
		PlayerPrefs.SetInt ("gamescounter", ClearBackgroundImage.gamesCounter);
		SceneManager.LoadScene ("MainScene");
	}

	public void BackButton(){
		SceneManager.LoadScene ("Menu");
	}

	public void PrizeButton(){
		if(PlayerPrefs.HasKey(keyNumberButton + PrizeButtonNumber.prizeButtonNumber.ToString())) 
		{
			if(!isPrizeButtonPressed){
				SetPrizeImage (PrizeButtonNumber.prizeButtonNumber, 1);
				isPrizeButtonPressed = true;
				PlayerPrefs.SetInt ("prizebutton" + PrizeButtonNumber.prizeButtonNumber.ToString(), 0);
			}else if(isPrizeButtonPressed){
				SetPrizeImage (PrizeButtonNumber.prizeButtonNumber, 2);
				isPrizeButtonPressed = false;
				PlayerPrefs.SetInt ("prizebutton" + PrizeButtonNumber.prizeButtonNumber.ToString(), 1);
			}
		}
	}
}
