using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIScript : MonoBehaviour {

	public bool showWindow = false;
	private GameObject scoreObj;
	private GameObject aliah;
	private AliahScript script;
	private Points scoreScript;
	bool score = false;
	GUIContent text;
	string value = "true";
	string enteredValue = "true";
	GUIStyle style;
	string part1 = "public static void main() {\n    start(game);\n\n";
	string part2 = "    while (";
	string part3 = ") {\n";
	string part4 = "        play(game);\n    }\n    end(game);\n}";

	private GameObject touchObj;
	private TouchMovement touchScript;


	int counter = 0;
	int helpCounter;
	int n = -1;
	public GameObject black;
	private SpriteRenderer black_sr;
	private HelpScript help;

	// Use this for initialization
	void Start () {

		helpCounter = 0;
		scoreObj = this.gameObject;
		scoreScript = scoreObj.GetComponent<Points> ();
		aliah = GameObject.FindGameObjectWithTag("Aliah");
		touchObj = GameObject.FindGameObjectWithTag("Pause");
		touchScript = touchObj.GetComponent<TouchMovement> ();
		script = aliah.GetComponent<AliahScript>();


		text = new GUIContent();
		text.text = part1 + part2 + value + part3 + part4;
		black_sr = black.GetComponent<SpriteRenderer> ();
		help = this.gameObject.GetComponent<HelpScript> ();
		//text.text = part1 + part2 + part3 + part4;
		help.helpScreen();

	}

	void OnGUI() {
		if (counter == 0) {
			style = GUI.skin.box;
			style.alignment = TextAnchor.UpperLeft;
			counter++;
		}
	

		if (showWindow) {
			GUI.Box (new Rect (Screen.width / 2 - 150, 0, 300, 150), text,style);
			value = GUI.TextField (new Rect (Screen.width / 2 - 150, 150, 50, 20), value, 4);
			if (GUI.Button (new Rect (Screen.width / 2 - 80, 150, 100, 20), "Enter Value")) 
			{
				if (value == "true") {
					enteredValue = "true";
					text.text = part1 + part2 + value + part3 + part4;
				} else if (int.TryParse (value, out n) && score && n > 0) {
					enteredValue = string.Copy (value);
					text.text = part1 + part2 + "score < " + value + part3 + part4;
				} else {
					enteredValue = "true";
					value = "true";
					text.text = part1 + part2 + value + part3 + part4;
				}

			}
			if (GUI.Button (new Rect (Screen.width / 2 + 40, 150, 100, 20), "Score")) 
			{
				if (!score) {
					value = "9999";
					text.text = part1 + part2 + "score < " + value + part3 + part4;
					score = true;
				} else {
					value = "true";
					text.text = part1 + part2 + value + part3 + part4;
					score = false;
				}
			}

		}


	}
	
	// Update is called once per frame
	void Update () {
		if (helpCounter == 0) 
		{
			touchScript.pauseTime (false);
			helpCounter++;
		}
		//counter++;
		if(Input.GetKeyDown(KeyCode.M) && !help.helpOpen)
		{
			if (showWindow) {
				showWindow = false;
			} 
			else {
				if (!script.pause)
					touchScript.pauseTime (false);
				//text.text = "butt \n" + counter;
				showWindow = true;

			}
			if (!showWindow) 
			{
				black_sr.sortingOrder = -5;
			} 
			else 
			{
				black_sr.sortingOrder = 5;
			}
		}
		if(Input.GetKeyDown(KeyCode.H) && !showWindow)
		{
			help.helpScreen ();
			if (help.helpOpen && !script.pause) 
			{
				touchScript.pauseTime (false);
			}
		}

		if (score && int.TryParse (enteredValue, out n)){
			if (scoreScript.points >= n) {
				//n  = SceneManager.GetActiveScene().buildIndex;
				SceneManager.LoadScene("Victory");
			}
		}
	}
}
