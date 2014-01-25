using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	
	public float fadeSpeed = 1.5f;        // Speed that the screen fades to and from black.

	public bool fading = true;		      // Whether or not the scene is still fading in.
	Color fadeColor;

	void Update()
	{
		if (guiTexture.color != fadeColor)
		{
			fading = true;
			guiTexture.color = Color.Lerp(guiTexture.color, fadeColor, fadeSpeed * Time.deltaTime);
		}
		else
		{
			fading = false;
		}
	}

	public void FadeToClear ()
	{
		fadeColor = Color.clear;
	}

	public void FadeToWhite ()
	{
		fadeColor = Color.white;
	}
	
	public void FadeToBlack ()
	{
		fadeColor = Color.black;
	}
}
