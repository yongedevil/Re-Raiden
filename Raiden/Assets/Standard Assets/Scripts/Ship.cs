using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Raden
{
	public class Ship : MonoBehaviour
	{
        [SerializeField]
        public List<Weapon> weapons;

        public Vector3 position { get { return (null != transform ? transform.position : new Vector3(0, 0, 0)); } }

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	}
}
