using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RaidenTests
{
    public abstract class Test : MonoBehaviour
    {
		public bool runtest;
		private bool testAlreadyRun = false;

        public string TestName;
		protected string CurTestName;

        
        public virtual void Awake()
        {
			AddTest();
			testAlreadyRun = false;
        }

		public virtual void Start()
		{

		}

		public virtual void Update()
		{
			Test.RunTests ();
		}


        protected abstract bool Run();


        private void AddTest()
        {
            if (null == listTests)
                listTests = new List<Test>();
            listTests.Add(this);
        }





        private static List<Test> listTests = new List<Test>();

        public static bool RunTests()
		{
			bool result = true;

			foreach (Test test in listTests)
			{
				if (test.runtest && !test.testAlreadyRun)
				{
					test.testAlreadyRun = true;
					result = test.Run ();

					Debug.Log ("Test: " + test.TestName + " = " + (result ? "Success" : "Failure"));

					if (!result)
						break;
				}
			}

            return result;
        }

    }
}
