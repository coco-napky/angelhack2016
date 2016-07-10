using UnityEngine;
using System.Collections;

public class InventoryItem2 : MonoBehaviour {

	public float xini;
	public float yini;
	public bool moved;
	public GameObject item;
	public GameObject empty;
	public Vector3 pos;
	public int cont;


	// Use this for initialization
	void Start () {
		xini = transform.position.x;
		yini = transform.position.y;
	}



	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0) && !moved) {
			moved = true;	
		} 

		if (Input.GetMouseButtonUp (0) && moved) {
			if(cont > 0){
				Vector3 v3 = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
				transform.position = new Vector3 (xini, yini, -1);
				Instantiate (item, v3, Quaternion.identity);
				moved = false;		
				cont--;
			}
		}
	}

	void Update(){
		if (moved && cont > 0)
			transform.position = new Vector3 (xini, yini, -1);
		else if (cont == 0) {
			transform.localScale = new Vector3 (0,0,0);
			Instantiate (empty, new Vector3 (xini, yini, -1), Quaternion.identity);
			--cont;
		}
			
	}
}
