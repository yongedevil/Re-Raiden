using UnityEngine;
using System.Collections.Generic;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Pickup class                                     *
     * Represents a NPC drop that can be picked up by   *
     * the player.                                      *
     * Base class for all Pickups.                      *
    \*--------------------------------------------------*/
    public abstract class Pickup : Entity
    {
        public enum PICKUP_TYPE
        {
            TYPE_BASE
        }

        public abstract PICKUP_TYPE pickupType { get; }

        public override ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_PICKUP; } }
    }
}
