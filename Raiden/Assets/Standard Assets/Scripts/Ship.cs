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
        public const string NODENAME = "SHIP";
        public const string NODEVAR_SHIPTYPE = "shipType";
        public const string NODEVAR_HEALTH = "health";

        public enum SHIP_TYPE
        {
            TYPE_BASE,
            TYPE_PLAYER
        }

        private SHIP_TYPE m_shipType;
        public SHIP_TYPE shipType { get { return m_shipType; } }

        public override ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_SHIP; } }

        private int m_health;
        public int health { get { return m_health; } }

        [SerializeField]
        public List<Weapon> weapons;


		// Use this for initialization
		void Start ()
		{
	
		}

        public void LoadData(DataNode node)
        {
            int shipType;
            if(node.HasValue(NODEVAR_SHIPTYPE) && (int.TryParse(node.GetValue(NODEVAR_SHIPTYPE), out shipType)))
            {
                m_shipType = (SHIP_TYPE)shipType;
            }

            int health;
            if (node.HasValue(NODEVAR_HEALTH) && (int.TryParse(node.GetValue(NODEVAR_HEALTH), out health)))
            {
                m_health = health;
            }

            foreach (DataNode subnode in node.GetNodes())
            {
                if (Weapon.NODENAME == subnode.name)
                {
                    Weapon newWep = new Weapon();
                    newWep.LoadData(subnode);
                    weapons.Add(newWep);
                }
            }             
        }
	
		// Update is called once per frame
		void Update ()
		{
	
		}
        
	}
}
