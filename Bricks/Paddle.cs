using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	public bool autoPlay = false;
	
	private Ball ball;
	// Update is called once per frame
	
	void Start() {
	
		ball = GameObject.FindObjectOfType<Ball>();
	}
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
		
	}
	
	void AutoPlay() {
	//set it so that the paddle keeps the current coordinates
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
	//get a vector 3 of the position of the ball
		Vector3 ballPos = ball.transform.position;
	// set the paddle position x to be the same as the ball
		paddlePos.x = Mathf.Clamp(ballPos.x,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse() {
		//set it so that it keeps to the current coordinate
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		
		//Left should be close to 0, center 0.5, right is 1 with screenwidth and mouse_x only.
		// if multiply by 16 (Number of world units), tells us how many game units we got
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
		
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		// Recall This corresponds to the current object, which is the INSTANCE OF THE PADDLE OBJECT
		//Now transform.pos returns a vector 3, so we cant choose individual components.
		this.transform.position = paddlePos;
	
	}
}
