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
		float angle = Angler.GetAngle(currentPosition, center);
		direction = Angler.GetDirecton(angle, 180f);
		sphere.rb.velocity = direction * 10;
		SetCooldown(true);
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
