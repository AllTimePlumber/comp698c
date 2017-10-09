using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	int i;
	// Use this for initialization
	void Start () {
		i  = SceneManager.GetActiveScene().buildIndex;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (this.gameObject.tag == "GameOver")
				SceneManager.LoadScene (0);
			else
				SceneManager.LoadScene (i + 1);
		}
	}
}
