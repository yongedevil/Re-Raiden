using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	float moveSpeed = 6.0f;
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
	}
}
