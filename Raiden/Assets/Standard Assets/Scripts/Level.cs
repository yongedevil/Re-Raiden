using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    public class Level : MonoBehaviour
    {
        private string m_lvlName;
        public string levelName { get { return m_lvlName; } }

        private Vector3 m_lvlOffset;
        private Vector3 m_lvlVel;
        public Vector3 levelOffset { get { return m_lvlOffset; } }
        public Vector3 levelVelocity { get { return m_lvlVel; } }

        private Vector3 m_playerSpawn;

        private List<Vector3> mlist_npcSpawns;


        public void Awake()
        {
            m_lvlName = "";

            m_lvlOffset = new Vector3(0, 0, 0);
            m_lvlVel = new Vector3(0, 0, 0);

            m_playerSpawn = new Vector3(0, 0, 0);
            mlist_npcSpawns = new List<Vector3>();
        }

        // Use this for initialization
        public void Start()
        {
        }

        // Update is called once per frame
        public void Update()
        {

        }

        public void Init(string name)
        {
            m_lvlName = name;
        }
    }
}
