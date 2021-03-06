using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Aliah_IfElse : MonoBehaviour {

	private bool showWindow = false;
	private AudioSource aud;
	private GameObject ball;
	private BallScript ballScript;
	public GameObject pipe;
	public GameObject black;
	private SpriteRenderer black_sr;

	string part1 = "public static void main(String[] args) {\n";
	string part2 = "   int pipe_location = ";
	string part3 = "1";
	string part4 = ";\n   if (ball_hits == devil) {\n      ";
	string part5 = "";
	string part6 = "\n   }";
	string part7 = "   else if (ball_hits == panel) {\n      "; 
	string part8 = "";
	string part9 = "\n   }";
	string part10 ="   else {\n";
	string part11 ="      //Do Nothing\n   }\n}\n";

	string text;

	int counter = 0;
	GUIStyle style;
	string value = " ";

	public bool devil_text;
	public bool panel_text;

	string devil_string;
	string panel_string;

	int part3_val;

	private int health;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public Sprite heartempty;
	public AudioClip ouch;
	private float time;

	private HelpScript help;
	private bool movement;

	void Awake(){
		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 3;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();
		}
	}

	// Use this for initialization
	void Start () {

		ball = GameObject.FindGameObjectWithTag("Ball");
		ballScript = ball.GetComponent<BallScript> ();
		aud = GetComponent<AudioSource>();
		health = 3;
		devil_text = false;
		panel_text = false;
		time = 0.0f;
		black_sr = black.GetComponent<SpriteRenderer> ();
		help = this.gameObject.GetComponent<HelpScript> ();
		movement = false;
		help.helpScreen ();


	}

	void OnGUI() {

		if (counter == 0) {
			style = GUI.skin.box;
			style.alignment = TextAnchor.UpperLeft;
			counter++;
		}

		if (showWindow) {

			text = part1 + part2 + part3 + part4 + part5 + part6 + part7 + part8 + part9 + part10 + part11;


			GUI.Box (new Rect (Screen.width / 2 - 150, 0, 300, 175), text, style);
			GUI.Label(new Rect (Screen.width / 2 - 150, 175, 200, 25), "Pipe Location");
			value = GUI.TextField (new Rect ((Screen.width / 2 - 150) + 85, 175, 15, 25), value, 1);
			//GUI.Label(new Rect (Screen.width / 2 - 150, 250, 200, 25), "Change Devil Text");

			//part3_val = int.Parse((System.String) value); 
			if (value.Equals ("1") || value.Equals ("2") || value.Equals ("3"))
				part3 = value;
			else
				part3 = "1"; 

			if (devil_text) {
				devil_string = "Remove Devil Text";
				part5 = "      poison_gas = true;";
			}
			else {
				devil_string = "Add Devil Text";
				part5 = "";
			}

			if (panel_text) {
				panel_string = "Remove Panel Text";
				part8 = "      door_open = true;";
			} 
			else {
				panel_string = "Add Panel Text";
				part8 = "";
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 150, 200, 200, 25), devil_string)) 
				devil_text = !devil_text;
					
			//GUI.Label(new Rect (Screen.width / 2 - 150, 300, 200, 25), "Change Panel Text");

			if (GUI.Button (new Rect (Screen.width / 2 - 150, 225, 200, 25), panel_string)) 
				panel_text = !panel_text;
		}
	}

	// Update is called once per frame
	void Update () {
		if (health == 0)
			SceneManager.LoadScene("GameOver");

		if (Input.GetKeyDown (KeyCode.H) && !showWindow && !ballScript.ballMoving && !ballScript.devil && !ballScript.panel)
		{
			movement = !movement;
			help.helpScreen ();
		}



		if (!showWindow && movement) {
			if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow)) && transform.position.x > -8f)
			{
				transform.position = new Vector3 (transform.position.x - .1f, transform.position.y, transform.position.z);
			} 
			else if ((Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKey (KeyCode.RightArrow)) && transform.position.x < 8f)
			{
				transform.position = new Vector3 (transform.position.x + .1f, transform.position.y, transform.position.z);
			}
		}

		if (value.Equals("2"))
		{
			pipe.transform.position = new Vector3 (pipe.transform.position.x, -2.25f, pipe.transform.position.z);
			ball.transform.position = new Vector3 (ball.transform.position.x, -2.25f, ball.transform.position.z);
		}
		else if (value.Equals("3"))
		{
			pipe.transform.position = new Vector3 (pipe.transform.position.x, -4f, pipe.transform.position.z);
			ball.transform.position = new Vector3 (ball.transform.position.x, -4f, ball.transform.position.z);
		}
		else
		{
			pipe.transform.position = new Vector3 (pipe.transform.position.x, -0.17f, pipe.transform.position.z);
			ball.transform.position = new Vector3 (ball.transform.position.x, -0.17f, ball.transform.position.z);
		}

		if (ballScript.poison && movement)
		{
			if (time < 5f)
				time += Time.deltaTime;
			else 
			{
				healthDecrease ();
				time = 0.0f;
			}
				
		}
			
	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "Monitor" && this.gameObject.tag == "Aliah") 
		{
			
			if(Input.GetKeyDown(KeyCode.M) && !ballScript.ballMoving && !ballScript.devil && !ballScript.panel && !help.helpOpen)
			{
				showWindow = !showWindow;
				if (!showWindow) 
				{
					black_sr.sortingOrder = -5;
					ballScript.ballMoving = true;
				} 
				else 
				{
					black_sr.sortingOrder = 5;
				}
			}
		}
		if (other.gameObject.tag == "Door" && this.gameObject.tag == "Aliah") 
		{

			if(ballScript.door_open)
			{
				SceneManager.LoadScene("Victory");
			}
		}
			
	}

	private void healthDecrease()
	{
		SpriteRenderer sprite = null;

		aud.PlayOneShot(ouch, 0.7F);
		switch (health)
		{
		case 1:
			sprite = heart1.GetComponent<SpriteRenderer>(); break;
		case 2:
			sprite = heart2.GetComponent<SpriteRenderer>(); break;
		default:
			sprite = heart3.GetComponent<SpriteRenderer>(); break;
		}

		sprite.sprite = heartempty;

		health--;

	}

}
