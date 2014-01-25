using UnityEngine;
using System.Collections;

public class MenuPlayController : MonoBehaviour {

	void OnMouseDown () {
		audio.Play ();
		Application.LoadLevel(2);
	}
}
