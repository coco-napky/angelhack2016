using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public Scene nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void replayLevel(){
		int i = Application.loadedLevel;
		SceneManager.LoadScene (i);
	}

	public void loadNextLevel(){
		int i = Application.loadedLevel;
		SceneManager.LoadScene (i + 1);
	}
}
