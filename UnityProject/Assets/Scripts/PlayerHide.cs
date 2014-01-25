using UnityEngine;
using System.Collections;

public class PlayerHide : MonoBehaviour 
{
	PlayerVisibility visibility;
	PlatformerCharacter2D character;
	SpriteRenderer spriteRenderer;
	bool hidingInto;
	
	int SFXplayCount;
	bool hiding;

	public AudioClip hideClip;
	public AudioClip unHideClip;

	void Start()
	{
		visibility = GetComponent<PlayerVisibility> ();
		character = GetComponent<PlatformerCharacter2D>();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "HideInThe")
			hide (true);
		else if (other.gameObject.tag == "HideInto")
		{
			if (hidingInto && character.grounded)
			{
				spriteRenderer.enabled = false;
				hide (true);
			}
			else
			{
				spriteRenderer.enabled = true;
				hide (false);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "HideBefore")
		{
			if (Input.GetKey(KeyCode.LeftControl))
				hide (true);
			else
				hide (false);
		}
		else if (other.gameObject.tag == "HideBetween")
		{
			float yTarget = 0f; 
			if (Input.GetKey(KeyCode.Space))
			{
				yTarget = 0.8f;
				hide (true);
				rigidbody2D.Sleep();
			}
			else
			{
				hide (false);
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
			else if (Input.anyKey && hidingInto)
			{	
				character.Move(1f, false, true);
				hidingInto = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.tag == "HideInThe")
			hide (false);
		else if (other.gameObject.tag == "HideBefore")
			hide (false);
		else if (other.gameObject.tag == "HideInto")
		{
			hide (false);
			spriteRenderer.enabled = true;
		}
	}

	void hide(bool flag)
	{
		++SFXplayCount;
		if (hiding != flag)
		{
			SFXplayCount = 0;
			hiding = flag;
		}

		visibility.visible = !flag;

		if (SFXplayCount > 0)
			return;

		if (flag)
			AudioSource.PlayClipAtPoint(hideClip, transform.position);
		else
			AudioSource.PlayClipAtPoint(unHideClip, transform.position);
	}
}
