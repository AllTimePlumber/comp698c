using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameOverScript : MonoBehaviour {

	public AudioClip gameover;

	private int currlevel = 0;
	private int counter = 0;
	private AudioSource aud;
	// Use this for initialization
	void Awake () {

		aud = GetComponent<AudioSource>();

		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			string level = "";

			StreamReader read_time = new StreamReader ("Assets/Resources/leveldata.txt");

			while (!read_time.EndOfStream) {
				level = read_time.ReadLine ();
				// Do Something with the input. 
			}

			read_time.Close (); 
			currlevel = int.Parse (level);

		}/*
		else
		{
			File.WriteAllText ("Assets/Resources/leveldata.txt", "1");
			currlevel = 1;
		}
		*/



	}

	// Update is called once per frame
	void Update () {
		if (counter == 0) 
		{
			aud.PlayOneShot(gameover, 0.7F);
			counter++;

		}

		if (Input.GetKeyDown (KeyCode.Return))
		{
			switch (currlevel) 
			{
			case 2: 
				SceneManager.LoadScene ("MainScene");
				break;
			case 3: 
				SceneManager.LoadScene ("IfElse");
				break;
			case 4: 
				SceneManager.LoadScene ("IntDouble");
				break;
			case 5: 
				SceneManager.LoadScene ("Overload");
				break;
			case 6: 
				SceneManager.LoadScene ("MunchTime");
				break;
			default: 
				SceneManager.LoadScene ("HelloWorld");
				break;
			}
		}
	}
}
