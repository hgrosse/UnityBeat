using UnityEngine;

public class SphereGenerator : MonoBehaviour {

	public GameObject spherePrefab;
	public Color sphereColor = Color.white;

	private const float delay = 1f;
	private float lastTime = 0f;

	void Start () {
		
	}
	
	void Update () {
		if ((Time.time - lastTime) > delay) {
			lastTime = Time.time;
			GameObject sphere = newSphere();
		}
	}

	private GameObject newSphere() {
		Vector3 initialPos = new Vector3 (transform.position.x, 
			transform.position.y -3, transform.position.z);
		GameObject sphere = GameObject.Instantiate (spherePrefab);
		sphere.transform.Translate (initialPos);
		sphere.name = "Sphere";
		sphere.GetComponent<TempoSphere> ().color = sphereColor;
		return sphere;
	}


}
