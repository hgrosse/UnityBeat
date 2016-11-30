using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameScript : MonoBehaviour {

	public GameObject spherePrefab;

	private int mScore;
	private GUIText mGUIScore;
	private LevelReader mLevel;
	private Vector3[] mStartPositions = new Vector3[4];

	private float ellapsedTime = 0f;

	void Start () {
		mStartPositions [0] = new Vector3 (-4f, 0f, 100f);
		mStartPositions [1] = new Vector3 (4f, 0f, 100f);
		mStartPositions [2] = new Vector3 (-4f, -5f, 100f);
		mStartPositions [3] = new Vector3 (4f, -5f, 100f);

		mGUIScore = GetComponent<GUIText> ();
		resetScore ();
		mLevel = new LevelReader ("Assets/TapTap/Resources");
		mLevel.loadLevel ("KnockOnWood.txt");
	}

	void Update () {
		if (ellapsedTime > 0.1) {
			// Tous les 10èmes de seconde
			if (mLevel.hasNext ()) {
				// S'il y a encore des notes à lire
				int beat = mLevel.nextBeat ();
				for (int i = 0; i < 4; i++) {
					if (LevelReader.decodeBeat(beat, i)) {
						// Générer une sphère
						generateSphere(mStartPositions[i], getColor(i));
					}
				}
			}
		}
		ellapsedTime += Time.deltaTime;
	}
		
	private void updateScore() {
		mGUIScore.text = "Score : " + mScore;
	}

	public void addScore(int points) {
		if (points > 0) {
			mScore += points;
			updateScore ();
		}
	}

	public void resetScore() {
		mScore = 0;
		updateScore ();
	}

	private void generateSphere(Vector3 position, Color color) {
		GameObject sphere = GameObject.Instantiate (spherePrefab);
		sphere.transform.Translate (position);
		sphere.name = "Sphere";
		sphere.GetComponent<TempoSphere> ().color = color;
	}

	private Color getColor(int pos) {
		switch (pos) {
		case 0:
			return Color.red;
		case 1:
			return Color.blue;
		case 2:
			return Color.green;
		case 3:
			return Color.yellow;
		default:
			return Color.white;
		}
	}
}
