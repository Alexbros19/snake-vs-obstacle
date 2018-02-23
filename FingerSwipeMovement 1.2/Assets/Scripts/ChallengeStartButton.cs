using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeStartButton : MonoBehaviour {

	public int buttonNumber = 0;
	public static int startButtonNumber;

	void Start(){
		startButtonNumber = buttonNumber;
	}
}
