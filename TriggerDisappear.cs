using UnityEngine;
using System.Collections;

public class TriggerDisappear : MonoBehaviour {

	private AliahScript script;
	// Use this for initialization
	void Start () {

		GameObject aliah = GameObject.FindWithTag ("Aliah");
		script = (AliahScript)aliah.GetComponent (typeof(AliahScript));
		if (this.gameObject.tag != "Wall")
			transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!script.pause)
		{
			if (script.aliahCurrentX - this.gameObject.transform.position.x >= 10f)
				Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Aliah" && this.gameObject.tag == "Wall") 
		{
			AliahScript aliah = other.gameObject.GetComponent<AliahScript>(); 
			aliah.healthDecrease();
			Destroy (this.gameObject);
		}
		else if (other.gameObject.tag == "Aliah" && this.gameObject.tag == "Mushroom") 
		{
			AliahScript aliah = other.gameObject.GetComponent<AliahScript>(); 
			aliah.healthIncrease();
			Destroy (this.gameObject);
		}
		else if (other.gameObject.tag == "Aliah" && this.gameObject.tag == "Money") 
		{
			AliahScript aliah = other.gameObject.GetComponent<AliahScript>(); 
			aliah.scoreIncrease();
			Destroy (this.gameObject);
		}
		else if (other.gameObject.tag == "Aliah" && this.gameObject.tag == "Star") 
		{
			AliahScript aliah = other.gameObject.GetComponent<AliahScript>(); 
			aliah.invincibleTime();
			Destroy (this.gameObject);
		}
	}
}
