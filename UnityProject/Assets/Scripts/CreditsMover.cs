using UnityEngine;
using System.Collections;

public class CreditsMover : MonoBehaviour {

	Vector3 movement = new Vector3 (-3.0f, 0.0f, 0.0f);	

	void Start () {
		rigidbody.velocity = movement * Time.deltaTime;
	}
}
