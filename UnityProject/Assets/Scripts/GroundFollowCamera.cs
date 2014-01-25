using UnityEngine;
using System.Collections;

public class GroundFollowCamera : MonoBehaviour {

	public Camera camera;

	float initXDistance;
	Vector3 initPosition;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").camera;

		initPosition = transform.position;
		initXDistance = camera.transform.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = initPosition;
		targetPosition.x = camera.transform.position.x - initXDistance;

		transform.position = targetPosition;
	}
}
