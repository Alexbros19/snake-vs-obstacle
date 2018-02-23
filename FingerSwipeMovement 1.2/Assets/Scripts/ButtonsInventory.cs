using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInventory : MonoBehaviour {

	public GameObject[] buttons;
	[SerializeField]
	private GridLayoutGroup gridGroup;

	void Start () {
		gridGroup.constraintCount = 3;

		for(int i = 0; i < 5; i++){
			GameObject newButton = Instantiate (buttons[i]) as GameObject;
			buttons[i].SetActive (true);
			newButton.transform.SetParent (buttons[i].transform.parent, false);
		}
	}
}
