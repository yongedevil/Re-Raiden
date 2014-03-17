using UnityEngine;
using System.Collections.Generic;

namespace Raiden
{
    /*--------------------------------------------------*\
     * NPC class                                        *
     * Represents an NPC ship.                          *
     * Base class for all NPCs.                         *
    \*--------------------------------------------------*/
    public abstract class NPC : Ship
    {
        public enum NPC_TYPE
        {
            TYPE_BASE
        }

        public abstract NPC_TYPE npcType { get; }

        public ENTITY_TYPE entityType { get { return ENTITY_TYPE.TYPE_SHIP; } }



    }
}
