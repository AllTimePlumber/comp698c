using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

class Answer{

	public bool isCorrect;
	public string text;
	public Answer(bool correct, string s)
	{
		isCorrect = correct;
		text = s;
	}
};

public class Aliah_Munch : MonoBehaviour {

	private AudioSource aud;
	private bool correctExists;

	private int health;
	private GUIStyle style;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public GameObject munch01;
	public GameObject munch02;
	public GameObject munch03;
	public GameObject munch04;
	public GameObject munch05;
	public GameObject munch06;
	public GameObject munch07;
	public GameObject munch08;
	public GameObject munch09;
	public GameObject munch10;
	public GameObject munch11;
	public GameObject munch12;
	public GameObject munch13;
	public GameObject munch14;
	public GameObject munch15;
	public GameObject munch16;
	public GameObject title;
	public GameObject row1;
	public GameObject row2;
	public GameObject row3;
	public GameObject row4;
	public GameObject fireball;
	private MunchText munchScript01;
	private MunchText munchScript02;
	private MunchText munchScript03;
	private MunchText munchScript04;
	private MunchText munchScript05;
	private MunchText munchScript06;
	private MunchText munchScript07;
	private MunchText munchScript08;
	private MunchText munchScript09;
	private MunchText munchScript10;
	private MunchText munchScript11;
	private MunchText munchScript12;
	private MunchText munchScript13;
	private MunchText munchScript14;
	private MunchText munchScript15;
	private MunchText munchScript16;
	public Sprite heartempty;
	public AudioClip ouch;
	private GameObject[] objArr;
	private MunchText[] scriptArr;
	private int level;
	private List<Answer> level1,level2,level3;
	private TextMesh titleMesh;
	private float time;
	public bool pause;
	private HelpScript help;

	void Shuffle(List<Answer> list)
	{
		int n = list.Count;
		while (n > 1){
			n--;
			int k = Random.Range(0,n);
			Answer value = list[k];
			list[k] = list[n];
			list[n] = value;
		}

	}

	// Use this for initialization
	void Awake () {

		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 6;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();
		}
			
		time = 0.0f;
		int l = Random.Range (3, 13);
		int m, n;
		double p;
		 
		level1 = new List<Answer> ();
		level2 = new List<Answer> ();
		level3 = new List<Answer> ();

		titleMesh = title.GetComponentInChildren<TextMesh> ();
		titleMesh.text = "Select the integers";

		for (int i = 0; i < 16; i++)
		{
			if (l > 0) 
			{ 
				m = Random.Range (1, 100);
				level1.Add (new Answer (true, m.ToString()));
				l--;
			} 
			else 
			{
				m = Random.Range (1, 9);
				n = Random.Range (0, 99);
				p = n + (m / 10.0);
				level1.Add (new Answer (false, p.ToString()));
			}
		}

		Shuffle (level1);

		level2.Add(new Answer(false, "public"));
		level2.Add(new Answer(false, "private"));
		level2.Add(new Answer(false, "static"));
		level2.Add(new Answer(true, "for"));
		level2.Add(new Answer(true, "do"));
		level2.Add(new Answer(true, "while"));
		level2.Add(new Answer(true, "break"));
		level2.Add(new Answer(true, "continue"));
		level2.Add(new Answer(false, "class"));
		level2.Add(new Answer(false, "bool"));
		level2.Add(new Answer(false, "int"));
		level2.Add(new Answer(false, "double"));
		level2.Add(new Answer(false, "long"));
		level2.Add(new Answer(false, "end"));
		level2.Add(new Answer(false, "start"));
		level2.Add(new Answer(false, "void"));
		level3.Add(new Answer(true, "public"));
		level3.Add(new Answer(true, "private"));
		level3.Add(new Answer(true, "static"));
		level3.Add(new Answer(false, "for"));
		level3.Add(new Answer(false, "do"));
		level3.Add(new Answer(false, "while"));
		level3.Add(new Answer(false, "break"));
		level3.Add(new Answer(false, "continue"));
		level3.Add(new Answer(false, "class"));
		level3.Add(new Answer(true, "final"));
		level3.Add(new Answer(true, "abstract"));
		level3.Add(new Answer(true, "protected"));
		level3.Add(new Answer(true, "volatile"));
		level3.Add(new Answer(false, "end"));
		level3.Add(new Answer(false, "start"));
		level3.Add(new Answer(true, "synchronized"));

		level = 1;
		objArr = new GameObject[16];
		scriptArr = new MunchText[16];
		Shuffle (level2);
		Shuffle (level3);

		correctExists = false;

		munchScript01 = munch01.GetComponentInChildren<MunchText> ();
		munchScript02 = munch02.GetComponentInChildren<MunchText> ();
		munchScript03 = munch03.GetComponentInChildren<MunchText> ();
		munchScript04 = munch04.GetComponentInChildren<MunchText> ();
		munchScript05 = munch05.GetComponentInChildren<MunchText> ();
		munchScript06 = munch06.GetComponentInChildren<MunchText> ();
		munchScript07 = munch07.GetComponentInChildren<MunchText> ();
		munchScript08 = munch08.GetComponentInChildren<MunchText> ();
		munchScript09 = munch09.GetComponentInChildren<MunchText> ();
		munchScript10 = munch10.GetComponentInChildren<MunchText> ();
		munchScript11 = munch11.GetComponentInChildren<MunchText> ();
		munchScript12 = munch12.GetComponentInChildren<MunchText> ();
		munchScript13 = munch13.GetComponentInChildren<MunchText> ();
		munchScript14 = munch14.GetComponentInChildren<MunchText> ();
		munchScript15 = munch15.GetComponentInChildren<MunchText> ();
		munchScript16 = munch16.GetComponentInChildren<MunchText> ();

