using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	Fader fader;

	void Awake()
	{
		fader = GetComponent<Fader> ();
	}

	void Start()
	{
		StartGame ();
	}

	void Update()
	{
		if (fader.fading)
			guiTexture.enabled = true;
	}

	public void StartGame()
	{
		fader.FadeToClear ();
	}

	public void EndGame()
	{
		fader.FadeToBlack ();
	}
}
