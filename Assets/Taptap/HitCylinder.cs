using UnityEngine;
using System.Collections;

public class HitCylinder : MonoBehaviour {
	
    public Color defaultColor;
    public Color pressedColor;

    private Renderer mRenderer;
	private ParticleSystem mParticle;
	private GameScript mGameInstance;
	private GameObject mHitSphere;

    void Start () {
		GameObject camera = GameObject.FindWithTag ("MainCamera");
		mGameInstance = camera.GetComponent<GameScript> ();
		mParticle = GetComponent<ParticleSystem> ();
        mRenderer = GetComponent<Renderer>();
		mHitSphere = null;
        ToggleColor(false);
    }

	void Update () {
	    
	}

	/**
	 * Evènement déclenché lorsqu'un autre GameObject entre en contact
	 * avec ce cylindre.
	 * Si c'est une sphère, on l'enregistre.
	 * Sinon, s'il y a une sphère enregistrée, on la détruit et on gagne des points.
	 */
    void OnTriggerEnter(Collider other) {
		if ("Sphere".Equals (other.gameObject.name)) {
			// C'est une sphère !
			mHitSphere = other.gameObject;
		} else {
			ToggleColor(true);
			if (mHitSphere != null) {
				// Gagner des points s'il y a une sphère
				mGameInstance.AddScore (50);
				mParticle.Play ();
				Destroy (mHitSphere);
				mHitSphere = null;
			}
		}
    }

	/**
	 * Evènement déclenché lorsqu'un autre GameObject n'est plus en contact
	 * avec ce cylindre.
	 * Si c'est une sphère, on l'oublie.
	 */
    void OnTriggerExit(Collider other) {
		ToggleColor(false);
		if ("Sphere".Equals (other.gameObject.name)) {
			// La sphère est sortie
			mHitSphere = null;
		}
    }

	/**
	 * Change la couleur du cylindre en fonction 
	 * de son état avec/sans contact avec un autre objet.
	 */
    private void ToggleColor(bool pressed) {
        mRenderer.material.SetColor("_Color", pressed ? pressedColor : defaultColor);
    }
}