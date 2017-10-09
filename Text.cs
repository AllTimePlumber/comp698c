using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	public int points;
	// Use this for initialization
	void Start () {
		points = 0;
	}
	/*
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	*/
	// Update is called once per frame
	void Update () {

		this.gameObject.GetComponent<GUIText>().fontSize = (int)(Screen.currentResolution.height * 0.04f);
	}
}
