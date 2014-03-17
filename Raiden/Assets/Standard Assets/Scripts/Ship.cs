using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Pickup class                                     *
     * Represents a ship.                               *
     * Base class for Player and NPC.                   *
    \*--------------------------------------------------*/
    public class Ship : Entity
    {
        public ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_SHIP; } }

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
