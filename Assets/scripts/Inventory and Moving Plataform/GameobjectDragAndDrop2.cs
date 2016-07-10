﻿using UnityEngine;
using System.Collections;

public class GameobjectDragAndDrop2 : MonoBehaviour {

	public GameObject target;
	public bool isMouseDrag;
	public Vector3 screenPosition;
	public Vector3 offset;

	GameObject ReturnClickedObject(out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
		{
			target = hit.collider.gameObject;
		}
			
		return target;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			target = ReturnClickedObject(out hitInfo);
			if (target != null)
			{
				isMouseDrag = true;
				//Convert world position to screen position.
				screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
				offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDrag = false;
		}
		if (isMouseDrag)
		{
			//track mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
			//convert screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
			//It will update target gameobject's current postion.
			target.transform.position = currentPosition;
		}
	}
}
