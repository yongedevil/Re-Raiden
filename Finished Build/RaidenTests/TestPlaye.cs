using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidenTests
{
    class TestPlayer : Test
    {
        public TestPlayer() : base("PLAYER TEST") { }

        protected override bool Run()
        {
            Player player = new Player();
            return true;
        }
    }
}
