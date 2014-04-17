using UnityEngine;
using System.Collections;

public class TestAI : MonoBehaviour 
{
	public enum TestEnemyState{Idle, Attack, Chase};

	public float attackDistance = 10.0f;
	public float idleDistance = 15.0f;
	public float chaseDistance = 20.0f;
	public float awareDistance = 20.0f;
	public float moveSpeed = 4.0f;
	public float fireRate;
	public Transform player;
	public Transform Gun;
	public GameObject Bullet;
	public int enemyHealth;
	static public bool alive = true;

	private TestEnemyState state;
	private float CoolDown;
	private Vector3 moveDirection;

    public TestAI()
    {
    }

	public void Awake()
	{
		state = TestEnemyState.Idle;
		moveDirection = Vector3.zero;
		CoolDown = 0;
		fireRate = 1.0f;
	}

	// Use this for initialization
	public void Start () 
	{
		Player playerObj = (Player)FindObjectOfType (typeof(Player));
		player = playerObj.transform;

	}
	
	// Update is called once per frame
	public void Update () 
	{

		float dist = Vector3.Distance(player.position, transform.position);
		RaycastHit hit;
		checkState();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if(Physics.Raycast(transform.position, fwd, 30))
		{
			//print ("Move Zig");
		}

		switch(state)
		{
			case TestEnemyState.Attack:
				attack();
				runAfter();
		    	idle();
			break;

			case TestEnemyState.Chase:
			runAfter();
			break;

			case TestEnemyState.Idle:

			break;
		}

		if(enemyHealth <= 0)
		{
			Destroy(gameObject);
			alive = false;
		}

	}

	public void updateEnemyhealth(int amount) 
	{
		enemyHealth += amount;
	}

	void checkState()
	{
		float dist = Vector3.Distance(player.position,transform.position);
		
		
		bool isVisible = true;
		Vector3 pos = transform.position;
		Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		
		foreach (Plane plane in cameraPlanes)
		{
			if (!plane.GetSide(pos))
			{
				isVisible = false;
				break;
			}
			
		}
		
		//attacks the player
		if (isVisible)
		{
			state = TestEnemyState.Attack;
			return;
		}

		//chases the player
		if(dist < chaseDistance)
		{
			state = TestEnemyState.Chase;
			return;
		}
		//not aware of the player
		if(dist > awareDistance)
		{
			state = TestEnemyState.Idle;
			return;
		}
	}

	void attack()
	{   
		if (Player.alive) 
		{
		  transform.LookAt (player);
		  
		  if(Time.time > CoolDown)
		  {
		    if(Time.time > CoolDown)
			{
			 CoolDown = Time.time + fireRate;
			 GameObject BulletInstance = Instantiate(Bullet, Gun.position, Gun.rotation) as GameObject;		
			 Physics.IgnoreCollision(BulletInstance.collider, collider);
			 BulletInstance.rigidbody.velocity = transform.TransformDirection(Vector3.forward*20);
			}
		  }
		}
	}

	void runAfter()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation,
		Quaternion.LookRotation(player.position - transform.position), 30.0f*Time.deltaTime);
		
		gameObject.transform.Translate(0,0,3*Time.deltaTime);
	}

	void idle()
	{

	}

	void OnCollisionEnter(Collision c)
	{

		if(c.gameObject.name == "Playercharacter")
		{
			Player player = (Player)FindObjectOfType (typeof(Player));
			player.updateHealth(-50);
			Destroy(gameObject);
		}
	}
}
