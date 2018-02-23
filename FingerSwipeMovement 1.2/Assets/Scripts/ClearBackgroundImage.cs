using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClearBackgroundImage : MonoBehaviour, IPointerClickHandler {
	public static int gamesCounter = 0;
	public int number = 0;

	public void OnPointerClick(PointerEventData eventData){
        // if number 1 load main scene else take challenge
		if (number == 1) {
			gamesCounter++;
			PlayerPrefs.SetInt ("gamescounter", gamesCounter);
			PlayerPrefs.SetInt ("challengestartbutton", 0);
			SceneManager.LoadScene ("MainScene");
		} else {
			SceneManager.LoadScene ("TakeChallenge");
		}
	}
}
