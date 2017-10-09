using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class AliahScript : MonoBehaviour {

	private int height;
	public bool pause;
	public int health;
	private SpriteRenderer aliahSprite;
	public float movement;
	private float curr_move;
	public GameObject heart1; 
	public GameObject heart2;
	public GameObject heart3;
	public GameObject score;
	public Sprite heartfull;
	public Sprite heartempty;
	public Sprite regAliah;
	public Sprite starAliah;
	public Sprite pauseButton;
	public Sprite playButton;
	public Sprite tomato;
	private bool invincible;
	public bool tqInvincible;
	public AudioClip mushroom;
	public AudioClip ouch;
	public AudioClip coin;
	public AudioClip pauseSound;
	private AudioSource aud;
	public GameObject cam;
	private CameraScript camScript;
	private Points scoreScript;
	private float aliahmove;
	public float aliahCurrentX;
	private float aliahInvincible;
	public bool init;
	private BoxCollider2D box;

	void Awake(){
		if (File.Exists ("Assets/Resources/leveldata.txt")) 
		{
			int currlevel = 2;

			StreamWriter write_time = new StreamWriter("Assets/Resources/leveldata.txt");
			write_time.Write (currlevel.ToString());
			write_time.Close ();
		}
	}

	// Use this for initialization
	void Start () {
		movement = 0.05f;
		aliahSprite = this.gameObject.GetComponent<SpriteRenderer>();
		camScript = cam.GetComponent<CameraScript>(); 
		scoreScript = score.GetComponent<Points> (); 
		height = 2;
		health = 3;
		aud = GetComponent<AudioSource>();
		pause = false;
		aliahmove = this.gameObject.transform.position.x;
		aliahCurrentX = this.gameObject.transform.position.x;
		aliahInvincible = this.gameObject.transform.position.x;
		init = true;
		box = this.gameObject.GetComponent<BoxCollider2D>();

	}

	// Update is called once per frame
	void Update () {



		aliahCurrentX = this.gameObject.transform.position.x;

		if (health == 0) 
		{
			health = 3;
			int i  = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene("GameOver");
		}

		if (!pause) 
		{
			if (movement < 0.09f && ((aliahCurrentX - aliahmove) >= (movement * 2000f)))
			{
				aliahmove = aliahCurrentX;
				movement += 0.01f;
			}
		}

		if (tqInvincible)
		{
			if (!pause) 
			{
				if ((aliahCurrentX - aliahInvincible) >= (movement * 625f))
				{
					aliahSprite.sprite = regAliah;
					camScript.Undisclosed ();
					box.size = new Vector2(1f, box.size.y);
					tqInvincible = false;
				}
			}
		}
		else if (invincible)
		{
			if (!pause) 
			{
				if ((aliahCurrentX - aliahInvincible) >= (movement * 125f)) // movement * 125f = 2 seconds
				{
					aliahSprite.sprite = regAliah;
					invincible = false;
				}
			}
		}

		if (init) 
		{
			transform.position = new Vector3 (transform.position.x + 7.5f, transform.position.y, transform.position.z);
			scoreScript.points = 0;
			score.GetComponent<TextMesh>().text = "Score: " + scoreScript.points.ToString();
			init = false;
		}
		else 
		{
			transform.position = new Vector3 (transform.position.x + movement, transform.position.y, transform.position.z);
		}
	}

	public void moveAliah(int value)
	{
		if (value == 1) 
			transform.position = new Vector3(transform.position.x, 3.137929f, transform.position.z);
		else if (value == 2)
			transform.position = new Vector3(transform.position.x, 0.137929f, transform.position.z);
		else
			transform.position = new Vector3(transform.position.x, -3.137929f, transform.position.z);

	}

	public void healthDecrease()
	{
		SpriteRenderer sprite = null;

		if (!invincible && !tqInvincible)
		{
			if (health > 0)
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
			invincible = true;
			aliahSprite.sprite = starAliah;
			aliahInvincible = aliahCurrentX;
		}
	}

	public void healthIncrease()
	{
		SpriteRenderer sprite = null;
		
		if (health < 3)
		{
			aud.PlayOneShot(mushroom, 0.7F);

			if (health == 1)
				sprite = heart2.GetComponent<SpriteRenderer>();
			else
				sprite = heart3.GetComponent<SpriteRenderer>();
			
			sprite.sprite = heartfull;
			
			health++;
		}	
	}

	public void scoreIncrease()
	{
		aud.PlayOneShot(coin, 0.7F);
		scoreScript.points++;
		score.GetComponent<TextMesh>().text = "Score: " + scoreScript.points.ToString();
	}

	public void invincibleTime()
	{
		tqInvincible = true;
		box.size = new Vector2(1.5f, box.size.y);
		invincible = false;
		camScript.Star ();
		aliahSprite.sprite = tomato;
		aliahInvincible = aliahCurrentX;
	}

	public void moveDown()
	{
		if (height > 0) {
			
			height--;
			transform.position = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
			
		}

	}

	public void moveUp()
	{
		if (height < 2) {
			
			height++;
			transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
			
		}

	}

	public void pauseGame(bool playAudio)
	{
		transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
		if (playAudio) 
		{
			aud.PlayOneShot (pauseSound, 0.7F);
		}
		pause = true;
		curr_move = movement;
		movement = 0.0f;
		//camScript.GetComponent<AudioSource>().Pause ();
	}
	
	public void unPauseGame(bool playAudio)
	{
		if (playAudio) 
		{
			aud.PlayOneShot (pauseSound, 0.7F);
		}
		pause = false;
		movement = curr_move;
		transform.position = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
		//camScript.GetComponent<AudioSource>().Play ();
	}


	

}
