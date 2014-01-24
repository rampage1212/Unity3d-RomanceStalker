using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class TargetAI : MonoBehaviour 
{
	private PlatformerCharacter2D character;
	
	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

	void FixedUpdate()
	{
		float h = 1;		
		// Pass all parameters to the character control script.
		character.Move( h, false , false );
	}
}
