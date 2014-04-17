using UnityEngine;
using System.Collections;

namespace RaidenTests
{
    class Test_testAI : Test
    {
        private TestAI testAI;

        public void Start()
        {
            testAI = this.GetComponent<TestAI>();
        }

        protected override bool Run()
        {
            bool success = true;

            if (null != testAI)
			{
				if(!TestUpdateHealth())
					success = false;
				Debug.Log("Test: " + TestName + "." + CurTestName + " = " + (success ? "Success" : "Failure"));

				if(!TestDeath())
					success = false;
				Debug.Log("Test: " + TestName + "." + CurTestName + " = " + (success ? "Success" : "Failure"));

            }

            return success;
        }


		private bool TestUpdateHealth()
		{
			CurTestName = "TestUpdateHealth";

			testAI.enemyHealth = 100;
			testAI.updateEnemyhealth (-10);

			return (100 - 10) == testAI.enemyHealth;
		}

		private bool TestDeath()
		{
			CurTestName = "TestDeath";
			
			testAI.enemyHealth = 0;
			testAI.Update ();

			
			//WHY is alive static!
			return false == TestAI.alive;
		}
    }
}
