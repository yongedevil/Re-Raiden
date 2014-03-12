using UnityEngine;
using System.Collections;
using System.Xml;

namespace Raden
{
    [System.Serializable]
    public class Weapon
	{
		private Ship m_parent;
        private Projectile m_proj;

        Weapon()
        {
            m_parent = null;
            m_proj = null;
        }

		Weapon(Ship parent)
		{
			m_parent = parent;
            m_proj = null;
		}


        public Projectile Fire(Vector3 dir)
		{
            GameObject projObj = null;
            Projectile proj = null;

            if (null != m_proj && null != m_parent)
			{
                projObj = UnityEngine.Object.Instantiate(m_proj.template, m_parent.position, Quaternion.identity) as GameObject;
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

