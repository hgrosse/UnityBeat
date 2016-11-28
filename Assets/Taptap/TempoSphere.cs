using UnityEngine;
using System.Collections;


public class TempoSphere : MonoBehaviour {

    public GameObject sphere;

	// Use this for initialization
	void Start () {
        transform.Translate(0, 1, 40);
        GameObject instanciatedObject = (GameObject) Instantiate(sphere, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
