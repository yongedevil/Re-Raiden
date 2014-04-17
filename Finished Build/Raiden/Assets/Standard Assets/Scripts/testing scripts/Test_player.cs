using UnityEngine;
using System.Collections;

namespace RaidenTests
{
	class Test_player : Test
	{
		private Player player;

		public override void Start()
		{
			base.Start ();

			player = this.GetComponent<Player>();
		}

        protected override bool Run()
		{
			bool success = true;
			
			if (null != player)
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

			player.health = 100;
			player.updateHealth (-10);

			return (100 - 10) == player.health;
		}


		private bool TestDeath()
		{
			CurTestName = "TestDeath";

			player.health = 0;
			player.Update ();

			
			//WHY is alive static!
			return false == Player.alive;
		}
    }
}
