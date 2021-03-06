using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Aliah_HelloWorld : MonoBehaviour {

	private bool showWindow = false;
	private int health;
	private AudioSource aud;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public Sprite heartempty;
	public AudioClip ouch;
	private int points;
	public GameObject black;
	private SpriteRenderer black_sr;
	private HelpScript help;
	private bool movement;

	string part1 = "<blank1> <blank2> <blank3> main(String[] args) {\n";
	string part2 = "   //Prints \"Hello, World\"\n";
	string part3 = "   System.<blank4>.<blank5>(\"Hello World\");\n}\n\n";
	//string part4 = "       play(game);\n    }\n    end(game);\n}";

	string part5 = "What should go in <blank1> if we want to indicate\nthat this method can be called from any object?\n";

	string text;

	int counter = 0;
	GUIStyle style;

	void Awake(){
		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 1;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();
		}
	}

	// Use this for initialization
	void Start () {

		aud = GetComponent<AudioSource>();
		health = 3;
		text = part1 + part2 + part3 + part5;
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

			GUI.Box (new Rect (Screen.width / 2 - 150, 0, 300, 150), text, style);
			if (points == 0)
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "public")) 
				{
					points++;
					changeText ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 170, 100, 20), "private"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 190, 100, 20), "protected"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 210, 100, 20), "abstract"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 230, 100, 20), "interface"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
			}
			else if (points == 1)
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "loose")) 
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 170, 100, 20), "access"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 190, 100, 20), "noinstance"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 210, 100, 20), "static"))
				{
					points++;
					changeText ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 230, 100, 20), "fullaccess"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
			}
			else if (points == 2)
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "double")) 
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 170, 100, 20), "int"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 190, 100, 20), "none"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 210, 100, 20), "void"))
				{
					points++;
					changeText ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 230, 100, 20), "float"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
			}
			else if (points == 3)
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "err")) 
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 170, 100, 20), "out"))
				{
					points++;
					changeText ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 190, 100, 20), "in"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 210, 100, 20), "output"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 230, 100, 20), "toscreen"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
			}
			else if (points == 4)
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "print")) 
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 170, 100, 20), "printnewline"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 190, 100, 20), "printnow"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 210, 100, 20), "printtoscreen"))
				{
					healthDecrease ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 80, 230, 100, 20), "println"))
				{
					points++;
					changeText ();
					showWindow = false;
					black_sr.sortingOrder = -5;
				}
			}
		}
	}

	private void changeText()
	{
		if (points == 1) {
			part1 = "public <blank2> <blank3> main(String[] args) {\n";
			part5 = "What should go in <blank2> if we want to indicate\nthat this method can be accessed without creating an\ninstance of the class?\n";
			text = part1 + part2 + part3 + part5;
		} 
		else if (points == 2) {
			part1 = "public static <blank3> main(String[] args) {\n";
			part5 = "What should go in <blank3> if we want to indicate\nthat there is no return type?\n";
			text = part1 + part2 + part3 + part5;
		}
		else if (points == 3) {
			part1 = "public static void main(String[] args) {\n";
			part5 = "What should go in <blank4> if we want to use an output stream?\n";
			text = part1 + part2 + part3 + part5;
		}
		else if (points == 4) {
			part3 = "   System.out.<blank5>(\"Hello World\");\n}\n\n";
			part5 = "What should go in <blank5> if we want to print \n\"Hello World\" on a new line?\n";
			text = part1 + part2 + part3 + part5;
		}
		else if (points == 5) {
			part3 = "   System.out.println(\"Hello World\");\n}\n\n";
			part5 = "";
			text = part1 + part2 + part3 + part5;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.H) && !showWindow)
		{
			movement = !movement;
			help.helpScreen ();
		}

		if (points == 5) 
		{
			SceneManager.LoadScene("Victory");

		}
		if (health == 0) 
		{
			SceneManager.LoadScene("GameOver");
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
