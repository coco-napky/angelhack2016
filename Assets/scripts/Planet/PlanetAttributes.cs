using UnityEngine;
using System.Collections;

public class PlanetAttributes : MonoBehaviour {
	public float radius;
  public Vector2 center;
  public bool visited = false;
	public bool waypoint = false;
	private Renderer _renderer;

	public Color waypointColor = new Color(42,221,115);
	public int cameraDirection = 2;

	//This happens before Start()
	void Awake() {
		_renderer = GetComponent<Renderer>();
		SetCenter();
		SetRadius();

		if(waypoint)
			SetColor(waypointColor);

	}

    void FixedUpdate() {
		SetCenter();
	}

	public void SetColor(Color color) {
		tweenColor(_renderer.material.color, color, 0.25f);
	}

	void SetCenter() {
		float x = _renderer.bounds.center.x,
		      y = _renderer.bounds.center.y;

		if(x != center.x && y != center.y)
			center  = new Vector2(x,y);
	}

	void SetRadius() {
		radius  = _renderer.bounds.size.y/2 + 0.5f;
	}

	void UpdateColor (Color newColor) {
		_renderer.material.color = newColor;
	}

	void tweenColor (Color from, Color to, float time) {
		iTween.ValueTo (gameObject, iTween.Hash ("from", from, "to", to, "time",
										time, "easetype", "easeInCubic", "onUpdate","UpdateColor"));
	}

}
