using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class TransitionScript : MonoBehaviour {

	public Sprite dungeon1;
	public Sprite dungeon2;
	public Sprite dungeon3;
	public Sprite dungeon4;
	public Sprite dungeon5;
	public Sprite dungeon6;
	private SpriteRenderer ren;
	private int currlevel = 0;

	void Awake () {

		ren = GetComponent<SpriteRenderer>();

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
			
		switch (currlevel) 
		{
		case 2: 
			ren.sprite = dungeon2;
			break;
		case 3: 
			ren.sprite = dungeon3;
			break;
		case 4: 
			ren.sprite = dungeon4;
			break;
		case 5: 
			ren.sprite = dungeon5;
			break;
		case 6: 
			ren.sprite = dungeon6;
			break;
		default: 
			ren.sprite = dungeon1;
			break;
		}
			

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
