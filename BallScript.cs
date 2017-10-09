using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public bool ballMoving;
	public bool devil;
	public bool panel;
	public bool poison;
	public bool door_open;
	public GameObject panel_screen;
	public Sprite greenSprite;
	private SpriteRenderer panel_sr;
	public GameObject door;
	public Sprite doorSprite;
	private SpriteRenderer door_sr;
	private GameObject aliah;
	private Aliah_IfElse script;
	//private Aliah_IntDouble script2;
	private GameObject[] clouds;
	private SpriteRenderer cloud_sr;
	public bool upDown;

	// Use this for initialization
	void Start () {
		ballMoving = false;
		devil = false;
		panel = false;
		poison = false;
		door_open = false;
		aliah = GameObject.FindGameObjectWithTag("Aliah");
		script = aliah.GetComponent<Aliah_IfElse> ();
		//script2 = aliah.GetComponent<Aliah_IntDouble> ();
		panel_sr = panel_screen.GetComponent<SpriteRenderer> ();
		door_sr = door.GetComponent<SpriteRenderer> ();
		clouds = GameObject.FindGameObjectsWithTag ("Poison");
		upDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ballMoving) 
		{
			if (script != null)
				transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
			else   //IntDouble
				transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
		}
			
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("Help!");
		if (other.gameObject.tag == "Devil" && this.gameObject.tag == "Ball") {
			if (script.devil_text)
			{
				devil = true;
				poison = true;
				foreach (GameObject cloud in clouds) 
				{
					cloud_sr = cloud.GetComponent<SpriteRenderer> ();
					cloud_sr.enabled = true;
				}
			}
		} 
		else if (other.gameObject.tag == "Panel" && this.gameObject.tag == "Ball")
		{
			if (script != null)
			{
				if (script.panel_text) 
				{
					panel = true;
					door_open = true;
					panel_sr.sprite = greenSprite;
					door_sr.sprite = doorSprite;
				}
			} 
			else   //IntDouble
			{
				panel = true;
				door_open = true;
				panel_sr.sprite = greenSprite;
				door_sr.sprite = doorSprite;
			}
		}

		ballMoving = false;
		if (script != null)
			transform.position = new Vector3 (-8.3f, transform.position.y, transform.position.z);
		else   //IntDouble
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

	}


}
