﻿using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	private PlanetAttributes planet;
	private SphereBehaviour sphere;
	public float dividend;
	public float offset;
	public CircleCollider2D collider;
	void Awake () {
		planet = transform.parent.GetComponent<PlanetAttributes>();
		collider = GetComponent<CircleCollider2D>();
	}

	void Start () {
		collider.radius = planet.radius/2;
	}
	void FixedUpdate () {
		if(sphere == null) return;

		ApplyGravity();
		if(sphere.attached)
			sphere = null;
	}

	void ApplyGravity () {
		Vector2 currentPosition = new Vector2(sphere.transform.position.x, sphere.transform.position.y);
		float distance = Vector2.Distance(currentPosition,planet.center);
		float angle = Angler.GetAngle(currentPosition, planet.center);
		Vector2 direction = Angler.GetDirecton(angle, 180f);
		float multiplier = Time.deltaTime * dividend/distance + offset;
    sphere.rb.AddForce(direction * multiplier);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject gameObject = collider.gameObject;
		switch(gameObject.tag){
			case "Player":
				sphere = gameObject.GetComponent<SphereBehaviour>();
			break;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		GameObject gameObject = collider.gameObject;
		switch(gameObject.tag){
			case "Player":
				sphere = null;
			break;
		}
	}
}
