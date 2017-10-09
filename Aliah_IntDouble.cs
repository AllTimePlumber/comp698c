using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


public class Aliah_IntDouble : MonoBehaviour {

	public bool showWindow = false;
	private AudioSource aud;
	private GameObject ball;
	private BallScript ballScript;
	public GameObject pipe;
	public GameObject black;
	private SpriteRenderer black_sr;

	string part1 = "public static void main(String[] args) {\n   ";
	string part2 = "int";
	string part3 =	" pipe_location = ";
	string part4 = "0";
	string part5 = ";\n   move_pipe(pipe_location);\n";
	string part6 = "   shoot_ball();\n}";

	string text;

	int counter = 0;
	GUIStyle style;
	string value = " ";

	public bool isDouble_text;

	string isDouble_string;

	float part4_val;

	private int health;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public Sprite heartempty;
	public AudioClip ouch;
	private float time;
	private bool parse;
	private float move;
	private HelpScript help;
	private bool movement;

	void Awake(){
		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 4;

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
		isDouble_text = false;
		time = 0.0f;
		black_sr = black.GetComponent<SpriteRenderer> ();
		parse = false;
		move = 0.0f;
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

			text = part1 + part2 + part3 + part4 + part5 + part6;

			//x-coor, y-coor, width, height
			GUI.Box (new Rect (Screen.width / 2 - 150, 0, 300, 100), text, style);
			GUI.Label(new Rect (Screen.width / 2 - 150, 100, 200, 25), "Pipe Location");

		
			if (isDouble_text) {
				value = GUI.TextField (new Rect ((Screen.width / 2 - 150) + 85, 100, 45, 25), value, 3);
				isDouble_string = "Change to Int";
				part2 = "double";
			}
			else {
				value = GUI.TextField (new Rect ((Screen.width / 2 - 150) + 85, 100, 15, 25), value, 1);
				isDouble_string = "Change to Double";
				part2 = "int";
			}
				
			parse = float.TryParse(value, out part4_val); 
			if (parse && part4_val >= 0 && part4_val <= 4)
				part4 = value;
			else
				part4 = "0";
			

		
			if (GUI.Button (new Rect (Screen.width / 2 - 150, 125, 200, 25), isDouble_string)) 
				isDouble_text = !isDouble_text;




		}
	}

	// Update is called once per frame
	void Update () {
		if (health == 0)
			SceneManager.LoadScene("GameOver");

		if (Input.GetKeyDown (KeyCode.H) && !showWindow && !ballScript.ballMoving && !ballScript.panel)
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
		else
		{
			move = -8.3f + (part4_val * 4.15f);
			pipe.transform.position = new Vector3 (move, pipe.transform.position.y, pipe.transform.position.z);
			ball.transform.position = new Vector3 (move, ball.transform.position.y, ball.transform.position.z);
		}


		if (ballScript.poison)
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

			if(Input.GetKeyDown(KeyCode.M) && !ballScript.ballMoving && !ballScript.panel && !help.helpOpen)
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
