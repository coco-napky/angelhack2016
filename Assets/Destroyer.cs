﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Planet") {
			var planetAttributes = collider.gameObject.GetComponent<PlanetAttributes>();
			audio.Play ();
			Destroy (collider.gameObject);
		}
	}
}
