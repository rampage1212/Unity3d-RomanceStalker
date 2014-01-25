using UnityEngine;
using System.Collections;

public class UpdateScore : MonoBehaviour 
{
	HUDController hud;

	void Awake()
	{
		hud = transform.parent.GetComponent<HUDController> ();
	}

	void FixedUpdate()
	{
		guiText.text = "Score : " + hud.getScore ();
	}
}
