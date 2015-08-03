using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// this thing load the level
	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);	
	}
	
	public void QuitRequest() {
		Debug.Log ("I want to quit");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
	// This line automatically loads the next level in the Build Settings
		Application.LoadLevel(Application.loadedLevel + 1);	
	}
	
	public void BrickDestroyed() {
		if(Brick.brickCount <= 0) {
			LoadNextLevel();
		}
	}
}
