using UnityEngine;
using System.Collections;

namespace Raiden
{
    public class Bullet : MonoBehaviour
    {

        int seconds = 1;

<<<<<<< HEAD
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
=======
        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, seconds);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
>>>>>>> 330cb868afc953eed88fe906aef6091f2c91a997
}
