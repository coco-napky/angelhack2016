using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public GameObject player;
	public float offset;
	public Vector3 destiny;
	public Vector3 origin;
	public bool moving = false;
	public float speed;
	private float length,startTime;
	// Use this for initialization
	void Start () {
		speed = 75;
	}

	void LateUpdate() {
		Move();
	}

	public void SetMovement(Vector3 destiny) {
		float nextValueY = destiny.y > (transform.position.y) ? destiny.y + offset : transform.position.y;
		this.destiny = new Vector3(destiny.x, nextValueY, -10);
		origin       = transform.position;
		startTime    = Time.time;
		length       = Vector3.Distance(origin, destiny);
		moving       = true;
	}

	void Move() {
		if(!moving) return;
		
		float distCovered = (Time.time - startTime) * speed;
    float fracJourney = distCovered / length;
    transform.position = Vector3.Lerp(origin, destiny, fracJourney);
	}
}
