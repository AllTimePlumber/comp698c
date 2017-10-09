using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public int points;
	private TextMesh text;

	// Use this for initialization
	void Awake () {
		points = 0;
		text = this.gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + points.ToString ();
	}
}
