using UnityEngine;
using System.Collections;


public class TempoSphere : MonoBehaviour {

	public float speed;
	public Color color = Color.white;

	void Start () {
		GetComponent<Material> ().SetColor ("_Color", color);
	}

	void Update () {
		transform.Translate (0.0f, 0.0f, -speed);

		// Détruit la sphère si elle dépasse du champ de la caméra
		if (transform.position.z < -10) {
			Destroy (gameObject);
		}
	}
}
