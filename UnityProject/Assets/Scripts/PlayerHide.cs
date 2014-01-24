using UnityEngine;
using System.Collections;

public class PlayerHide : MonoBehaviour 
{
	PlayerVisibility visibility;
	PlatformerCharacter2D character;
	SpriteRenderer spriteRenderer;
	bool hidingInto;

	void Start()
	{
		visibility = GetComponent<PlayerVisibility> ();
		character = GetComponent<PlatformerCharacter2D>();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "HideInThe")
			visibility.visible = false;
		else if (other.gameObject.tag == "HideInto")
		{
			if (hidingInto && character.grounded)
				spriteRenderer.enabled = false;
			else
				spriteRenderer.enabled = true;
		}
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
				yTarget = 0.8f;
				visibility.visible = false;
				rigidbody2D.Sleep();
			}
			else
			{
				visibility.visible = true;
				rigidbody2D.WakeUp();
			}
			transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yTarget, 2 * Time.deltaTime), transform.position.z);
		}
		else if (other.gameObject.tag == "HideInto")
		{
			if (Input.GetKey(KeyCode.Space))
			{
				character.Move(0f, false, true);
				hidingInto = true;
			}
			else if (Input.anyKey)
			{	
				character.Move(0f, false, true);
				hidingInto = false;
			}
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
