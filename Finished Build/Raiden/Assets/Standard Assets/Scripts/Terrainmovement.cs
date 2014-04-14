using UnityEngine;
using System.Collections;

public class Terrainmovement : MonoBehaviour 
{
	public float moveSpeed = -50.0f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
