using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	private PlanetAttributes planet;
	private SphereBehaviour sphere;
	private int counter = 0;
	void Awake () {
		planet = transform.parent.GetComponent<PlanetAttributes>();
		Debug.Log(planet.center);
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
    sphere.rb.AddForce(direction * distance * Time.deltaTime * 10);
		Debug.Log(distance * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject gameObject = collider.gameObject;
		Debug.Log("GRAVITY ENTER TO : " + gameObject.tag);
		switch(gameObject.tag){
			case "Player":
				sphere = gameObject.GetComponent<SphereBehaviour>();
			break;
		}
	}
}
