using UnityEngine;
using System.Collections;

public class Startmenu : MonoBehaviour 
{
	public string type = "Blank";
	public bool info = true;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(260,50,500,100), type))
		{
			Application.LoadLevel("Raiden");
		}

		if(GUI.Button(new Rect(260,180,500,100),"Quit!!"))
		{
			Application.Quit();
		}
	}
}
