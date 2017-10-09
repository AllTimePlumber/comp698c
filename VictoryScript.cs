using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class VictoryScript : MonoBehaviour {

	public AudioClip victory;

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

			currlevel++;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();

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
			aud.PlayOneShot(victory, 0.7F);
			counter++;

		}



		if (Input.GetKeyDown (KeyCode.Return))
		{
			SceneManager.LoadScene ("Transition");
		}
	}
}
