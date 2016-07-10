using UnityEngine;
using System.Collections;

public class PlanetAttributes : MonoBehaviour {

	private float radius;
	public float radiusOffset;
	public float speed;

	public Color actual;

	// Use this for initialization
	void Start () {
		actual = new Color ();
		//actual = this.GetComponent<Renderer> ().material.color;
		radius = transform.localScale.x - (transform.localScale.x * 0.375f);
	}

	void Update(){
		if(actual.r != 0)
			this.GetComponent<Renderer>().material.color = actual;
	}
}
