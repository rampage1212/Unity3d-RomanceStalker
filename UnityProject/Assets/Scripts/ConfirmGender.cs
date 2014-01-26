using UnityEngine;
using System.Collections;

public class ConfirmGender : MonoBehaviour {

//	GenderProfile genderProfile;
	public GUITexture genderFemale;
	public GUITexture genderMale;
	public GUITexture back;
	public GUITexture clickToPlay;
	public GUITexture selectYourGender;
	public GUIText description;




	// Use this for initialization
	void OnMouseDown () {
		audio.Play ();
		if (gameObject.tag == "Male") {
			description.text = "This is how we think about the girls";
		} else if (gameObject.tag == "Female") {
			description.text = "This is how the boys think about you";
		}
		SetPageOne (false);
		SetPageTwo (true);
	}

	void SetPageOne (bool value) {
		selectYourGender.enabled = value;
		genderFemale.enabled = value;
		genderMale.enabled = value;
		back.enabled = value;
	}

	void SetPageTwo (bool value) {
		clickToPlay.enabled = value;
		description.enabled = value;
	}
}
