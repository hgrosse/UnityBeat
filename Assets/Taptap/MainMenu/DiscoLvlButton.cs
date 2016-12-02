using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DiscoLvlButton : MonoBehaviour {

	private const float THRESHOLD = 1f;
	private float enterTime;
	private ParticleSystem mParticle;

	void Start() {
		mParticle = GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter() {
		Debug.Log ("Enter DiscoButton");
		mParticle.Play ();
		enterTime = Time.time;
	}

	void OnTriggerStay() {
		if (Time.time - enterTime >= THRESHOLD) {
			SceneManager.LoadScene("TapGame");
		}
	}

	void OnTriggerExit() {
		mParticle.Stop ();
	}
}
