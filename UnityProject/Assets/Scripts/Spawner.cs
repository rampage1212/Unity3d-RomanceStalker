using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject ground;

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ground")
			Instantiate(ground, new Vector3(transform.position.x, other.transform.position.y, transform.position.z), Quaternion.identity);
	}
}
