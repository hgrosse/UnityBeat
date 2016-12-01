using UnityEngine;
using System.Collections;


public class TempoSphere : MonoBehaviour {

	public float speed;

	private const float THRESHOLD = .02f;

	private float mLastTime;

	void Start () {
		mLastTime = 0f;
		InvokeRepeating ("GoForward", 0f, THRESHOLD);
	}

	void FixedUpdate() {

		// Détruit la sphère si elle dépasse le champ de la caméra
		if (transform.position.z < -10) {
			Destroy (gameObject);
		}
	}

	private bool ShouldMove() {
		float timestamp = Time.time;
		if ((timestamp - mLastTime) >= THRESHOLD) {
			mLastTime = timestamp;
			return true;
		}
		return false;
	}

	private void GoForward() {
		transform.Translate (0.0f, 0.0f, -speed);
	}
}
