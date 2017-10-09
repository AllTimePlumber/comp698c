using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallOver : MonoBehaviour {

	public bool pause;
	private GameObject aliah;
	private Aliah_Overload script;
	// Use this for initialization
	void Awake () {
		aliah = GameObject.FindGameObjectWithTag ("Aliah");
		script = aliah.GetComponent<Aliah_Overload> ();
		pause = false;
		transform.localScale = new Vector3 (0.4f, 0.4f, 1.0f);
		transform.Rotate (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		pause = script.showWindow || !script.movement;

		if (!pause)
			transform.position = new Vector3 (transform.position.x, transform.position.y - .1f, transform.position.z);

		if (transform.position.y <= -8.0f)
			Destroy (this.gameObject);
	}
}
