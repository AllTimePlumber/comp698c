using UnityEngine;
using System.Collections;

public class CreateObjects : MonoBehaviour {

	public GameObject Aliah;
	public GameObject Row1;
	public GameObject Row2;
	public GameObject Row3;
	public GameObject LargeWall;
	//public GameObject Mushroom;
	public GameObject Coin;
	//public GameObject Star;
	private AliahScript script;
	private float obj1;
	private float obj2;
	private float obj3;
	private GameObject choice1;
	private GameObject choice2;
	private GameObject choice3;
	private SpawnScript ss1;
	private SpawnScript ss2;
	private SpawnScript ss3;
	private float createTime;

	// Use this for initialization
	void Start () {
		script = (AliahScript)Aliah.GetComponent (typeof(AliahScript));
		ss1 = (SpawnScript) Row1.GetComponent(typeof(SpawnScript));
		ss2 = (SpawnScript) Row2.GetComponent(typeof(SpawnScript));
		ss3 = (SpawnScript) Row3.GetComponent(typeof(SpawnScript));
		createTime = script.aliahCurrentX;
	}
	
	// Update is called once per frame
	void Update () {

		if (!script.pause)
		{
			if (script.aliahCurrentX - createTime >= (5f - (script.movement * 12.5f)))
			{
				bool nowall1 = false;
				bool nowall2 = false;
				bool nowall3 = false;
				obj1 = Random.value;
				obj2 = Random.value;
				obj3 = Random.value;
				if (obj1 >= 0.67f && obj2 >= 0.67f)
					nowall3 = true;
				else if (obj1 >= 0.67f && obj3 >= 0.67f)
					nowall2 = true;
				else if (obj2 >= 0.67f && obj3 >= 0.67f)
					nowall1 = true;

				//< 0.33f = coin
				// < 0.67f = largewall
				// = empty

				if (nowall1 || obj1 < 0.33f) {
				}
				else if (obj1 < 0.67f)
					ss1.Spawn (Coin);
				else
					ss1.Spawn (LargeWall);

				if (nowall2 || obj2 < 0.33f) {
				}
				else if (obj2 < 0.67f)
					ss2.Spawn (Coin);
				else
					ss2.Spawn (LargeWall);

				if (nowall3 || obj3 < 0.33f) {
				}
				else if (obj3 < 0.67f)
					ss3.Spawn (Coin);
				else 
					ss3.Spawn (LargeWall);
					
				createTime = script.aliahCurrentX;
			}
		}
		//Instantiate (obj, transform.position, Quaternion.identity);
		//Invoke ("Spawn", 2.5f - (script.movement * 20));
	}

}
