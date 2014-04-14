using UnityEngine;
using System.Collections;

public class End : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		Debug.Log(c.gameObject.name);
		if(c.gameObject.name == "Playercharacter")
		{
			Destroy(c.gameObject);
			Application.LoadLevel("Victory");
		}
		
	}
}
