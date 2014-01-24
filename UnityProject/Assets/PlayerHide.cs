using UnityEngine;
using System.Collections;

public class PlayerHide : MonoBehaviour 
{
	PlayerVisibility visibility;

	void Start()
	{
		visibility = GetComponent<PlayerVisibility> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "HideInThe")
			visibility.visible = false;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "HideBefore")
		{
			if (Input.GetKey(KeyCode.LeftControl))
				visibility.visible = false;
		}
		else if (other.gameObject.tag == "HideBetween")
		{
			float yTarget = 0f; 
			if (Input.GetKey(KeyCode.Space))
			{
				yTarget = 1f;
				visibility.visible = false;
			}
			else
			{
				visibility.visible = true;
			}
			transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yTarget, 2 * Time.deltaTime), transform.position.z);
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "HideInThe")
			visibility.visible = true;
		else if (other.gameObject.tag == "HideBefore")
			visibility.visible = true;
	}
}
