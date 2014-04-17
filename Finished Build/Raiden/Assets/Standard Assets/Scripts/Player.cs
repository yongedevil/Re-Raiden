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
	public void Start () 
	{
		alive = true;
	}
	
	// Update is called once per frame
	public void Update () 
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

		CheckBounds();

		if(health <= 0 && alive)
		{
			alive = false;
		}
		
		if (health <= 0) 
		{
			Destroy(gameObject);
			Application.LoadLevel("GameOver");
		}
	

	}

	void OnGUI ()
	{
		GUI.color = Color.black;
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

	private void CheckBounds()
	{
		Vector3 PlayerPos = transform.position;
		Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		
		Vector3 ScreenPos = Camera.main.WorldToScreenPoint(PlayerPos);
		
		if (ScreenPos.x < 0)
		{
			ScreenPos.x = 0;
			PlayerPos = Camera.main.ScreenToWorldPoint(ScreenPos);
		}
		
		else if (ScreenPos.x > Screen.width)
		{
			ScreenPos.x = Screen.width;
			PlayerPos = Camera.main.ScreenToWorldPoint(ScreenPos);
		}
		
		
		if (ScreenPos.y < 0)
		{
			ScreenPos.y = 0;
			PlayerPos = Camera.main.ScreenToWorldPoint(ScreenPos);
		}
		
		else if (ScreenPos.y > Screen.height)
		{
			ScreenPos.y = Screen.height;
			PlayerPos = Camera.main.ScreenToWorldPoint(ScreenPos);
		}
		
		transform.position = PlayerPos;
	}
}
