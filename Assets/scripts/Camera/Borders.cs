using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour {

	public AudioSource audio;
	public bool destroyer = false;

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
			if (destroyer == true) {
				audio.Play ();
				Destroy (collider.gameObject);
			}
		}
	}
}
