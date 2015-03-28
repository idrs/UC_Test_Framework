using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsecaseTesting;
using Moq;

namespace Prototype
{
    [TestClass]
    public class UsecaseTests_PrePostChecks
    {
        public class TestActivity_PrePostChecks_Successful : Activity
        {
            public override bool Precheck()
            {
                return true;
            }

            public override bool Postcheck()
            {
                return true;
            }
        }

        public class TestActivity_PrePostChecks_PrecheckFailed : Activity
        {
            public override bool Precheck()
            {
                return false;
            }

            public override bool Postcheck()
            {
                return true;
            }
        }

        public class TestActivity_PrePostChecks_PostcheckFailed : Activity
        {
            public override bool Precheck()
            {
                return true;
            }

            public override bool Postcheck()
            {
                return false;
            }
        }

        [TestMethod]
        public void PrePostChecks_Successful()
        {
            //UsecaseTest usecaseTest = new UsecaseTest();

            //usecaseTest.Flow.StartWith<TestActivity_PrePostChecks_Successful>();

            //Mock<Messaging_Interface> msg = new Mock<Messaging_Interface>();
            //msg.Setup(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()));
            //usecaseTest.SendMessages = msg.Object;
            //usecaseTest.RunUsecase();

            //msg.Verify(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void PrePostChecks_PrecheckFailed()
        {
            //UsecaseTest usecaseTest = new UsecaseTest();

            //usecaseTest.Flow.StartWith<TestActivity_PrePostChecks_PrecheckFailed>();

            //Mock<Messaging_Interface> msg = new Mock<Messaging_Interface>();
            //msg.Setup(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()));
            //usecaseTest.SendMessages = msg.Object;
            
            //usecaseTest.RunUsecase();

            //msg.Verify(y => y.Submit(It.Is<string>(x => x == "precheck"), It.Is<string>(x => x == "failed")), Times.Once);
        }

        [TestMethod]
        public void PrePostChecks_PostcheckFailed()
        {
            //UsecaseTest usecaseTest = new UsecaseTest();

            //usecaseTest.Flow.StartWith<TestActivity_PrePostChecks_PostcheckFailed>();

            //Mock<Messaging_Interface> msg = new Mock<Messaging_Interface>();
            //msg.Setup(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()));
            //usecaseTest.SendMessages = msg.Object;
            //usecaseTest.RunUsecase();

            //msg.Verify(y => y.Submit(It.Is<string>(x => x == "postcheck"), It.Is<string>(x => x == "failed")), Times.Once);
        }
    }
}
