using UnityEngine;
using System.Collections;

public class PlanetAttributes : MonoBehaviour {
	public float radius;
  public Vector2 center;

	//This happens before Start()
	void Awake() {
		SetCenter();
		SetRadius();
	}

	void FixedUpdate() {
		SetCenter();
	}

	public void SetColor(Color color) {
		GetComponent<Renderer>().material.color = color;
	}

	void SetCenter() {
		float x = GetComponent<Renderer>().bounds.center.x,
		      y = GetComponent<Renderer>().bounds.center.y;

		if(x != center.x && y != center.y)
			center  = new Vector2(x,y);
	}

	void SetRadius() {
		radius  = GetComponent<Renderer>().bounds.size.y/2 + 0.5f;
	}
}
