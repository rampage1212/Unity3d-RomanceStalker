using UnityEngine;
using System.Collections;

enum stalkedState{
	NORMAL,
	KAGET,
	CURIGA,
	POST_BALIK
};

[RequireComponent(typeof(PlatformerCharacter2D))]
public class TargetAI : MonoBehaviour 
{
	public float awarenesDistance = 10f;
	private GameObject player;
	private PlatformerCharacter2D character;
	private PlayerVisibility visibility;
	public float awarenesTimer;
	public bool aware;

	bool turnBack;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		visibility = player.GetComponent<PlayerVisibility> ();
		character = GetComponent<PlatformerCharacter2D>();
	}

	void turnBackFunc()
	{
		character.Move (-1f, false, false);
		character.Move (0f, false, false);
		turnBack = true;
	}

	void FixedUpdate()
	{
		float distance = Vector3.Distance (transform.position, player.transform.position);

		float h = 1f;

		if (turnBack && !aware)
		{
			awarenesTimer += Time.deltaTime;

			if (visibility.visible && awarenesTimer > 1f)
			{
				Debug.Break();
				return;
			}
			else if (awarenesTimer > 7f)
			{
				aware = false;
			}
		}
		else if (distance < awarenesDistance)
		{
			h = 0f;
			aware = true;

			if (!turnBack) 
			{
				Invoke("turnBackFunc", 2f);
			}
		}
		else
		{
			turnBack = false;
		}

		// Pass all parameters to the character control script.
		if (!turnBack && !aware) character.Move( h, false , false );
	}
}
