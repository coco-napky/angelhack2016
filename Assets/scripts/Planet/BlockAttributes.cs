using UnityEngine;
using System.Collections;

public class BlockAttributes : MonoBehaviour {
	public Color currentColor;
	public int hp;
	public bool destroyable = true;
	public AudioSource audio;
	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		hp = 3;
		currentColor = new Color ();
		_renderer = GetComponent<Renderer>();
		if(destroyable)
			ColorUtility.TryParseHtmlString ("#C6FF00FF", out currentColor);
    else
			ColorUtility.TryParseHtmlString ("#616161FF", out currentColor);
		_renderer.material.color = currentColor;

		audio = GetComponent<AudioSource>();
	}

	public void ReceiveDamage() {
		if (!destroyable) return;

		hp--;
		audio.Play ();
		switch (hp) {
			case 0:
				Destroy(gameObject);
			break;
			case 1:
				ColorUtility.TryParseHtmlString ("#0077B5FF", out currentColor);
			break;
			case 2:
				ColorUtility.TryParseHtmlString ("#9C27B0FF", out currentColor);
			break;
		}
		_renderer.material.color = currentColor;
	}
}
