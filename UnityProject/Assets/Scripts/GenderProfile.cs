using UnityEngine;
using System.Collections;

public class GenderProfile : MonoBehaviour {

	public GUITexture genderFemale;
	public GUITexture genderMale;
	public GUITexture back;
	public GUITexture clickToPlay;
	public GUITexture selectYourGender;
	public GUIText description;

	void Start () {
		SetPageOne (true);
		SetPageTwo (false);
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
