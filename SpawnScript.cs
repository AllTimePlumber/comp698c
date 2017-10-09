using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	//public GameObject Aliah;

	// Use this for initialization
	void Start () {
		//Spawn ();
	}

	public void Spawn(GameObject obj)
	{
		//AliahScript script = (AliahScript)Aliah.GetComponent (typeof(AliahScript));
		Instantiate (obj, transform.position, Quaternion.identity);
		//Invoke ("Spawn", 2.5f - (script.movement * 20));
	}

}
