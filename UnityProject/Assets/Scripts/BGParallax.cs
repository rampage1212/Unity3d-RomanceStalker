using UnityEngine;
using System.Collections;

public class BGParallax : MonoBehaviour {

	public Camera camera;
	Vector3 initPosition;
	Vector3 couplePosition;
	public GameObject couple;
	public GameObject kanan;
	public GameObject kiri;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").camera;
		initPosition = transform.position;
	

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentPosBasedOnCamera = camera.WorldToViewportPoint (transform.position);

		Vector3 currentPosBasedOnWorld = camera.ViewportToWorldPoint (currentPosBasedOnCamera);

		Vector3 mostLeftWorld = camera.ViewportToWorldPoint (new Vector3 (0, 0, 0));

		if (transform.position.x + (kanan.transform.position.x - kiri.transform.position.x)  < mostLeftWorld.x +10 ) {

			Vector3 targetPosBasedOnCamera = currentPosBasedOnCamera;
			targetPosBasedOnCamera.x = 1;
			targetPosBasedOnCamera.y = 0;


			Vector3 targetPosBasedOnWorld = camera.ViewportToWorldPoint(targetPosBasedOnCamera);
//			targetPosBasedOnWorld.x += renderer.bounds.size.x/2;
			targetPosBasedOnWorld.x = couple.transform.Find("kanan").position.x + (transform.position.x - kiri.transform.position.x) ;
			targetPosBasedOnWorld.y = transform.position.y;
			targetPosBasedOnWorld.z = 0;

			transform.position = targetPosBasedOnWorld;
		}


	}
}
