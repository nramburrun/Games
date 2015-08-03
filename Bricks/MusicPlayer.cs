using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;
	// Use this for initialization
	
	/* The Game object that is inside this method is the GAME OBJECT (stuff under Create in Unity)
	When you attach the script to the game object component, it directly references to that game object
	Dont Destroy on Load will keep the game object(music player) alive when you change scenes*/
	
	void Awake() {
		Debug.Log ("Music Player AWAKE " + GetInstanceID());
		if(instance != null) {
			Destroy(gameObject);
			print ("Duplicate music player self destructing");
		} else {
			// else claim this instance
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	void Start () {
	// takes in a game object,make sure its not destroyed on load
		Debug.Log ("Music Player START " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
