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

	public void ScrollCamera(Vector3 destiny, int scrollOption){
		
		switch (scrollOption){
			case 1: //scroll to the top left of the current planet
				destiny = new Vector3 (destiny.x - 10, destiny.y + 7, -10);
				iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", 3.0f, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
				break;

			case 2: //scroll to the top
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", 3.0f, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
				break;

			case 3: //scroll to the top right of the current planet
			    destiny = new Vector3 (destiny.x + 10, destiny.y + 7, -10);
				iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", 3.0f, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
				break;
			default:
				
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", 3.0f, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
				break;
		}
	}

	void Move() {
		if(!moving) return;
		
		float distCovered = (Time.time - startTime) * speed;
    float fracJourney = distCovered / length;
    transform.position = Vector3.Lerp(origin, destiny, fracJourney);
	}
}
