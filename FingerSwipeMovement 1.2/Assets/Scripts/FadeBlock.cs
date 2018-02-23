using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlock : MonoBehaviour {
	public static float fadeBlockSpeed = 0;

	void Start () {
		fadeBlockSpeed = 3f;
	}
	
	void Update () {
		transform.Translate (new Vector3(0, -1, 0) * fadeBlockSpeed * Time.deltaTime);
	}
}
