using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
	public Text tapToCountinue;
	public Text scoreGameOverLabel;
	public Text highscoreLabel;

	private bool isCoroutine = true;
	private int highscore = 0;

	void Start () {
		StartCoroutine (FadeText(Color.white, new Color(1, 1, 1, 0.3f), 0.75f));
	}

	void Update(){
		highscore = PlayerController.score;
		scoreGameOverLabel.text = PlayerController.score.ToString ();

		if(highscore > PlayerPrefs.GetInt("Highscore", 0)){
			PlayerPrefs.SetInt("Highscore", highscore);
			highscoreLabel.text = PlayerPrefs.GetInt ("Highscore", 0).ToString();
		}

		if (PlayerPrefs.HasKey ("Highscore")) {
			highscoreLabel.text = PlayerPrefs.GetInt ("Highscore", 0).ToString();
		}
	}
	
	IEnumerator FadeText(Color from, Color to, float time){

		while(isCoroutine){
			float speed = 1 / time;
			float percent = 0;

			while (percent < 1) {
				percent += speed * Time.deltaTime;
				tapToCountinue.color = Color.Lerp (from, to, percent);
				yield return null;
			}
			yield return new WaitForSeconds (0.75f);
		}
	}
}
