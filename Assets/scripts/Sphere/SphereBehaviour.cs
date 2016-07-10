using UnityEngine;
using System.Collections;

public class SphereBehaviour : MonoBehaviour {

    public float currentAngle = 0;
    public float speed;
    public float seconds;
    public float radius;
    public float x;
    public float y;
    public float z;
	public bool attached;

	private Vector2 direction; 
	private Rigidbody2D rb;
    private Vector2 center;
    

    void Start () {
        center   = new Vector2(0, 0);
    	attached = true;
    	seconds  = 1.5f;
        speed    = (2*Mathf.PI)/seconds;
        radius   = 2;
        z        = 10;
        rb       = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		Move();

		//Todo : Separate control concern to SphereController.cs
		if (Input.GetButtonUp ("Jump")){
			attached    = !attached;
            float angle = GetAngle(new Vector2(x,y));
            direction   = GetDirecton(angle);
            Debug.Log(direction);
		}
	}

	void Move() {
		if (attached) {
        	currentAngle += Time.deltaTime   * speed;
			x      = Mathf.Cos (currentAngle) * radius;
			y      = Mathf.Sin (currentAngle) * radius;
            transform.position = new Vector3(x, y, z);
        }else
            rb.velocity = direction * 10;
	}

    float GetAngle(Vector2 point) {
        float deltaX = point.x - center.x;
        float deltaY = point.y - center.y;

        return Mathf.Atan2(deltaY, deltaX) * 180/ Mathf.PI;
    }

    Vector3 GetDirecton(float angle) {
        return Quaternion.AngleAxis(angle + 90f, Vector3.forward) * Vector3.right;
    }
}