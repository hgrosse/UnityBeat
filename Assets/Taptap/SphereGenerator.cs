using UnityEngine;
using System.Collections;

public class SphereGenerator : MonoBehaviour {

	public GameObject spherePrefab;
	public float speed = 0.1f;

	private GameObject currentSphere;

	void Start () {
		Vector3 initialPos = new Vector3 (transform.position.x, 
			transform.position.y -3, transform.position.z);
		currentSphere = GameObject.Instantiate (spherePrefab);
		currentSphere.transform.Translate (initialPos);
	}
	
	void Update () {
		currentSphere.transform.Translate (0f, 0f, -speed);
	}
}
