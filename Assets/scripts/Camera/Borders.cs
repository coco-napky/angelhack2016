using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player")
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		else if (collider.gameObject.tag == "Planet") {
			var planetAttributes = collider.gameObject.GetComponent<PlanetAttributes>();
			if (planetAttributes.visited == true) {
				audio.Play ();
				Destroy (collider.gameObject);
			}
		}
	}
}
