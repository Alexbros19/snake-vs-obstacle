﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TakeChallenge : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData){
		SceneManager.LoadScene ("TakeChallenge");
	}
}
