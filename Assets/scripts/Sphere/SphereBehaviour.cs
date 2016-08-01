using UnityEngine;
using System.Collections;

public class SphereBehaviour : MonoBehaviour {
	//THIS IS IN RADIANS
	private float x,y,z,speed,currentAngle = 0;
	public bool attached;
	public Rigidbody2D rb;
	public Color color;
	public Material _material;
	public CameraBehaviour _camera;
	public PlanetAttributes currentPlanet;
	public Vector2 direction;
	private Fallback fb;

	void Awake () {
		z         = 10;
		rb        = GetComponent<Rigidbody2D>();
		_material = GetComponent<Renderer>().material;
		color     = _material.color;
	}

	void Start () {
		fb        = GetComponent<Fallback>();
		fb.sphere = this;
		fb.active = color;
		SetCurrentPlanet(currentPlanet.gameObject, null);
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if(attached)
				Detach();
			else
				fb.Act();
		}
	}

	public void Detach() {
		float angle = GetAngle(new Vector2(x,y));
		attached    = false;
		direction   = GetDirecton(angle);
		rb.velocity = direction * 15/currentPlanet.radius;
	}

	void FixedUpdate() {
		Move();
	}

	void Move() {
		if(!attached) return;

		x = currentPlanet.center.x + Mathf.Cos (currentAngle) * currentPlanet.radius;
		y = currentPlanet.center.y + Mathf.Sin (currentAngle) * currentPlanet.radius;
		transform.position = new Vector3(x, y, z);
		currentAngle += Time.deltaTime  * speed;
		rb.velocity = Vector2.zero;
	}

	//Gets the angle formed by a given point and the center of currentPlanet
	float GetAngle(Vector2 point) {
		float deltaX = point.x - currentPlanet.center.x;
		float deltaY = point.y - currentPlanet.center.y;
		return Mathf.Atan2(deltaY, deltaX) * 180/ Mathf.PI;
	}

	Vector3 GetDirecton(float angle) {
		return Quaternion.AngleAxis(angle + 90f, Vector3.forward) * Vector3.right;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(attached) return;

		GameObject gameObject = collision.gameObject;
		switch(gameObject.tag){
			case "Planet":
				SetCurrentPlanet(gameObject, collision);
			break;
			case "Block":
					BlockAttributes block = gameObject.GetComponent<BlockAttributes>();
					block.ReceiveDamage();
			break;
		}
	}

	void SetCurrentPlanet(GameObject gameObject, Collision2D collision) {
		currentPlanet = gameObject.GetComponent<PlanetAttributes>();
		fb.SetCooldown(currentPlanet.visited && fb.cooldown);
		currentPlanet.SetColor(color);
	  currentPlanet.visited = true;

		attached = true;
		speed = (2*Mathf.PI)/currentPlanet.radius;
		rb.velocity = Vector2.zero;
		_camera.SetMovement(transform.position);

		if(collision == null) return;

		//Sets currentAngle on contact point of collisioned planet
		foreach (ContactPoint2D contact in collision.contacts) {
			var point = contact.point;
			var deltaX = point.x - currentPlanet.center.x;
			var deltaY = point.y - currentPlanet.center.y;
			currentAngle = Mathf.Atan2(deltaY, deltaX);
		}
	}
}
