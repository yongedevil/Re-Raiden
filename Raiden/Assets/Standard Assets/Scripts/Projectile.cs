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
        
        private bool m_shooterIsPlayer;
        public bool shooterIsPlayer { get { return m_shooterIsPlayer; } } 

        private float m_launchSpeed;
        public float launchSpeed { get { return m_launchSpeed; } }

        private int m_dmg;
        public int damage { get { return m_dmg; } }

        private float m_lifetime;


        public void Awake()
        {
            m_projType = PROJECTILE_TYPE.TYPE_BASE;
            m_shooterIsPlayer = false;
            m_launchSpeed = 1;
            m_dmg = 1;
        }
        
		// Use this for initialization
		void Start ()
		{
            Destroy(gameObject, m_lifetime);
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
            m_shooterIsPlayer = false;
        }


        public void Shoot(Ship shooter, Vector3 dir)
        {
            if (Ship.SHIP_TYPE.TYPE_PLAYER == shooter.shipType)
                m_shooterIsPlayer = true;
            else
                m_shooterIsPlayer = false;

            if (null != this.rigidbody)
            {
                if (dir.sqrMagnitude > 1) dir.Normalize();
                this.rigidbody.velocity = launchSpeed * dir;
            }
        }


        public override void LoadData(DataNode node)
        {
            Debug.Log("Projectile.LoadData: node " + node.ToString());

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

            Debug.Log("Projectile.LoadData: projType " + m_projType + " | launchSpeed " + m_launchSpeed + " | dmg " + m_dmg);
        }

        void OnCollisionEnter(Collision col)
        {
            Ship ship = col.gameObject.GetComponent<Ship>();
            Debug.Log("ship " + (null != ship ? "Not null" : "NULL!"));
            if (null != ship)
            {
                if ((m_shooterIsPlayer) != (Ship.SHIP_TYPE.TYPE_PLAYER == ship.shipType))
                {
                    ship.UpdateHealth(-m_dmg);
                }

                Destroy(gameObject);
            }

        }
	}
}

