using UnityEngine;
using System.Collections;

public class PlanetAttributes : MonoBehaviour {

	private float radius;
	public float radiusOffset;
	public float speed;

	// Use this for initialization
	void Start () {
		radius = transform.localScale.x - (transform.localScale.x * 0.375f);
	}
}
