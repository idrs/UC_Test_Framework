using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsecaseTesting;

namespace Prototype
{
    /// <summary>
    /// Summary description for UsecaseTests_Environment
    /// </summary>
    [TestClass]
    public class UsecaseTests_Setting
    {
        private class ChromeEnvironment_Initailize : Setting
        {
            public override void Initialize()
            {
                throw new Exception("Initialize done");     
            }

            public override void Cleanup()
            {
                
            }
        }

        private class ChromeEnvironment_Cleanup : Setting
        {
            public override void Initialize()
            {
                
            }

            public override void Cleanup()
            {
                throw new Exception("Cleanup done");
            }
        }

        [TestMethod]
        public void EnvironmentTest_SeleniumInitailize()
        {
            ChromeEnvironment_Initailize env = new ChromeEnvironment_Initailize();
            UsecaseTest usecaseTest = new UsecaseTest(env);

            try
            {
                usecaseTest.RunUsecase();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Initialize done", ex.Message);
            }
        }
        

        [TestMethod]
        public void EnvironmentTest_SeleniumCleanup()
        {
            ChromeEnvironment_Cleanup env = new ChromeEnvironment_Cleanup();
            UsecaseTest usecaseTest = new UsecaseTest(env);

            try
            {
                usecaseTest.RunUsecase();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cleanup done", ex.Message);
            }
        }

    }

}
