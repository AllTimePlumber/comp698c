using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject Aliah;
	public AudioClip undisclosed;
	public AudioClip star;
	private AudioSource aud;
	private float music_time;
	private AliahScript script;
	
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource>();
		music_time = 0.0f;
		script = (AliahScript)Aliah.GetComponent (typeof(AliahScript));
	}
	
	// Update is called once per frame
	void Update () {

		if (script.init) 
		{
			transform.position = new Vector3 (transform.position.x + 7.5f, transform.position.y, transform.position.z);
		}
		else 
		{
			transform.position = new Vector3(transform.position.x + script.movement, transform.position.y, transform.position.z);
		}
		

		
	}

	public void Star()
	{
		music_time = aud.time;
		aud.clip = star;
		aud.time = 0.0f;
		aud.Play ();
	}

	public void Undisclosed()
	{
		aud.clip = undisclosed;
		aud.time = music_time;
		aud.loop = true;
		aud.Play ();
	}
}
