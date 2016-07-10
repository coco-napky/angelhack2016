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
    
    public PlanetAttributes startPlanet;    

    public CameraBehaviour camera;
    public Vector3 gizmo;

    void Start () {
    	attached = true;
    	seconds  = 2f;
        z        = 10;
        rb       = GetComponent<Rigidbody2D>();
        float planet_x = startPlanet.GetComponent<Renderer>().bounds.center.x;
        float planet_y = startPlanet.GetComponent<Renderer>().bounds.center.y;
        this.center = new Vector2(planet_x, planet_y);
        this.radius = startPlanet.GetComponent<Renderer>().bounds.size.y/2 + 0.5f;
        speed = (2*Mathf.PI)/radius;
	}
	
	// Update is called once per frame
	void Update () {
		//Todo : Separate control concern to SphereController.cs
		if (Input.GetMouseButtonDown(0))
			detach();
		
    }

    void detach() {
        float angle = GetAngle(new Vector2(x,y));
        attached    = !attached;
        direction   = GetDirecton(angle);
        rb.velocity = direction * 15/radius;
        Debug.Log(direction);
    }

    void FixedUpdate() {
        Move();
	}

	void Move() {
		if (attached) {   
        	currentAngle += Time.deltaTime  * speed;
			x = center.x + Mathf.Cos (currentAngle) * radius;
			y = center.y + Mathf.Sin (currentAngle) * radius;
            transform.position = new Vector3(x, y, z);

            if(Mathf.Abs(rb.velocity.x ) > 0.1f || Mathf.Abs(rb.velocity.y ) > 0.1f)
                rb.velocity = new Vector2(0,0);
        }
	}

    float GetAngle(Vector2 point) {
        float deltaX = point.x - center.x;
        float deltaY = point.y - center.y;

        return Mathf.Atan2(deltaY, deltaX) * 180/ Mathf.PI;
    }

    Vector3 GetDirecton(float angle) {
        return Quaternion.AngleAxis(angle + 90f, Vector3.forward) * Vector3.right;
    }

    void OnCollisionEnter2D(Collision2D collision){
        GameObject planet = collision.gameObject;
        Debug.Log("Collision : " + planet.tag);
        
        if(!attached)
            switch(planet.tag){
                case "Planet" :

                    attached = true;
                    float planet_x = planet.GetComponent<Renderer>().bounds.center.x;
                    float planet_y = planet.GetComponent<Renderer>().bounds.center.y;
                    this.center = new Vector2(planet_x, planet_y);
                    this.radius = planet.GetComponent<Renderer>().bounds.size.y/2 + 0.5f;
                    currentAngle += 3;
                    speed = (2*Mathf.PI)/radius;
                    rb.velocity = new Vector2(0,0);

                    camera.SetMovement(transform.position);

                    //contacts
                    foreach (ContactPoint2D contact in collision.contacts) {

                        var point = contact.point;
                        var deltaX = point.x - planet_x;
                        var deltaY = point.y - planet_y;
                        currentAngle = Mathf.Atan2(deltaY, deltaX);
                        
                    }
                break;
            }
        }
}