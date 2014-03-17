using UnityEngine;
using System.Collections;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Projectile class                                 *
     * Represents a projectile fired by a weapon.       *
     * Base class for all projectiles.                  *
    \*--------------------------------------------------*/
    public abstract class Projectile : Entity
	{
        enum PROJECTILE_TYPE
        {
            TYPE_BASE
        }

		private const int DEFAULT_DAMAGE = 5;

        public abstract PROJECTILE_TYPE projectileType { get; }
        public ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_PROJECTILE; } }

        private Ship m_shooter;
        public Ship shooter { get { return m_shooter; } }

        private float m_launchSpeed;
        public float launchSpeed { get { return m_launchSpeed; } }

        private int m_dmg;
        public int damage { get { return m_dmg; } }

		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			
		}

        public void Initilize(int damage, float launchSpeed)
        {
        }


        public void Shoot(Ship shooter)
        {
            m_shooter = shooter;
        }
	}
}

