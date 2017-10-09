using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour {

	private GameObject aliah;
	private Aliah_Munch munchScript;
	// Use this for initialization
	void Awake () {
		aliah = GameObject.FindWithTag ("Aliah");
		munchScript = aliah.GetComponent<Aliah_Munch>();
		transform.localScale = new Vector3 (0.4f, 0.4f, 1.0f);
		transform.Rotate (0, 0, 90);
	}
	
	// Update is called once per frame
	void Update () {

		if (!munchScript.pause)
			transform.position = new Vector3 (transform.position.x + .1f, transform.position.y, transform.position.z);

		if (transform.position.x >= 15.0f)
			Destroy (this.gameObject);
	}
}
