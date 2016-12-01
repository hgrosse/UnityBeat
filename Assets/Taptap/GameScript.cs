using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameScript : MonoBehaviour {

	/**
	 * Modèle de la sphère à générer.
	 */
	public GameObject spherePrefab;

	private const float THRESHOLD = 0.1f;

	private Vector3[] mStartPositions = new Vector3[4];
	private string[] mTextures = new string[] {
		"red_fire", "blue_fire", "green_fire", "yellow_fire"
	};

	private int mScore;
	private GUIText mGUIScore;
	private LevelReader mLevel;
	private AudioSource mAudio;

	private float mLastTime;

	void Start () {
		mAudio = GameObject.FindObjectOfType<AudioSource> ();

		mStartPositions [0] = new Vector3 (-4f, 3f, 50f);
		mStartPositions [1] = new Vector3 (4f, 3f, 50f);
		mStartPositions [2] = new Vector3 (-4f, -2f, 50f);
		mStartPositions [3] = new Vector3 (4f, -2f, 50f);

		mGUIScore = GetComponent<GUIText>();
		ResetScore ();
		mLevel = new LevelReader ("Assets/TapTap/Levels");
		mLevel.LoadLevel ("KnockOnWood");

		mAudio.PlayDelayed (2f);
		InvokeRepeating ("Perform", 0f, THRESHOLD);
	}
		
	private void UpdateScore() {
		mGUIScore.text = "Score : " + mScore;
	}

	/**
	 * Ajoute un nombre de points au score du joueur.
	 */
	public void AddScore(int points) {
		if (points > 0) {
			mScore += points;
			UpdateScore ();
		}
	}

	/**
	 * Réinitialise le score.
	 */
	public void ResetScore() {
		mScore = 0;
		UpdateScore ();
	}

	/**
	 * Crée dynamiquement une nouvelle sphère de la couleur donnée,
	 * et la place à la position précisée par le Vector.
	 */
	private void GenerateSphere(Vector3 position, string texture) {
		GameObject sphere = GameObject.Instantiate (spherePrefab);
		sphere.transform.position = position;
		sphere.name = "Sphere";
		sphere.GetComponent<Renderer> ().material.mainTexture = Resources.Load (texture) as Texture;
	}

	private void Perform() {
		if (mLevel.HasNext ()) {
			// S'il y a encore des notes à lire
			int beat = mLevel.NextBeat ();
			for (int i = 0; i < 4; i++) {
				if (LevelReader.DecodeBeat (beat, i)) {
					// Générer une sphère
					GenerateSphere (mStartPositions [i], mTextures[i]);
				}
			}
		}
	}
}
