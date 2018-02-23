using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeButtonNumber : MonoBehaviour {
	public int buttonNumber = 0;
	public static int prizeButtonNumber = 0;

	void Start () {
		prizeButtonNumber = buttonNumber;
	}
}
