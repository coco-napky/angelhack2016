﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public PlanetAttributes startingPlanet;

	void Start () {
		ScrollCamera(startingPlanet.transform.position, startingPlanet.cameraDirection);
	}

	public void ScrollCamera(Vector3 destiny, int scrollOption){
		switch (scrollOption){
			case 1: //scroll to the top left of the current planet
				destiny = new Vector3 (destiny.x - 3.5f, destiny.y + 7, -10);
				break;
			case 2: //scroll to the top
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				break;
			case 3: //scroll to the top right of the current planet
			  destiny = new Vector3 (destiny.x + 3.5f, destiny.y + 7, -10);
				break;
			default:
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				break;
		}
		float distance = Vector3.Distance(destiny, transform.position);
		float seconds  = distance/4;
		iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", seconds, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
	}

}
