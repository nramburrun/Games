using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
	//Distance between ball and paddle.
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//set position of ball
	
	//if the game hasn't started
		if(!hasStarted){
		// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//listen to mouse input
		//wait for a mouse press to launch
			if(Input.GetMouseButton(0)) {
			//once it launches, change the hasStarted flag.
				hasStarted = true;
				//launch ball	
				this.rigidbody2D.velocity = new Vector2(2.5f,12f);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		// modify the ball's bounce everytime it bounces off somethin
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
