using UnityEngine;
using System.Collections;

public class HideInCrowd : MonoBehaviour 
{
	PlayerVisibility visibility;

	void OnCollisionEnter2D()
	{
		visibility = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerVisibility> ();
	}

	void OnCollisionStay2D()
	{
		visibility.visible = false;
	}

	void OnCollisionExit2D()
	{
		visibility.visible = true;
	}
}
