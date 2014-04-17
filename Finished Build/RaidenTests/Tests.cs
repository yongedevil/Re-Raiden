using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaidenTests
{
    public abstract class Test : MonoBehaviour
    {

        public string TestName;

        
        public void Awake()
        {
            AddTest();
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
                result = test.Run();

                Console.WriteLine("Test: " + test.TestName + " = " + (result ? "Success" : "Failure"));

                if (!result)
                    break;
            }

            return result;
        }

    }
}
