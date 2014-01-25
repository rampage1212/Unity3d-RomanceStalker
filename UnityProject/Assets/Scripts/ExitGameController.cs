using UnityEngine;
using System.Collections;

public class ExitGameController : MonoBehaviour {

	//int count;

	void OnMouseDown () {
		StartCoroutine (ExitGame ());
	}

	IEnumerator ExitGame () {
		audio.Play ();
		yield return new WaitForSeconds(3);
		Application.Quit ();
	}
}
