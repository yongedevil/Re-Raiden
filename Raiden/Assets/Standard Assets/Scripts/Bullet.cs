﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{

	int seconds = 1;

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
		if (col.gameObject.name != "Playerbullet(Clone)") 
		{
			Destroy (gameObject);
		}
	}
}
