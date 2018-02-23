using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetElementsSize : MonoBehaviour {

	void Start(){
		RectTransform parentRect = gameObject.GetComponent<RectTransform>();
		GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
		gridLayout.cellSize = new Vector2(parentRect.rect.width / 3f - parentRect.rect.width / 12f, parentRect.rect.width / 3f - parentRect.rect.width / 12f);
		gridLayout.spacing = new Vector2 (parentRect.rect.width / 12f, parentRect.rect.width / 12f);
		gridLayout.padding.left = Mathf.RoundToInt(parentRect.rect.width / 24f);
	}
}