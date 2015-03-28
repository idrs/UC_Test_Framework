using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsecaseTesting;
using Moq;

namespace Prototype
{
    [TestClass]
    public class UsecaseTests_Activity_Data
    {
        public class TestActivity_Login_Data
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }

        public class TestActivity_Login : Activity<TestActivity_Login_Data>
        {
            public override void DoActivity()
            {
                if (Data.Name != "Testname")
                    throw new Exception();

                if (Data.Password != "Testpassword")
                    throw new Exception();
            }
        }

        [TestMethod]
        public void Activity_Data_StrongTyped()
        {
            TestActivity_Login_Data testactivity_login_data = new TestActivity_Login_Data()
            {
                Name = "Testname",
                Password = "Testpassword"
            };

            UsecaseTest usecaseTest = new UsecaseTest();
            usecaseTest.Flow.StartWith<TestActivity_Login>(testactivity_login_data);

            usecaseTest.RunUsecase();
        }

        public class TestActivity_Login_Data_Wrong
        {
            public string Blabla { get; set; }
        }

        [TestMethod]
        public void Activity_Data_WrongType()
        {
            TestActivity_Login_Data_Wrong testactivity_login_data_wrong = new TestActivity_Login_Data_Wrong()
            {
                Blabla = "blabla"
            };

            UsecaseTest usecaseTest = new UsecaseTest();
            usecaseTest.Flow.StartWith<TestActivity_Login>(testactivity_login_data_wrong);
            try
            {
                usecaseTest.RunUsecase();

            }
            catch (ArgumentException)
            { 
            }
        }

        [TestMethod]
        public void Activity_Data_NoType()
        {
            UsecaseTest usecaseTest = new UsecaseTest();
            usecaseTest.Flow.StartWith<TestActivity_Login>();
            
            try
            {
                usecaseTest.RunUsecase();
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
