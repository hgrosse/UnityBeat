using UnityEngine;
using System.Collections;

public class HitCylinder : MonoBehaviour {

    public Color defaultColor;
    public Color pressedColor;

    private Renderer mRenderer;

    // Use this for initialization
    void Start () {
        mRenderer = GetComponent<Renderer>();
        toggleColor(false);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) {
        toggleColor(true);
    }

    void OnTriggerExit(Collider other) {
        toggleColor(false);
    }

    private void toggleColor(bool pressed) {
        mRenderer.material.SetColor("_Color", pressed ? pressedColor : defaultColor);
    }
}
