using UnityEngine;
using System.Collections;

public class Oscilator2 : MonoBehaviour {

    public float timercounter = 0;
    public float speed;
    public float width;
    public float height;
    public float x;
    public float y;
    public float z;
	public bool locked;
	public float xini;
	public float yini;

    void Start () {
        speed = 5;
        width = 5;
        height = 5;
		yini = 0;
		xini = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        

		if (!locked) {
			timercounter += Time.deltaTime * speed;
			x = Mathf.Cos (timercounter) * width;
			y = Mathf.Sin (timercounter) * height;
			z = 10;
			transform.position = new Vector3(x+xini, y+yini, z);
		} else {
			
		}

		if (Input.GetButtonDown ("Jump"))
			locked = !locked;


	}
}
