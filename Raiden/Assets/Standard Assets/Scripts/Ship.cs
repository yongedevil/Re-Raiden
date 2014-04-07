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
        public const string NODEVAR_SPEED = "speed";

        public enum SHIP_TYPE
        {
            TYPE_BASE,
            TYPE_PLAYER,
            TYPE_NPC
        }

        private SHIP_TYPE m_shipType;
        public SHIP_TYPE shipType { get { return m_shipType; } }

        public override ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_SHIP; } }

        private int m_health;
        public int health { get { return m_health; } }

        private float m_speed;
        public float speed { get { return m_speed; } } 

        private List<Weapon> mlist_weapons;


        public virtual void Awake()
        {
            mlist_weapons = new List<Weapon>();
        }

		// Use this for initialization
        public virtual void Start()
		{
            Debug.Log("Ship.Start: loading file " + filePath);
            List<DataNode> nodes = FileIO.LoadFile(filePath);

            foreach (DataNode node in nodes)
            {
                if (node.name == Ship.NODENAME)
                    this.LoadData(node);
            }
        }

        public virtual void Update()
        {
        }


        public override void LoadData(DataNode node)
        {
            Debug.Log("Ship.LoadData: node " + node.ToString());

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

            float speed;
            if (node.HasValue(NODEVAR_HEALTH) && (float.TryParse(node.GetValue(NODEVAR_SPEED), out speed)))
            {
                m_speed = speed;
            }

            foreach (DataNode subnode in node.GetNodes())
            {
                if (Weapon.NODENAME == subnode.name)
                {
                    Weapon newWep = new Weapon();
                    newWep.LoadData(subnode);
                    mlist_weapons.Add(newWep);
                }
            }

            Debug.Log("Ship.LoadData: shipType " + m_shipType + " | health " + m_health + " | speed " + m_speed);
        }

        public void UpdateHealth(int amount)
        {
            m_health += amount;
        }

        public void FireWeapon(int weaponIndex, Vector3 dir)
        {
            if(weaponIndex >= 0 && weaponIndex < mlist_weapons.Count)
                mlist_weapons[weaponIndex].Fire(dir);
        }
	}
}
