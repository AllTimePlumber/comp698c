using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunchText : MonoBehaviour {

	public bool isCorrect;
	public string text;
	private TextMesh mesh;

	// Use this for initialization
	void Start () {
		mesh = this.gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		mesh.text = text;
	}
}
