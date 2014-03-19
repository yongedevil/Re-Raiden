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
        public enum SHIP_TYPE
        {
            TYPE_BASE,
            TYPE_PLAYER
        }

        private SHIP_TYPE m_shipType;
        public SHIP_TYPE shipType { get { return m_shipType; } }

        public override ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_SHIP; } }

        [SerializeField]
        public List<Weapon> weapons;


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
