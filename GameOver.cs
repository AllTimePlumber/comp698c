using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject text;

	// Use this for initialization
	void Start () {
		GameObject score = GameObject.Find("Score");
		int points = 0;
		if (score != null) 
		{
			Text script = score.GetComponent<Text> (); 
			points = script.points;
			Destroy (score);
		}

		text.GetComponent<GUIText>().text = "Score: " + points.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter))
			SceneManager.LoadScene(0);
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit();
		*/
	}
}
