using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	GUIText tutorialText;
	int index = 0;
	string[] text;

	void Awake()
	{
		tutorialText = transform.parent.GetComponent<GUIText> ();
	}

	void Start()
	{
		Invoke ("beginTutorial", 1f);

		text = new string[10];

		text [0] = "Once upon a time, there is a woman who unexpectedly \nmet with a handsome man and fall in love with him.";
		text [1] = "She then began to trailing and stalking the man who \nher in love with.";
		text [2] = "And this is your job to help her.";
		text [3] = "You can move by pressing left or right and shift for \nrun.";
		text [4] = "There is four hiding spot you can use for now.";
		text [5] = "First one is corwd, you'll be automatically hidden \nwhen standing near them.";
		text [6] = "Second one is the mail box, you can hide by pressing \ncrouch(ctrl on the keyboard) behind the mail box.";
		text [7] = "Third one is in the trash can, press space when you \nare near the spot, and your character will enter \nthe trash can.";
		text [8] = "Fourth one is in between the two building, hold space \nto hide in that spot.";
		text [9] = "Are you ready Stalker !!!";

		tutorialText.text = text [0];
	}

	void beginTutorial()
	{
		Time.timeScale = 0;
	}

	void OnMouseDown()
	{
		if (index == text.Length)
		{
			Time.timeScale = 1;
			Destroy(transform.parent.gameObject);
			return;
		}

		tutorialText.text = text [++index];

		if (index + 1 == text.Length)
			guiText.text = "<<Got It!!>>";
	}
}
