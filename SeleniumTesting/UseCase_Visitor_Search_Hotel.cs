using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using UsecaseTesting;

namespace SeleniumTesting
{
    [TestClass]
    public class UseCase_Visitor_Search_Hotel
    {
        [TestMethod]
        public void Search_Cheapes_In_Berlin()
        {
            Search search = new Search()
            {
                Input = "Berlin"
            };

            Order order = new Order()
            {
                Sortorder = "Preis"
            };

            ChromeBrowser_Setting chromeBrowserSetting = new ChromeBrowser_Setting("www.hotel.de");

            UsecaseTest usecaseTest = new UsecaseTest(chromeBrowserSetting);
            usecaseTest.Flow.StartWith<Activity_Search_City>(search).Then<Activity_Order_ResultList>(order);
            usecaseTest.RunUsecase();
        }


    }
}

