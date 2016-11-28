using UnityEngine;
using System.Collections;

public class Cylinder : MonoBehaviour {
    Texture texture1;
    Texture texture2;

    // Use this for initialization
    void Start () {
        texture1 = (Texture)Resources.Load("renard_01");
        texture2 = (Texture)Resources.Load("renard_02");
        GetComponent<Renderer>().material.mainTexture = texture1;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) {
        System.Console.WriteLine("Boum");
        //GetComponent<Renderer>().material.mainTexture = texture2;
        Destroy(this);

    }
}
