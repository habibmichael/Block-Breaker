using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	private int timesHit;

	public Sprite[] hitSprites;
	public static int brickCount=0;

	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			brickCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (isBreakable) {
			HandleHits ();
		}
	

	}

	void HandleHits(){
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit >= maxHits) {
			brickCount--;
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		} else
			LoadSprites ();

	}

	//	SimulateWin ();

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	//TODO destroy method once you can actually wiin
	void SimulateWin(){

		levelManager.LoadNextLevel ();
	}

}
