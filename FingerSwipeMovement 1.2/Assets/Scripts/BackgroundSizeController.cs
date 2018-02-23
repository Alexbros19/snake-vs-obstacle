using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSizeController : MonoBehaviour {

	void Start () {
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;
		RectTransform backgroundRect = gameObject.GetComponent<RectTransform>();

		float rectWidth = backgroundRect.rect.width;
		float rectHeight = backgroundRect.rect.height;

		rectWidth = screenWidth;
		rectHeight = screenHeight;
	}
}
