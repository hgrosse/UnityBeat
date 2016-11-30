using UnityEngine;
using System.Collections;

public class HitCylinder : MonoBehaviour {

    public Color defaultColor;
    public Color pressedColor;

    private Renderer mRenderer;
	private GameScript mGameInstance;
	private GameObject mHitSphere;

    void Start () {
		GameObject camera = GameObject.FindWithTag ("MainCamera");
		mGameInstance = camera.GetComponent<GameScript> ();
        mRenderer = GetComponent<Renderer>();
		mHitSphere = null;
        toggleColor(false);
    }

	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) {
		toggleColor(true);
		if ("Sphere".Equals (other.gameObject.name)) {
			// C'est une sphère !
			mHitSphere = other.gameObject;
			Debug.Log ("Sphere entered : " + mHitSphere);
		} else {
			// C'est un bras !
			Debug.Log ("Enter trigger with " + other.gameObject.name);

			if (mHitSphere != null) {
				// Gagner des points s'il y a une sphère
				Debug.Log("Earned 50 points");
				mGameInstance.addScore (50);
				Destroy (mHitSphere);
				mHitSphere = null;
			}
		}
    }
		
    void OnTriggerExit(Collider other) {
		toggleColor(false);
		if ("Sphere".Equals (other.gameObject.name)) {
			// La sphère est sortie
			Debug.Log ("Sphere exited : " + mHitSphere);
			mHitSphere = null;
		} else {
			Debug.Log("Exit trigger with " + other.gameObject.name);
		}
    }

    private void toggleColor(bool pressed) {
        mRenderer.material.SetColor("_Color", pressed ? pressedColor : defaultColor);
    }
}
