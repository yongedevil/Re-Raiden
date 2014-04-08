using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	int seconds = 1;
	public int damage;


	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, seconds);


	}
	
	// Update is called once per frame
	void Update () 
	{
	 
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name != "PlayerBullet(Clone)") 
		{

			if(col.gameObject.name == "Playercharacter")
			{
				print (col.gameObject.name);
				Player player = (Player)FindObjectOfType (typeof(Player));
				//player = gameObject.GetComponent<Player>();
				player.updateHealth(-10);
			}

			if(col.gameObject.name == "TestEnemy(Clone)")
			{
				TestAI testAI = (TestAI)FindObjectOfType(typeof(TestAI));
				testAI.updateEnemyhealth(-5);
			}

			Destroy (gameObject);
		}
	}
}
