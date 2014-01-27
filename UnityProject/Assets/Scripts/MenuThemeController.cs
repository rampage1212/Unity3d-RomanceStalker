using UnityEngine;
using System.Collections;

public class MenuThemeController : MonoBehaviour {

	void FixedUpdate () {
		if (Application.loadedLevel == 2) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject.audio);
	}
}
