using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TouchMovement : MonoBehaviour {
	
	private GameObject aliah;
	private GameObject guiObj;
	private GUIScript gScript;
	private AliahScript script;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainScene")) {

			guiObj = GameObject.FindWithTag ("GUI");
			aliah = GameObject.FindWithTag ("Aliah");
			gScript = guiObj.GetComponent<GUIScript> ();
			script = aliah.GetComponent<AliahScript> ();
			sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && !gScript.showWindow)
			{
				if (this.gameObject.tag == "Up" && !script.pause)
					script.moveUp();
				else if (this.gameObject.tag == "Down" && !script.pause)
					script.moveDown();
				else if (this.gameObject.tag == "Exit")
					Application.Quit();
				else if (this.gameObject.tag == "Pause" )
				{
					if (!script.pause)
					{
						sprite.sprite = script.playButton;
						script.pauseGame(true);
					}
					else
					{
						sprite.sprite = script.pauseButton;
						script.unPauseGame(true);
					}
				}
				else if (this.gameObject.tag == "Start")
				{
					int i  = SceneManager.GetActiveScene().buildIndex;
					SceneManager.LoadScene(i + 1);
				}
				else if (this.gameObject.tag == "End")
					SceneManager.LoadScene(0);
				
			}
		}

		/*
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				if (this.gameObject.tag == "Up" && !script.pause)
					script.moveUp();
				else if (this.gameObject.tag == "Down" && !script.pause)
					script.moveDown();
				else if (this.gameObject.tag == "Exit")
					Application.Quit();
				else if (this.gameObject.tag == "Pause" )
				{
					if (!script.pause)
					{
						sprite.sprite = script.playButton;
						script.pauseGame();
					}
					else
					{
						sprite.sprite = script.pauseButton;
						script.unPauseGame();
					}
				}
				else if (this.gameObject.tag == "Start")
				{
					int i  = SceneManager.GetActiveScene().buildIndex;
					SceneManager.LoadScene(i + 1);
				}
				else if (this.gameObject.tag == "End")
					SceneManager.LoadScene(0);
				
			}
		}
		*/


	}

	public void pauseTime(bool playAudio){
		if (this.gameObject.tag == "Pause" )
		{
			sprite.sprite = script.playButton;
			script.pauseGame(playAudio);
		}
	}
	public void unPauseTime(bool playAudio){
		if (this.gameObject.tag == "Pause" )
		{
			script.unPauseGame(playAudio);
		}
	}
}
