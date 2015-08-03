using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public AudioClip crack;
	
	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		
		if(isBreakable) {
			brickCount++;
		}
		timesHit = 0; 
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//collision sinc eit ain ta trigger
	void OnCollisionEnter2D(Collision2D collision) {
		if(isBreakable) {
			AudioSource.PlayClipAtPoint(crack,transform.position,0.5f);
		
			HandleHits();
			
		}
	}
	
	void HandleHits() {
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			brickCount--;
			//send a message to level manager
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
	// to switch sprites use the lines below
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	// TODO Remove this method once we can actually win the game
	
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
