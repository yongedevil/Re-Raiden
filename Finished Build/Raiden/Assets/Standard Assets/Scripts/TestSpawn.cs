using UnityEngine;
using System.Collections;

public class TestSpawn : MonoBehaviour 
{   
	public enum TestSpawnState{Idle, Spawn};

	public Transform Spawn;
	public GameObject TestEnemy;
	public float awareDistance = 35.0f;
	public float idleDistance = 25.0f;
	public Transform player;
	float maxSeconds = 5;
	float currentSeconds = 0;

	private TestSpawnState state;

	void Awake()
	{
		state = TestSpawnState.Idle;
	}

	// Use this for initialization
	void Start () 
	{
	
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
			//print ("Preparing to attack");
		}

		switch(state)
		{
		case TestSpawnState.Spawn:
			spawn();
			idle();
			break;

			
		case TestSpawnState.Idle:
			
			break;
		}
	}

	void checkState()
	{
		float dist = Vector3.Distance(player.position,transform.position);

		currentSeconds += Time.deltaTime;
		//attacks the player
		if (currentSeconds > maxSeconds) 
		{
			currentSeconds = 0;
			//Debug.Log (awareDistance.ToString () + " " + dist.ToString ());
			state = TestSpawnState.Spawn;
			return;
		} 

		else 
		{
			state = TestSpawnState.Idle;		
		}

		//not aware of the player

	}

	void spawn()
	{       
		    
			GameObject TestEnemyinstance = Instantiate(TestEnemy, Spawn.position, Spawn.rotation) as GameObject;
			//Destroy (gameObject);

	}

	void idle()
	{

	}
}
