using UnityEngine;
using System.Collections;

public class Fallback : MonoBehaviour {

	public bool cooldown = false;
	private Vector2 direction;
	public SphereBehaviour sphere;

	public Color active;
	public Color inactive;

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

		if(state)
			tweenColor(sphere._material.color, inactive, 0.35f);
		else
		  tweenColor(sphere._material.color, active, 0.35f);
  }

	void UpdateColor (Color newColor) {
		sphere._material.color = newColor;
	}

	void tweenColor (Color from, Color to, float time) {
		iTween.ValueTo (gameObject, iTween.Hash ("from", from, "to", to, "time",
										time, "easetype", "easeInCubic", "onUpdate","UpdateColor"));
	}
}
