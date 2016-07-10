using UnityEngine;
using System.Collections;

public class BlockAttributes : MonoBehaviour {

	public Color actual;
	public int vida;
	public bool destroyable = true;
	// Use this for initialization
	void Start () {
		vida = 3;
		actual = new Color ();
		if(destroyable)
			ColorUtility.TryParseHtmlString ("#C6FF00FF", out actual);
        else
			ColorUtility.TryParseHtmlString ("#616161FF", out actual);
	}

	void Update(){
		this.GetComponent<Renderer>().material.color = actual;
	}

	public void ReceiceDamage() {
		if (!destroyable)
			return;
		vida--;
		switch (vida) {
			case 0:
				transform.localScale = new Vector3 (0, 0, 0);
			break;
			case 1:
				ColorUtility.TryParseHtmlString ("#0077B5FF", out actual);
			break;
			case 2:
				ColorUtility.TryParseHtmlString ("#9C27B0FF", out actual);
			break;
		}
	}
}
