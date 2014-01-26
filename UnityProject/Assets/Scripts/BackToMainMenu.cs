using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown () {
		audio.Play ();
		Application.LoadLevel (0);
	}
}
