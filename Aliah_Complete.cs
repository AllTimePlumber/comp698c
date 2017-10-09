using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Aliah_Complete : MonoBehaviour {

	public AudioClip victory;

	private int counter = 0;
	private AudioSource aud;
	// Use this for initialization
	void Awake () {

		aud = GetComponent<AudioSource>();

		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write ("1");
			write_time.Close ();

		}/*
		else
		{
			File.WriteAllText ("Assets/Resources/leveldata.txt", "1");
			currlevel = 1;
		}
		*/



	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (counter == 0) 
		{
			aud.PlayOneShot(victory, 0.7F);
			counter++;

		}
			
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow)) && transform.position.x > -8f) 
		{
			transform.position = new Vector3 (transform.position.x - .1f, transform.position.y, transform.position.z);
		} 
		else if ((Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKey (KeyCode.RightArrow)) && transform.position.x < 8f) 
		{
			transform.position = new Vector3 (transform.position.x + .1f, transform.position.y, transform.position.z);
		}

		if (Input.GetKeyDown (KeyCode.Return))
			SceneManager.LoadScene("Title");
	}

}
