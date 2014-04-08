using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Entity class                                     *
     * Base class for all objects used in Raden         *
    \*--------------------------------------------------*/                                         
    public abstract class Entity : MonoBehaviour, iDataNode
    {
        public enum ENTITY_TYPE
        {
            TYPE_BASE,
            TYPE_SHIP,
            TYPE_PROJECTILE,
            TYPE_PICKUP
        };

        public abstract ENTITY_TYPE entityType { get; }

        public string filePath;

        public Vector3 position
        {
            get
            {
                if (this.transform)
                    return this.transform.position;
                return new Vector3(0, 0, 0);
            }
            set
            {
                if (this.transform)
                    this.transform.position = value;
            }
        }

        public Vector3 velocity
        {
            get
            {
                if (this.rigidbody)
                    return this.rigidbody.velocity;

                return new Vector3(0, 0, 0);
            }
            set
            {
                if (this.rigidbody)
                    this.rigidbody.velocity = value;
            }
        }
        
        public abstract void LoadData(DataNode node);

    }
}
