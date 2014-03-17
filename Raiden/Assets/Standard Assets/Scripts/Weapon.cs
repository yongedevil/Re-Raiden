using UnityEngine;
using System.Collections;
using System.Xml;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Weapon class                                     *
     * Represents a weapon carried by a ship.           *
     * Base class for all weapons.                      *
    \*--------------------------------------------------*/
    [System.Serializable]
    public abstract class Weapon
	{
        enum WEAPON_TYPE
        {
            TYPE_BASE
        }

        public abstract WEAPON_TYPE weaponType { get; }

		private Ship m_parent;
        public Ship parent { get { return m_parent; } }

        private Projectile m_projTemplate;
        public Projectile projectileTemplate { get { return m_projTemplate; } }

        Weapon()
        {
            m_parent = null;
            m_projTemplate = null;
        }

		Weapon(Ship parent)
		{
			m_parent = parent;
            m_projTemplate = null;
		}


        public Projectile Fire(Vector3 dir)
		{
            Entity projObj = null;
            Projectile proj = null;

            if (null != m_projTemplate && null != m_parent)
			{
                projObj = UnityEngine.Object.Instantiate(m_projTemplate, m_parent.position, Quaternion.identity) as Entity;
                if (null == projObj) return null;

                Physics.IgnoreCollision(projObj.collider, m_parent.collider);

                proj = projObj.GetComponent<Projectile>();
                if (null == proj) return null;
                
                proj.Shoot(m_parent);
                if (null != projObj.rigidbody)
                {
                    if (dir.sqrMagnitude > 1) dir.Normalize();
                    projObj.rigidbody.velocity = proj.launchSpeed * dir;
                }

			}

            return proj;
		}

	}
}

