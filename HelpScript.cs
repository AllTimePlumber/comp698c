using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour {

	public GameObject black;
	private SpriteRenderer black_sr;
	public bool helpOpen;
	private string text;
	GUIStyle style;
	private int counter;

	// Use this for initialization
	void Awake () {
		counter = 0;
		text = "";
		helpOpen = false;
		black_sr = black.GetComponent<SpriteRenderer> ();
	}

	void OnGUI() {

		if (helpOpen) {

			if (counter == 0)
			{
				style = GUI.skin.box;
				style.alignment = TextAnchor.UpperLeft;
				counter++;
			}

			if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("HelloWorld")) {

				text = "This is a simple beginner level about the \"Hello World\" program.\n\n";
				text = text + "Use the mouse to select the correct answer.\n\n";
				text = text + "You will lose a unit of health for an incorrect answer\n\n";
				text = text + "Use the arrow keys to move. Press 'M' when on top of the monitor to access it.\n";
				text = text + "Press 'H' to close/reopen this page.";

			}
			else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainScene")) {

				text = "This level will test your skills on loops.\n\n";
				text = text + "Avoid the brick walls and collect coins to gain points.\n";
				text = text + "However, the game will continue forever unless you modify the code\n";
				text = text + "Press the score button to change the loop conditions\n";
				text = text + "Press Enter value to insert the value into the code\n";
				text = text + "Note: You can only enter a value between 1-9999\n";
				text = text + "Press the up arrow to move up.\n";
				text = text + "Press the down arrow to move down.\n";
				text = text + "Press the pause button to pause. Press it again to resume.\n";
				text = text + "Press 'M' at anytime to access the code.\n";
				text = text + "Click on an open space and Press 'M' to remove the code window.\n";
				text = text + "Press 'H' to close/reopen this page.";

			}
			else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("IfElse")) {

				text = "This level will test your knowledge of conditional statements.\n\n";
				text = text + "The goal is to hit the red panel to open the door\n";
				text = text + "Once looking at the code, press the buttons to see what they change\n";
				text = text + "The only valid values for the pipe location are 1-3\n";
				text = text + "The pipe will automatically shoot once you exit the monitor window\n";
				text = text + "Beware of hitting the devil under certain conditions\n";
				text = text + "\nUse the arrow keys to move. Press 'M' when on top of the monitor to access it.\n";
				text = text + "Click on an open space and Press 'M' to remove the code window.\n";
				text = text + "Press 'H' to close/reopen this page.";
			}
			else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("IntDouble")) {

				text = "This level will show the differences between integers and doubles.\n\n";
				text = text + "The goal is to hit the red panel to open the door\n";
				text = text + "Once looking at the code, press the button to see what is changed\n";
				text = text + "The only valid values for the pipe location are between 0-4\n";
				text = text + "The pipe will automatically shoot once you exit the monitor window\n";
				text = text + "\nUse the arrow keys to move. Press 'M' when on top of the monitor to access it.\n";
				text = text + "Click on an open space and Press 'M' to remove the code window.\n";
				text = text + "Press 'H' to close/reopen this page.";
			}
			else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Overload")) {

				text = "This level will show how overloaded methods are used.\n\n";
				text = text + "The goal is to get to the open door on the other side\n";
				text = text + "Once looking at the code, you can enter any single character or integer value\n";
				text = text + "Beware: You only have 1 unit of health\n";
				text = text + "Note: There are multiple ways to complete this level\n";
				text = text + "\nUse the arrow keys to move. Press 'M' when on top of the monitor to access it.\n";
				text = text + "Click on an open space and Press 'M' to remove the code window.\n";
				text = text + "Press 'H' to close/reopen this page.";
			}
			else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MunchTime")) {

				text = "The final level will test your overall knowledge.\n\n";
				text = text + "The goal is to correctly select all answers for 3 questions\n";
				text = text + "Go to a box and press the spacebar if you believe the answer is correct.\n";
				text = text + "You will lose 1 unit of health if you choose incorrectly.\n";
				text = text + "Beware: A fireball will shoot from the left side at times\n";
				text = text + "Note: There is not a code window for this level\n";
				text = text + "\nUse the arrow keys to move.\n";
				text = text + "Press 'H' to close/reopen this page.";
			}

			//x-coor, y-coor, width, height
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width/3), 0, (Screen.width / 2) + (Screen.width/3), Screen.height), text, style);


		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void helpScreen(){
		helpOpen = !helpOpen;
		if (!helpOpen) 
		{
			black_sr.sortingOrder = -50;
		} 
		else 
		{
			black_sr.sortingOrder = 5;
		}
	}
}
