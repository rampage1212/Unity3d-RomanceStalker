using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	public Fader screenFader;
	public TargetAI target;
	bool isGameOver;
	float score;
	public AudioClip gameOverClip;

	void Start()
	{
		guiTexture.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		screenFader.FadeToClear ();
	}

	void Update()
	{
		score += Time.deltaTime;

		if (screenFader.fading)
			guiTexture.enabled = true;

		if (target.status == stalkedState.NORMAL)
			audio.pitch = Mathf.Lerp(audio.pitch, 1f, Time.deltaTime);
		else
			audio.pitch = Mathf.Lerp(audio.pitch, 1.5f, Time.deltaTime);

		if (isGameOver && !screenFader.fading)
			if (Input.anyKeyDown)
				Application.LoadLevel(0);
	}

	public void GameOver(int index)
	{
		if (isGameOver)
			return;

		AudioSource.PlayClipAtPoint (gameOverClip, transform.position);
		transform.GetChild (index).guiTexture.enabled = true;

		// if to left behind, display the sqript message
		transform.GetChild(2).guiText.enabled = true;

		string gameOverText;
		int totalScore = (int)(score * 10);
		if (totalScore > 8000)
			gameOverText = "~ Stalking like a Boss ~";
		else if (totalScore > 4000)
			gameOverText = "~ Not Bad ~";
		else if (totalScore > 2000)
			gameOverText = "~ At least i'm not a loser ~";
		else if (totalScore > 1000)
			gameOverText = "~ Okay ~";
		else
			gameOverText = "~ Forever Alone ~";

		transform.GetChild (2).guiText.text = "your stalking score is " + totalScore + "\n" + gameOverText;
		screenFader.FadeToBlack ();
		isGameOver = true;
	}

	public void addScore(int value)
	{
		score += value;
	}
}