		objArr [0] = munch01;
		objArr [1] = munch02;
		objArr [2] = munch03;
		objArr [3] = munch04;
		objArr [4] = munch05;
		objArr [5] = munch06;
		objArr [6] = munch07;
		objArr [7] = munch08;
		objArr [8] = munch09;
		objArr [9] = munch10;
		objArr [10] = munch11;
		objArr [11] = munch12;
		objArr [12] = munch13;
		objArr [13] = munch14;
		objArr [14] = munch15;
		objArr [15] = munch16;

		scriptArr [0] = munchScript01;
		scriptArr [1] = munchScript02;
		scriptArr [2] = munchScript03;
		scriptArr [3] = munchScript04;
		scriptArr [4] = munchScript05;
		scriptArr [5] = munchScript06;
		scriptArr [6] = munchScript07;
		scriptArr [7] = munchScript08;
		scriptArr [8] = munchScript09;
		scriptArr [9] = munchScript10;
		scriptArr [10] = munchScript11;
		scriptArr [11] = munchScript12;
		scriptArr [12] = munchScript13;
		scriptArr [13] = munchScript14;
		scriptArr [14] = munchScript15;
		scriptArr [15] = munchScript16;

		for (int i = 0; i < 16; i++)
		{
			scriptArr [i].isCorrect = level1 [i].isCorrect;
			scriptArr [i].text = level1 [i].text;
		}


		health = 3;

		aud = GetComponent<AudioSource>();



	}
		

	void Start(){

		help = this.gameObject.GetComponent<HelpScript> ();
		pause = true;
		help.helpScreen ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.H))
		{
			pause = !pause;
			help.helpScreen ();
		}


		if (!pause)
			time += Time.deltaTime;
		if (time >= 10.0f) 
		{
			int j = Random.Range (1, 4);
			GameObject row;
			switch (j) 
			{
				case 1:
					row = row1;
					break;
				case 2:
					row = row2;
					break;
				case 3:
					row = row3;
					break;
				default:
					row = row4;
					break;
			}
			SpawnScript spawn = row.GetComponent<SpawnScript> ();
			spawn.Spawn (fireball);
			time = 0.0f;
		}

		correctExists = false;

		for (int i = 0; i < 16; i++) {
			correctExists = scriptArr [i].isCorrect;
			if (correctExists)
				break;
		}

		if (!correctExists) 
		{
			if (level == 1) 
			{
				level++;
				titleMesh.text = "Pick the terms that are for a loop";
				for (int i = 0; i < 16; i++)
				{
					scriptArr [i].isCorrect = level2 [i].isCorrect;
					scriptArr [i].text = level2 [i].text;
				}
			} 
			else if (level == 2) 
			{
				level++;
				titleMesh.text = "Pick the modifiers";
				for (int i = 0; i < 16; i++)
				{
					scriptArr [i].isCorrect = level3 [i].isCorrect;
					scriptArr [i].text = level3 [i].text;
				}
			} 
			else if (level == 3) 
			{
				SceneManager.LoadScene("GameComplete");
			}


		}


		if (health == 0)
			SceneManager.LoadScene("GameOver");
		if (!pause) 
		{
			if (transform.position.y < 3.0f && Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y + 2.3f, transform.position.z);

			} 
			else if (transform.position.y > -3.0f && Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y - 2.3f, transform.position.z);

			} 
			else if (transform.position.x > -4.0f && Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				transform.position = new Vector3 (transform.position.x - 3.1f, transform.position.y, transform.position.z);

			} 
			else if (transform.position.x < 4.0f && Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				transform.position = new Vector3 (transform.position.x + 3.1f, transform.position.y, transform.position.z);

			}
		}

	}

	void OnTriggerStay2D(Collider2D other) {

		if (!pause) 
		{
			if (other.gameObject.tag == "Panel" && this.gameObject.tag == "Aliah" && Input.GetKeyDown (KeyCode.Space)) 
			{
				///Debug.Log ("lll");
				GameObject panel = other.gameObject;
				MunchText text = panel.GetComponentInChildren<MunchText> ();
				if (text.text.Length > 0 && !text.isCorrect)
					healthDecrease ();
				text.text = "";
				text.isCorrect = false;
			}
			if (other.gameObject.tag == "Fire" && this.gameObject.tag == "Aliah")
			{
				Destroy (other.gameObject);
				healthDecrease ();
			}
		}


	}

	private void healthDecrease()
	{
		SpriteRenderer sprite = null;

		aud.PlayOneShot(ouch, 0.7F);
		switch (health)
		{
		case 1:
			sprite = heart1.GetComponent<SpriteRenderer>(); break;
		case 2:
			sprite = heart2.GetComponent<SpriteRenderer>(); break;
		default:
			sprite = heart3.GetComponent<SpriteRenderer>(); break;
		}

		sprite.sprite = heartempty;

		health--;

	}



}
	