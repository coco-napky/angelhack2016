using UnityEngine;
using System.Collections;

public class BlockBehaviour : MonoBehaviour {
	public Color currentColor;
	public int hp;
	public bool destroyable = true;
	public AudioSource _audio;
	private Renderer _renderer;
	private bool dead = false;
	public Color deadColor;
	void Start () {
		hp = 3;
		currentColor = new Color ();
		_renderer = GetComponent<Renderer>();
		if(destroyable)
			ColorUtility.TryParseHtmlString ("#C6FF00FF", out currentColor);
    else
			ColorUtility.TryParseHtmlString ("#616161FF", out currentColor);
		_renderer.material.color = currentColor;

		_audio = GetComponent<AudioSource>();
	}

	void FixedUpdate () {
		if(dead && !_audio.isPlaying)
			Destroy(gameObject);
	}

	public void ReceiveDamage () {
		if (!destroyable) return;

		hp--;
		_audio.Play();
		Color _color = new Color();
		switch (hp) {
			case 0:
				dead = true;
				//TODO: "Death" animation, maybe?
				transform.localScale = new Vector3(0,0,0);
				return;
			break;
			case 1:
				ColorUtility.TryParseHtmlString ("#004D40FF", out _color);
			break;
			case 2:
				ColorUtility.TryParseHtmlString ("#558B2FFF", out _color);
			break;
		}
		tweenColor(_renderer.material.color, _color, 0.5f);
	}

	 void OnCollisionExit2D (Collision2D collision) {
		GameObject gameObject = collision.gameObject;
		switch(gameObject.tag){
			case "Player":
				ReceiveDamage();
			break;
		}
	}

	void UpdateColor (Color newColor) {
		_renderer.material.color = newColor;
	}

	void tweenColor (Color from, Color to, float time) {
		iTween.ValueTo (gameObject, iTween.Hash ("from", from, "to", to, "time",
										time, "easetype", "easeInCubic", "onUpdate","UpdateColor"));
	}

}
