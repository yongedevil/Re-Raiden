using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raiden
{
    /*--------------------------------------------------*\
     * Game class                                       *
     * Master class for running the game.               *
    \*--------------------------------------------------*/
    public class Game : MonoBehaviour
    {
        private int m_score;
        public int score { get { return m_score; } }

        private Player m_player;
        public Player player { get { return m_player; } }

        //master lists of templates to be cloned when creating new objects
        private List<NPC> mlist_npcTemplates;
        private List<Projectile> mlist_projectileTemplates;
        private List<Pickup> mlist_pickupTemplates;

        private List<Entity> mlist_entities;
    }
}
