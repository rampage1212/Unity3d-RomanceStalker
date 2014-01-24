using UnityEngine;
using System.Collections;

public class HideInCrowd : MonoBehaviour 
{
	PlayerVisibility visibility;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Player")
			visibility = coll.gameObject.GetComponent<PlayerVisibility> ();
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (visibility)
			visibility.visible = false;
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (visibility)
			visibility.visible = true;
	}
}
