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
	public Transform player;

	private TestEnemyState state;
	private float CoolDown;
	private Vector3 moveDirection;

	void Awake()
	{
		state = TestEnemyState.Idle;
		moveDirection = Vector3.zero;
		CoolDown = 0;
	}

	// Use this for initialization
	void Start () 
	{
		Player playerObj = (Player)FindObjectOfType (typeof(Player));
		player = playerObj.transform;

	}
	
	// Update is called once per frame
	void Update () 
	{
		float dist = Vector3.Distance(player.position, transform.position);
		RaycastHit hit;
		checkState();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if(Physics.Raycast(transform.position, fwd, 30))
		{
			print ("Move Zig");
		}

		switch(state)
		{
			case TestEnemyState.Attack:
				attack();
				runAfter();
		    	idle();
			break;

			case TestEnemyState.Chase:

			break;

			case TestEnemyState.Idle:

			break;
		}


	}

	void checkState()
	{
		float dist = Vector3.Distance(player.position,transform.position);
		
		//attacks the player
		if(dist < attackDistance)
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
		transform.LookAt(player);
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
		if(c.gameObject.name == "Player")
		{
			Destroy(gameObject);
		}
		
	}
}
