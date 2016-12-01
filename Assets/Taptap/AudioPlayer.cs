using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
	private AudioClip clipToPlay;
	private AudioSource mAudio;

	void Start () {
		clipToPlay = Resources.Load ("Knock_On_Wood") as AudioClip;
		mAudio = GetComponent<AudioSource> ();
		mAudio.clip = clipToPlay;
	}

	void Update () {}
}