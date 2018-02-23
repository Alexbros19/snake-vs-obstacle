using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClearBackgroundImage2 : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData){
		//AdManager.Instance.ShowInterstitial ();
		ReviveButton.isReviveButtonPressed = false;
		SceneManager.LoadScene ("Menu");
	}
}
