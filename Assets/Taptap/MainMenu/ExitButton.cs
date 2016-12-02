using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	private const float THRESHOLD = 1f;
	private float enterTime;
	private ParticleSystem mParticle;

	void Start () {
		mParticle = GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter() {
		Debug.Log ("Enter QuitButton");
		mParticle.Play ();
		enterTime = Time.time;
	}

	void OnTriggerStay() {
		if (Time.time - enterTime >= THRESHOLD) {
			Application.Quit ();
		}
	}

	void OnTriggerExit() {
		mParticle.Stop ();
	}
}
