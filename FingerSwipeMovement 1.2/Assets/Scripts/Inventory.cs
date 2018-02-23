using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private List<PlayerItem> playerInventory;
	[SerializeField]
	private GameObject buttonTemplate;
	[SerializeField]
	private GridLayoutGroup gridGroup;
	[SerializeField]
	private Sprite[] iconSprites;

	void Start () {
		playerInventory = new List<PlayerItem> ();

		for(int i = 0; i < 5; i++){
			PlayerItem newItem = new PlayerItem ();
			newItem.iconSprite = iconSprites [i];
			playerInventory.Add (newItem);
		}

		GenerateInventory ();
	}
	
	private void GenerateInventory(){
		if (playerInventory.Count < 4) {
			gridGroup.constraintCount = playerInventory.Count;
		} else {
			gridGroup.constraintCount = 3;
		}

		foreach(PlayerItem newItem in playerInventory){
			GameObject newButton = Instantiate (buttonTemplate) as GameObject;
			newButton.SetActive (true);
			//newButton.GetComponent<InventoryButton> ().SetIcon (newItem.iconSprite);
			newButton.transform.SetParent (buttonTemplate.transform.parent, false);
		}
	}

	public class PlayerItem{
		public Sprite iconSprite;
	}
}
