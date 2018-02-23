using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public Text tapToStart;
	public Text highscoreLabel;
	public Image currentSnakeImage;
	public Sprite[] snakeSkinImages = new Sprite[18];

	private bool isCoroutine = true;

	void Start () {
		if (PlayerPrefs.HasKey ("Highscore")) {
			highscoreLabel.text = PlayerPrefs.GetInt ("Highscore", 0).ToString();
		}

		ChangeSnakeSkinImage ();
			
		StartCoroutine (FadeText(Color.white, new Color(1, 1, 1, 0.3f), 0.75f));
	}

	void ChangeSnakeSkinImage(){
		Image snakeImage = currentSnakeImage.GetComponent<Image> ();

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int number = PlayerPrefs.GetInt ("PressedButtonNumber");

			snakeImage.sprite = snakeSkinImages [number - 1];
		}
	}

	IEnumerator FadeText(Color from, Color to, float time){

		while(isCoroutine){
			float speed = 1 / time;
			float percent = 0;

			while (percent < 1) {
				percent += speed * Time.deltaTime;
				tapToStart.color = Color.Lerp (from, to, percent);
				yield return null;
			}
			yield return new WaitForSeconds (0.75f);
		}
	}
}
