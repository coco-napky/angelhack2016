﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour {


	public bool destroyer = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player")
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
