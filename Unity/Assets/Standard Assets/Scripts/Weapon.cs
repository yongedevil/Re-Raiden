using UnityEngine;
using System.Collections;

namespace Raden
{
    public class Weapon
	{
		private Ship m_parent;

		private GameObject m_projTemplate;
		
		Weapon(Ship parent)
		{
			m_parent = parent;
			m_projTemplate = null;
		}


		public GameObject Fire(Vector3 dir)
		{
            GameObject projectile = null;

			if (null != m_projTemplate)
			{
                projectile = (GameObject)UnityEngine.Object.Instantiate(m_projTemplate, dir, Quaternion.identity);
			}

            return projectile;
		}

	}
}

