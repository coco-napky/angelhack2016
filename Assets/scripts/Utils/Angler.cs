using UnityEngine;
using System.Collections;

public class Angler : MonoBehaviour {

	//Gets the angle in degrees formed by a point relative to a center
	public static float GetAngle (Vector2 first, Vector2 center) {
		float deltaX = first.x - center.x;
		float deltaY = first.y - center.y;
		return Mathf.Atan2(deltaY, deltaX) * 180/ Mathf.PI;
	}

	public static Vector3 GetDirecton (float angle, float offset) {
		return Quaternion.AngleAxis(angle + offset, Vector3.forward) * Vector3.right;
	}
}
