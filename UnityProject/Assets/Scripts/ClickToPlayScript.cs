using UnityEngine;
using System.Collections;

public class ClickToPlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		audio.Play ();
		Application.LoadLevel(2);
	}
}
