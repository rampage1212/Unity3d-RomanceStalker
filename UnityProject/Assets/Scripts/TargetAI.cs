using UnityEngine;
using System.Collections;

public enum stalkedState{
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
	public HUDController hud;

	public float JARAK_MAKSIMAL = 10f;
	public static float JARAK_KETAHUAN = 3f;
	public static float INTERVAL_CURIGA = 2f;
	public static float INTERVAL_KAGET = 2f;
	
	public float tick; //time
	
	public float intervalCuriga;
	public float intervalKaget;
	
	public stalkedState status;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		visibility = player.GetComponent<PlayerVisibility> ();
		character = GetComponent<PlatformerCharacter2D>();
		
		status = stalkedState.NORMAL;
	}

	void FixedUpdate()
	{
		
		
		float distance = Vector3.Distance (transform.position, player.transform.position);
//		Debug.Log (status + "jarak:" + distance);	
		
		float h = 3f;

		if (distance > JARAK_MAKSIMAL)
			hud.GameOver(1);

		switch (status)
		{
		case stalkedState.NORMAL:
			
			//jarak cowok dengan cewek dekat banget
			if (distance <= JARAK_KETAHUAN && visibility.visible) {
				
				//waktu kaget
				intervalKaget = INTERVAL_KAGET;
				
				status = stalkedState.KAGET;
				
				
			}else{
				character.Move( h, false , false );
			}
			break;
			
		case stalkedState.KAGET:
			
			//waktu untuk kaget
			if (intervalKaget >= 0) {
				
				intervalKaget -= Time.deltaTime;
				
				//karakter balik badan
				//					Invoke("turnBackFunc", INTERVAL_KAGET);
				character.Move(-1, false, false);
				character.Move (0, false, false);
				
			}else{
				
				//nggak jadi curiga
				if (distance > JARAK_KETAHUAN) {
					
					status = stalkedState.NORMAL;
					
				}else{
					intervalCuriga = INTERVAL_CURIGA;
					status = stalkedState.CURIGA;
				}
				
			}
			break;
			
		case stalkedState.CURIGA:
			if (intervalCuriga >= 0) {
				intervalCuriga -= Time.deltaTime;
				
				//TODO
				//cek kalah
				if (visibility.visible) {
					hud.GameOver(0);
				}
				
			}else{
				status = stalkedState.NORMAL;
			}
			break;
			
		}
		
		//		if (turnBack && !aware)
		//		{
		//			awarenesTimer += Time.deltaTime;
		//
		//			if (visibility.visible && awarenesTimer > 1f)
		//			{
		//				Debug.Break();
		//				return;
		//			}
		//			else if (awarenesTimer > 7f)
		//			{
		//				aware = false;
		//			}
		//		}
		//		else if (distance < awarenesDistance)
		//		{
		//			h = 0f;
		//			aware = true;
		//
		//			if (!turnBack) 
		//			{
		//				Invoke("turnBackFunc", 2f);
		//			}
		//		}
		//		else
		//		{
		//			turnBack = false;
		//		}
		//
		//		// Pass all parameters to the character control script.
		//		if (!turnBack && !aware) character.Move( h, false , false );
		
		
	}
}
