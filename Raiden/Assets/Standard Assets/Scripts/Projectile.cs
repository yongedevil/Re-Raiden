using UnityEngine;
using System.Collections;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Projectile class                                 *
     * Represents a projectile fired by a weapon.       *
     * Base class for all projectiles.                  *
    \*--------------------------------------------------*/
    public class Projectile : Entity
	{
        public const string NODENAME = "PROJECTILE";
        public const string NODEVAR_PROJTYPE = "projectileType";
        public const string NODEVAR_SPEED = "projectileSpeed";
        public const string NODEVAR_DAMAGE = "projectileDamage";

        public enum PROJECTILE_TYPE
        {
            TYPE_BASE
        }

		private const int DEFAULT_DAMAGE = 5;

        private PROJECTILE_TYPE m_projType;
        public PROJECTILE_TYPE projectileType { get { return m_projType; } }

        public override ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_PROJECTILE; } }

        private Ship m_shooter;
        public Ship shooter { get { return m_shooter; } }

        private float m_launchSpeed;
        public float launchSpeed { get { return m_launchSpeed; } }

        private int m_dmg;
        public int damage { get { return m_dmg; } }


        public void Awake()
        {
            m_projType = PROJECTILE_TYPE.TYPE_BASE;
            m_shooter = null;
            m_launchSpeed = 1;
            m_dmg = 1;
        }
        
		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			
		}

        public void Init(PROJECTILE_TYPE type, int damage, float launchSpeed)
        {
            m_projType = type;
            m_dmg = damage;
            m_launchSpeed = launchSpeed;
            m_shooter = null;
        }


        public void Shoot(Ship shooter, Vector3 dir)
        {
            m_shooter = shooter;

            if (null != this.rigidbody)
            {
                if (dir.sqrMagnitude > 1) dir.Normalize();
                this.rigidbody.velocity = launchSpeed * dir;
            }
        }


        public void LoadData(DataNode node)
        {
            int projType;
            if (node.HasValue(NODEVAR_PROJTYPE) && (int.TryParse(node.GetValue(NODEVAR_PROJTYPE), out projType)))
            {
                m_projType = (PROJECTILE_TYPE)projType;
            }
            else
                m_projType = PROJECTILE_TYPE.TYPE_BASE;

            float speed;
            if (node.HasValue(NODEVAR_SPEED) && (float.TryParse(node.GetValue(NODEVAR_SPEED), out speed)))
            {
                m_launchSpeed = speed;
            }
            else
                m_launchSpeed = 10;

            int damage;
            if (node.HasValue(NODEVAR_DAMAGE) && (int.TryParse(node.GetValue(NODEVAR_DAMAGE), out damage)))
            {
                m_dmg = damage;
            }
            else
                m_dmg = 10;
        } 
	}
}

