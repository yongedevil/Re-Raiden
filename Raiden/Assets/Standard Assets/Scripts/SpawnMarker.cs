using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    public class SpawnMarker : MonoBehaviour
    {
        private Transform m_transform;

        public void Awake()
        {

        }

        // Use this for initialization
        public void Start()
        {
            m_transform = this.GetComponent<Transform>();
            if (null == m_transform)
            {
                m_transform = this.gameObject.AddComponent<Transform>();
            }
        }

        // Update is called once per frame
        public void Update()
        {
            //check if on screen

        }

    }
}
