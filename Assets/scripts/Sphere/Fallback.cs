using UnityEngine;
using System.Collections;

public class Fallback : MonoBehaviour {

	public bool cooldown = false;
	private Vector2 direction;
	private SphereBehaviour sphere;

	public Color active;
	public Color inactive;

	void Awake () {
		sphere = GetComponent<SphereBehaviour>();
	}

	void Start () {
		active = sphere.color;
	}

	public void Act () {
		if(cooldown) return;

		Vector2 currentPosition = new Vector2(sphere.transform.position.x, sphere.transform.position.y);
		Vector2 center = sphere.currentPlanet.center;
		float angle = GetAngle(currentPosition, center);
		direction = GetDirecton(angle);
		sphere.rb.velocity = direction * 10;
		SetCooldown(true);
	}

	//Gets the angle in degrees formed by a point relative to a center
	float GetAngle (Vector2 first, Vector2 center) {
		float deltaX = first.x - center.x;
		float deltaY = first.y - center.y;
		return Mathf.Atan2(deltaY, deltaX) * 180/ Mathf.PI;
	}

	Vector3 GetDirecton (float angle) {
		return Quaternion.AngleAxis(angle + 180f, Vector3.forward) * Vector3.right;
	}

	public void SetCooldown (bool state) {
		cooldown = state;
		sphere._material.color = state ? inactive : active;
	}
}
