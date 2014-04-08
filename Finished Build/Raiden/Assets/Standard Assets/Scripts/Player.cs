using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	float moveSpeed = 6.0f;
	public Transform Vulcans;
	public GameObject Playerbullet;
	public int health;
	public string healthcounter = "Health: ";
	public string healthcounter2 = " /100";
	static public bool alive = true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	  //Player controls
		float hValue = Input.GetAxis ("Horizontal");
		transform.Translate (new Vector3(hValue*moveSpeed,0,0)*Time.deltaTime);
		float vValue = Input.GetAxis ("Vertical");
		transform.Translate (new Vector3(0,0,vValue*moveSpeed)*Time.deltaTime);

		if(Input.GetButtonDown("Fire1"))
		{
			GameObject PlayerbulletInstance = Instantiate(Playerbullet, Vulcans.position, Vulcans.rotation) as GameObject;
			Physics.IgnoreCollision(PlayerbulletInstance.collider, collider);

			if(Input.GetButtonDown("Fire1"))
			{

				
				PlayerbulletInstance.rigidbody.velocity = transform.TransformDirection(Vector3.forward*20);
			}	
		}

		if(health <= 0 && alive)
		{
			alive = false;
		}
		
		if (health <= 0) 
		{
			Destroy(gameObject);
			Application.LoadLevel("GameOver");
		}

		Vector3 PlayerPos = transform.position;

		Debug.Log("x: " + PlayerPos.x + " / z: " + PlayerPos.z);
		if (PlayerPos.x >= 14.2342) 
		{
			PlayerPos.x = 14.15f;
			transform.position = PlayerPos;
		}

		if (PlayerPos.z <= -19.5) 
		{
			PlayerPos.z = -19.5f;
			transform.position = PlayerPos;
		}

		if (PlayerPos.z >= -6.12) 
		{
			PlayerPos.z = -6.12f;
			transform.position = PlayerPos;
		}

		if (PlayerPos.x <= -14.4) 
		{
			PlayerPos.x = -14.4f;
			transform.position = PlayerPos;
		}
		
	}

	void OnGUI ()
	{
		GUI.color = Color.white;
		if(health >0)
		{
			GUI.Label(new Rect(50,370,100,100), health.ToString());
			GUI.Label (new Rect(10, 370, 100, 100), healthcounter.ToString());
			GUI.Label (new Rect(68, 370, 100, 100), healthcounter2.ToString());
		}

    }

   public void updateHealth(int amount)
   {
     health += amount;
   }
}
