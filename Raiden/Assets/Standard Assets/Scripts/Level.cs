using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    public class Level : MonoBehaviour
    {
        public enum LevelState
        {
            STATE_INVALID,
            STATE_PAUSE,
            STATE_RUNNING
        }


        private string m_lvlName;
        public string levelName { get { return m_lvlName; } }

        private Terrain m_lvlTerrain;

        private LevelState m_lvlState;
        public LevelState levelState { get { return m_lvlState; } }

        private Vector3 m_lvlOffset;
        private Vector3 m_lvlVel;
        public Vector3 levelOffset { get { return m_lvlOffset; } }
        public Vector3 levelVelocity { get { return m_lvlVel; } }

        private Vector3 m_playerSpawn;
        public Vector3 playerSpawn { get { return m_playerSpawn; } } 
        private List<SpawnMarker> mlist_npcSpawns;  //spawners will check if they are on screen and sapwn a clone of the entity attached to them


        public void Awake()
        {
            m_lvlName = "";

            m_lvlOffset = new Vector3(0, 0, 0);
            m_lvlVel = new Vector3(0, 0, 0);

            m_playerSpawn = new Vector3(0, 0, 0);
            mlist_npcSpawns = new List<SpawnMarker>();

        }

        // Use this for initialization
        public void Start()
        {
            m_lvlTerrain = this.GetComponent<Terrain>();
            if (null == m_lvlTerrain)
                this.gameObject.AddComponent<Terrain>();
        }

        // Update is called once per frame
        public void Update()
        {
            //move terrain
            if (LevelState.STATE_RUNNING == levelState)
            {
                m_lvlTerrain.transform.position += m_lvlVel;
            }
        }

        public void Init(string name)
        {
            m_lvlName = name;
        }
    }
}
