using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsecaseTesting;
using Moq;

namespace Prototype
{
    [TestClass]
    public class UsecaseTests_Assertion
    {
        public class TestActivity_AssertRun : Activity
        {
            public override void Assert(Assertion assertion)
            {
                assertion.Message = "test";
                assertion.AssertState = AssertionState.Fail;
            }
        }

        public class TestActivity_AssertRun_Second : Activity
        {
            public override void Assert(Assertion assertion)
            {
                assertion.Message = "test";
                assertion.AssertState = AssertionState.Fail;
            }
        }

        public class TestActivity_AssertRun_Third : Activity
        {
            public override void Assert(Assertion assertion)
            {
                assertion.Message = "test";
                assertion.AssertState = AssertionState.Fail;
            }
        }

        public class MockLog : LogFactory
        {
            public Activity_Assertion_Log mock_assertionLog { get; set; }
            public Activity_Assertion_Log GetAssertionLog()
            {
                return mock_assertionLog;
            }

            public Activity_Log mock_activityLog { get; set; }
            public Activity_Log GetActivityLog()
            {
                return mock_activityLog;
            }

            public Core_Log mock_corelog { get; set; }
            public Core_Log GetCoreLog()
            {
                return mock_corelog;
            }
        }


        [TestMethod]
        public void AssertRun_Failed()
        {
            //UsecaseTest usecaseTest = new UsecaseTest();

            //usecaseTest.Flow.StartWith<TestActivity_AssertRun>().AndAssert();

            //Mock<Messaging_Interface> msg = new Mock<Messaging_Interface>();
            //msg.Setup(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()));
            //usecaseTest.SendMessages = msg.Object;

            //try
            //{
            //    usecaseTest.RunUsecase();
            //}
            //catch (UsecaseAssertFailedException ex)
            //{
            //    msg.Verify(y => y.Submit(It.Is<string>(x => x == "assert failed"), It.Is<string>(x => x == ex.Message)), Times.Once);
            //    Assert.AreEqual("Prototype.UsecaseTests_Assertion+TestActivity_AssertRun", ex.Activity);
            //    Assert.AreEqual("test", ex.Message);
            //}
        }

        [TestMethod]
        public void AssertRun_Failed_WithoutAssert()
        {
            UsecaseTest usecaseTest = new UsecaseTest();

            usecaseTest.Flow.StartWith<TestActivity_AssertRun>().Then<TestActivity_AssertRun_Second>().Then<TestActivity_AssertRun_Third>();

            usecaseTest.RunUsecase();
        }

        [TestMethod]
        public void AssertRun_Failed_MultibleActivites()
        {
            //UsecaseTest usecaseTest = new UsecaseTest();

            //usecaseTest.Flow.StartWith<TestActivity_AssertRun>().Then<TestActivity_AssertRun_Second>().AndAssert().Then<TestActivity_AssertRun_Third>().AndAssert();

            //Mock<Messaging_Interface> msg = new Mock<Messaging_Interface>();
            //msg.Setup(y => y.Submit(It.IsAny<string>(), It.IsAny<string>()));
            //usecaseTest.SendMessages = msg.Object;

            //try
            //{
            //    usecaseTest.RunUsecase();
            //}
            //catch (UsecaseAssertFailedException ex)
            //{
            //    msg.Verify(y => y.Submit(It.Is<string>(x => x == "assert failed"), It.Is<string>(x => x == ex.Message)), Times.Once);
            //    Assert.AreEqual("Prototype.UsecaseTests_Assertion+TestActivity_AssertRun_Second", ex.Activity);
            //    Assert.AreEqual("test", ex.Message);
            //}
        }
    }
}
