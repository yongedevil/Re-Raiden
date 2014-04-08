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
    public class Weapon : iDataNode
	{
        public const string NODENAME = "WEAPON";
        public const string NODEVAR_WEPTYPE = "weaponType";
        public const string NODEVAR_OFFSET = "muzzelOffset";

        public enum WEAPON_TYPE
        {
            TYPE_BASE
        }

        private WEAPON_TYPE m_wepType;
        public WEAPON_TYPE weaponType { get { return m_wepType; } }

		private Ship m_parent;
        public Ship parent { get { return m_parent; } }

        private Vector3 m_offset;

        private Projectile m_projTemplate;
        public Projectile projectileTemplate { get { return m_projTemplate; } }

        public Weapon()
        {
            m_wepType = WEAPON_TYPE.TYPE_BASE;
            m_parent = null;
            m_offset = new Vector3(0, 0, 0);
            m_projTemplate = null;
        }

        public void Init(WEAPON_TYPE type, Projectile projTemplate, Ship parent, Vector3 offset)
        {
            m_wepType = type;
            m_parent = parent;
            m_offset = offset;
            m_projTemplate = projTemplate;
        }


        public Projectile Fire(Vector3 dir)
		{
            Entity projObj = null;
            Projectile proj = null;

            if (null != m_projTemplate && null != m_parent)
			{
                projObj = UnityEngine.Object.Instantiate(m_projTemplate, m_parent.position + m_offset, Quaternion.identity) as Entity;
                if (null == projObj) return null;

                Physics.IgnoreCollision(projObj.collider, m_parent.collider);

                proj = projObj.GetComponent<Projectile>();
                if (null == proj) return null;
                
                proj.Shoot(m_parent, dir);

			}

            return proj;
		}


        public void LoadData(DataNode node)
        {
            Debug.Log("Weapon.LoadData: node " + node.ToString());

            int wepType;
            if (node.HasValue(NODEVAR_WEPTYPE) && (int.TryParse(node.GetValue(NODEVAR_WEPTYPE), out wepType)))
            {
                m_wepType = (WEAPON_TYPE)wepType;
            }
            else
                m_wepType = WEAPON_TYPE.TYPE_BASE;


            if (node.HasValue(NODEVAR_OFFSET))
            {
                //setup offset
            }
            else
                m_offset = new Vector3(0, 0, 0);


            foreach (DataNode subnode in node.GetNodes())
            {
                if (Projectile.NODENAME == subnode.name)
                {
                    GameObject newObj = new GameObject("Projectile Template");
                    m_projTemplate = newObj.AddComponent<Projectile>();
                    m_projTemplate.LoadData(subnode);
                }
            }

            Debug.Log("Weapon.LoadData: wepType " + m_wepType + " | offset " + m_offset);
        }

	}
}

