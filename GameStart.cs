using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameStart : MonoBehaviour {

	private int currlevel = 0;
	// Use this for initialization
	void Awake () {

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
		}
		else
		{
			if (!Directory.Exists("Assets/Resources/"))
			{
				Directory.CreateDirectory("Assets/Resources/");
			}
			File.WriteAllText ("Assets/Resources/leveldata.txt", "1");
			currlevel = 1;
		}

		if (currlevel < 1 || currlevel > 6) {
			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write ("1");
			currlevel = 1;
			write_time.Close ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene ("Transition");
		}
	}
}
