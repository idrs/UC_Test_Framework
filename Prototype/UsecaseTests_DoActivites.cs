using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsecaseTesting;

namespace Prototype
{
    [TestClass]
    public class UsecaseTests_DoActivites
    {
        public class TestActivity_First : Activity
        {
            public override void DoActivity()
            {
                throw new Exception("doactivity_ok");
            }
        }

        [TestMethod]
        public void Run_one_activity()
        {
            UsecaseTest usecaseTest = new UsecaseTest();

            usecaseTest.Flow.StartWith<TestActivity_First>();
            try
            {
                usecaseTest.RunUsecase();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("doactivity_ok", ex.Message);
            }
        }

        

    }
}
