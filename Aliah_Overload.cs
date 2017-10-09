using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Aliah_Overload : MonoBehaviour {


	public bool showWindow = false;
	private AudioSource aud;
	public GameObject black;
	private SpriteRenderer black_sr;
	public GameObject row1;
	public GameObject row2;
	public GameObject row3;
	public GameObject fireball;

	string part1 = "public static void main(String[] args) {\n";
	string part2 = "   shoot_fireball(";
	string part3 = "'T'";
	string part4 = ");\n}\n\n";
	string part5 = "shoot_fireball(int x){\n";
	string part6 = "   wait_seconds((double) x);\n";
	string part7 = "   fireball();\n"; 
	string part8 = "}\n\n";
	string part9 = "shoot_fireball(char x){\n";
	string part10 ="   if (!x.equals('F')){\n";
	string part11 ="      wait_seconds(0.2);\n";
	string part12 ="      fireball();\n";
	string part13 ="   }\n}";

	string text;

	int counter = 0;
	GUIStyle style;
	string value = "";

	private int health;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public Sprite heartempty;
	public AudioClip ouch;
	private float time;

	private HelpScript help;
	public bool movement;

	private float delay;

	// Use this for initialization
	void Awake() {

		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 5;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();
		}

		delay = 0.2f;
		value = "T";
		aud = GetComponent<AudioSource>();
		health = 1;
		time = 0.0f;
		black_sr = black.GetComponent<SpriteRenderer> ();


	}

	void Start(){

		help = this.gameObject.GetComponent<HelpScript> ();
		movement = false;
		help.helpScreen ();

	}

	void OnGUI() {
		int i = 0;


		if (counter == 0) {
			style = GUI.skin.box;
			style.alignment = TextAnchor.UpperLeft;
			counter++;
		}

		if (showWindow) {

			text = part1 + part2 + part3 + part4 + part5 + part6 + part7 + part8 + part9 + part10 + part11 + part12 + part13;


			GUI.Box (new Rect (Screen.width / 2 - 150, 0, 300, 300), text, style);
			GUI.Label(new Rect (Screen.width / 2 - 150, 250, 200, 25), "Input");
			value = GUI.TextField (new Rect ((Screen.width / 2 - 150) + 85, 250, 15, 25), value, 1);
			//GUI.Label(new Rect (Screen.width / 2 - 150, 250, 200, 25), "Change Devil Text");

			/*
			if (GUI.Button (new Rect (Screen.width / 2 - 150, 200, 200, 25), devil_string)) 
				devil_text = !devil_text;

			//GUI.Label(new Rect (Screen.width / 2 - 150, 300, 200, 25), "Change Panel Text");

			if (GUI.Button (new Rect (Screen.width / 2 - 150, 225, 200, 25), panel_string)) 
				panel_text = !panel_text;*/
		}

		bool result = int.TryParse (value, out i);
		if (result) 
		{
			delay = (float)i;
			part3 = value;
		}
		else 
		{
			if (value.Equals ("F"))
				delay = 8000000f;
			else
				delay = 0.2f;
			if (value.Equals (""))
				part3 = "'T'";
			else
				part3 = "'" + value + "'";
		}

	}

	// Update is called once per frame
	void Update () {
		if (health <= 0)
			SceneManager.LoadScene("GameOver");

		if (Input.GetKeyDown (KeyCode.H) && !showWindow)
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

		if (!showWindow && movement)
			time += Time.deltaTime;
		if (time >= delay) 
		{
			
			SpawnScript spawn = row1.GetComponent<SpawnScript> ();
			spawn.Spawn (fireball);
			spawn = row2.GetComponent<SpawnScript> ();
			spawn.Spawn (fireball);
			spawn = row3.GetComponent<SpawnScript> ();
			spawn.Spawn (fireball);
			time = 0.0f;
		}
			

	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.tag == "Monitor" && this.gameObject.tag == "Aliah") 
		{

			if(Input.GetKeyDown(KeyCode.M) && !help.helpOpen)
			{
				showWindow = !showWindow;
				if (!showWindow) 
				{
					black_sr.sortingOrder = -5;
				} 
				else 
				{
					black_sr.sortingOrder = 5;
				}
			}
		}
		else if (other.gameObject.tag == "Door" && this.gameObject.tag == "Aliah") 
		{
			SceneManager.LoadScene("Victory");
		}
		else if (other.gameObject.tag == "Fire" && this.gameObject.tag == "Aliah")
		{
			Destroy (other.gameObject);
			healthDecrease ();
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
