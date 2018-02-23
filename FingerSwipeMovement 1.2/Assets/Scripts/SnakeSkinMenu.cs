using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeSkinMenu : MonoBehaviour {
	public Text gamesStartCount;
	public Image currentSnakeImage;
	public Sprite[] snakeSkinImages = new Sprite[18];

	void Start(){
		ChangeSnakeSkinImage ();
	}

	void Update () {
		gamesStartCount.text = PlayerPrefs.GetInt ("gamescounter", ClearBackgroundImage.gamesCounter).ToString();
	}

	public void BackToMenu(){
		SceneManager.LoadScene ("Menu");
	}

	void ChangeSnakeSkinImage(){
		Image snakeImage = currentSnakeImage.GetComponent<Image> ();

		if (PlayerPrefs.HasKey ("PressedButtonNumber")) {
			int number = PlayerPrefs.GetInt ("PressedButtonNumber");

			snakeImage.sprite = snakeSkinImages [number - 1];
		}
	}
}
