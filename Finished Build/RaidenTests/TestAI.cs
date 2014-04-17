using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaidenTests
{
    class Test_AI : Test
    {
        TestAI testAI;

        public void Start()
        {
            testAI = this.GetComponent<TestAI>();
        }

        protected override bool Run()
        {
            bool success = true;

            if (null != testAI)
            {

            }

            return success;
        }
    }
}
