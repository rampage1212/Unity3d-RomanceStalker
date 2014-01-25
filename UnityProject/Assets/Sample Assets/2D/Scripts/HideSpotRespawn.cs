using UnityEngine;
using System.Collections;

public class HideSpotRespawn : MonoBehaviour {

	Camera camera;
	Vector3 initPosition;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").camera;
		initPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosBasedOnCamera = camera.WorldToViewportPoint (transform.position);

	
		if (currentPosBasedOnCamera.x < 0) {

			Vector3 targetPosBasedOnCamera = currentPosBasedOnCamera;
			targetPosBasedOnCamera.x = 1 + (float)(Random.Range(0,200)/100);
			targetPosBasedOnCamera.y = 0;


			Vector3 targetPosBasedOnWorld = camera.ViewportToWorldPoint(targetPosBasedOnCamera);
			targetPosBasedOnWorld.y = transform.position.y;
			targetPosBasedOnWorld.z = 0;

			Debug.Log (targetPosBasedOnWorld.x);

			transform.position = targetPosBasedOnWorld;
		}
	}
}