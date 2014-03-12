using UnityEngine;
using System.Collections;

namespace Raden
{
	public class Projectile : MonoBehaviour
	{
		private const int DEFAULT_DAMAGE = 5;

        private GameObject m_template;
        public GameObject template { get { return m_template; } }


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

