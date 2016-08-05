using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public void ScrollCamera(Vector3 destiny, int scrollOption){
		switch (scrollOption){
			case 1: //scroll to the top left of the current planet
				destiny = new Vector3 (destiny.x - 10, destiny.y + 7, -10);
				break;
			case 2: //scroll to the top
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				break;
			case 3: //scroll to the top right of the current planet
			  destiny = new Vector3 (destiny.x + 10, destiny.y + 7, -10);
				break;
			default:
				destiny = new Vector3 (destiny.x, destiny.y + 7, -10);
				break;
		}
		iTween.MoveTo (gameObject, iTween.Hash ("position", destiny, "time", 3f, "oncomplete", "setPosAndSpeed", "oncompletetarget", gameObject));
	}

}
